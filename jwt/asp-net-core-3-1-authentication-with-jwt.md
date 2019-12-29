#### asp.net core 3.1 JWT 认证与鉴权实践
在asp.net core中实现http无状态的认证与鉴权实基础的实现方式有多种，其中jwt方式是最常见与最方便的应用。  
在asp.net 2.2与3.1中jwt实践有一些小小区别，其中在文件：Startup.cs中的区别是：
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
 
    app.UseHttpsRedirection();
 
    app.UseRouting();
 
    -->app.UseAuthentication();<--
    app.UseAuthorization();
 
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```
这行代码是2.2与3.1的差别。  
#### 配置JWT身份验证  
要在.NET Core中配置JWT身份验证，我们需要修改Startup.csfile。 这是一个引导程序类，在我们的应用程序启动时运行。 在文件内部，我们具有ConfigureSerivces方法，该方法将服务添加到IServiceCollection容器，从而使服务可用于构造函数注入。

JWT的支持内置于ASP.NET Core 3.0中，我们将为JSON Web令牌配置身份验证中间件。

为了简单起见，我们将所有代码添加到ConfigureServices方法中。 但是更好的做法是使用扩展方法，以便我们可以从额外的代码行中释放我们的ConfigureServices方法。 如果您想学习如何做，并且想了解更多有关配置.NET Core Web API项目的信息，请查看：.NET Core服务配置。  
我们需要修改ConfigureServices方法以添加JWT支持：
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(opt => {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
 
            ValidIssuer = "http://localhost:5000",
            ValidAudience = "http://localhost:5000",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });
 
    services.AddControllers();
}
```  
为此，我们必须安装Microsoft.AspNetCore.Authentication.JwtBearer库。  


示例项目本目录中。

[具体参考地址](https://code-maze.com/authentication-aspnetcore-jwt-1/)  
