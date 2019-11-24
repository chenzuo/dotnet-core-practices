### ASP.NET Core 中使用日志“Scopes”关键字的正确姿势

本文是描述如何解决在ASP.NET Core中日志作用域块“scope”内发生异常时遇到的一系列问题。  

#### ASP.NET Core中使用Logging日志记录
ASP.NET Core中已经包含了一个强大的日志记录的基础功能，我们可以轻松的将各种信息通过日志组件把这些信息输出，例如输出到控制台、文件、数据库或者Windows EventLog中等等。  
日志记录这个功能能是贯穿在整个ASP.NET Core框架中的，你可以通过系统配置来从Kestrel或 者EF Core系统获取它们详细的日志信息。  
系统日志包含了一些公共特性，如：[event levels](https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x&view=aspnetcore-2.2#log-level),针对某一个event level进行日志筛选，或者通过创建跟踪某一消息的日志事件类别等。我们可以轻松的把这些日志消息结构化到的我们指定的地方。