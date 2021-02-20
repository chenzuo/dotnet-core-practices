### 使用MediatR编写解耦的应用代码：Mediator模式  
在我们往项目中，使用频率最多的几个开源项目分别是：  
- Automapper  
- Mediatr  
- Swagger  
- Fluent  
- Validation  
以上几个项目库在我们项目中应用非常广泛，也使得我们业务实更加快。本文将详细介绍MediatR的一些主要用法。  
#### 什么是MediatR？
简要的说：MediatR是mediator模式的一个实现。它是一种有行为的软件设计模式，通过使所有组件通过“中介”对象进行通信，而不是直接相互通信，它会帮助你构建更简单的应用代码。这样以来，可以有助你的代码保持高度解耦，并减少对象之间复杂依赖的数量。  
  
中介模式的用我们现实中的例子来解释的话，就像机场的空中交通管制（ATC）塔的功能一样。如果每架飞机都要与其他飞机直接通信，那将是一片混乱，取而代之的是，他们都向空中交通管制指挥塔报告，指挥塔决定如何将这些信息转发给其他飞机。在这个场景中，ATC塔是中介对象。  
  
使用MediatR包，可以将一些数据作为对象发送到mediator对象。根据发送到中介对象的数据类型，它决定调用哪些其他对象/服务。MediatR处理两种形式的消息： 
- Requests - 只能向另一个对象/服务发送消息。可以将该对象/服务的结果返回给原始调用者。
- Notifications - 可以向多个对象/服务发送消息。无法接收回任何数据。   
#### 设置 MediatR  
要使用MediatR，你可以从NuGet的源中安装MediatR引用包。asp.net core的安装试：  

>   `MediatR.Extensions.Microsoft.DependencyInjection`  

你只需要通过以下方法把所有MediaR服务注入到系统中：    
```C#
// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
  // other services

  services.AddMediatR(typeof(Startup));
}
```  

如果您使用的是不同的依赖注入方法，请查看MediatR官方的[WIKI](https://github.com/jbogard/MediatR/wiki)，了解如何为容器配置MediatR。   

### 发送请求（Sending Requests）

要发送请求，需要创建两个对象：请求和请求处理程序。 请求对像必须实现接口`IRequest `或者`IRequest<TResponse> `,这二个接口区别在于是否要求返回数据。其中请求对像必须要包含处理程序的要使用的数据，例如：
```C#
public class AdditionRequest : IRequest<int>
{
    public int A { get; set; }
    public int B { get; set; }
}
```  
请求处理程序应用实现接口：`IRequestHandler<TRequest>`或者`IRequestHandler<TRequest, TResponse>`,这二个接口中的`TRequest`所指的对应的对像就是上面这实现。  
```c#
public class AdditionRequestHandler : IRequestHandler<AdditionRequest, int>
{
    public Task<int> Handle(AdditionRequest request, CancellationToken cancellationToken)
    {
        var result = request.A + request.B;

        return Task.FromResult(result);
    }
}
```
通过MediatR发送请求数据，我们就需要使用到IMediator实例中的发送方法，把`AdditionRequest`实例对像传入到方法中进行处理。  
```C#
public class MyCalculator
{
    private readonly IMediator _mediator;

    public MyCalculator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<int> Add(int a, int b)
    {
        var request = new AdditionRequest { A = a, B = b };
        var result = await _mediator.Send(request);

        return result;
    }
}
```  
注意：如果你使用MediatR处理没有任何返回数据的请求时，实际上处理程序需要你返回了一个很特别的'空值'对像，这个空值对像是：`Unit` 。
```C#
// 请求对像
public class MyRequest : IRequest 
{
    // some properties
}
```
```C#
// 处理程序
public class MyRequestHandler : IRequestHandler<MyRequest>
{
    public Task<Unit> Handle(MyRequest request, CancellationToken cancellationToken)
    {
        // do stuff

        return Task.FromResult(Unit.Value);
    }
}
```
#### 发送通知（Sending Notifications） 
发送通知与发送请求非常类似，通知实例对像与通知应用处理程序也必须是要创建实现，不同之处在于：我们在使用MediatR发送通知时，只要实现了能处理对应用通知应用实例的处理程序都会被调用。
```c#
public class MyNotification : INotification
{
    // some properties
}
public class MyNotificationHandler1 : INotificationHandler<MyNotification>
{
    public Task Handle(MyNotification notification, CancellationToken cancellationToken)
    {
        // do stuff

        return Task.CompletedTask;
    }
}

public class MyNotificationHandler2 : NotificationHandler<MyNotification>
{
    public Task Handle(MyNotification notification, CancellationToken cancellationToken)
    {
        // do stuff

        return Task.CompletedTask;
    }
}
```  
如果实际执行一个发送通知实例，调用的是IMediator 实例中的`Publish `方法，而对这个方法传入的是一个notification 对像。当`Publish `方法被调用后，处理程序`MyNotificationHandler1 `和`MyNotificationHandler2 `将被调用（调用先后顺序按系统设置）。  
```C#
public class MyService
{
    private readonly IMediator _mediator;

    public MyService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Execute()
    {
        var notification = new MyNotification
        {
            // initialise
        };

        await _mediator.Publish(notification);
    }
}
```
#### 管理行为（Pipeline Behaviours）  
`Pipeline behaviours`是一个中间件处理应用，它在`request `之前和之后执行。这样就可以完成几个非常重要的任务，例如：记录日志，错误捕获，请求验证等垂直处理。  
如有很多`behaviours `，那么这些`behaviours `与系统中间件执行方式一致：你可以把多个`behaviours `进行串链接起来在一起，每个`behaviours `依次执行，直到执行到最后一个`behaviours`。然后在执行实际的请求处理程序，然后将结果传递回这个链中。  例如：
一个日志`behaviours `的实现`LoggingBehaviour `能写应用程序日志在请求执行前后。
```C#
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");

        // go to the next behaviour in the chain/to the request handler
        var response = await next();

        _logger.LogInformation($"Handled {typeof(TResponse).Name}");

        return response;
    }
}
```
在asp.net core中，要注册每个`PipelineBehaviour`到系统IOC容器中，可以在类`Startup`中的`ConfigureServices `方法里加入：  

`services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));`  
更多`behaviours `的使用方法请参考 [MediatR Behaviors](https://github.com/jbogard/MediatR/wiki/Behaviors)   
### 总结
在本文中，我介绍了mediator模式和NuGet包MediatR，它本身就是mediator模式的一个实现。我向您展示了如何发送请求（一对一）和通知（一对多），以及如何编写在每个请求之前/之后执行的中间件（管道行为）。