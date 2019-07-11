## .Net Core 实践
本文介绍dotnet core 环境下的一些常用使用方法和实践过程，包括：mvc,webapi,cache... 如果你任何问题可以直接与我联系，联系方式：chenzuo@hotmail.com,如需要转发请标明出处，本系列文章首发于[github.com/chenzuo](https://github.com/chenzuo/dotnet-core-practices);
+ 如何创建一个在windows和linux下运行的控制台应用程序
+ 如何使用 .net core开发一个中间键
+ 在 .net core中使用webapi、mvc进行简单的数据访问操作
+ 如何在 .net core中使用现有的缓存、日志等，并且如何快速定位生产线上的异常
+ 部署 .net core web程序到linux下使用nginx反向代理方式进行访问
+ 将https证书绑定到 .net core web服务中
+ 一些快捷的部署方式、脚本演示
+ 配合typescript语言进行前后端数据交互
+ 一些高级平台的部署使用，包括：servicefabric,k8s等 


### 阅读本文的群体和要掌握的基础知识点
- 面向 .net core 初中级学者
- 了解c#基础话法[（C#6.0+）](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6)
- 开发环境： .net core 2.2/3.0 ,nodejs,sqlserver express 2017
- 准备测试环境：多台云厂商的线上服务器
- 开发工具：Visual Studio 2019 、VS Code
- 目标成果：使初学者快速使用现在的工具快速的进行简单项目开发、部署、运维

### [（一）.NET Core 开发、运行环境准备](./dotnet-core-development-runtime-environment.md) 
 - [x] .NET Core SDK 在开发环境中的安装 
 - [x] 集成环境工具选择
 - [x] .NET Core 运行时在目标操作系统(linux)上的安装
 - [x] Nginx反向代理服务安装
 ### （二）Linux下的第一个可执行应用程序
- [ ] 命令行中创建”Hello World”控制台应用程序 
- [ ] 命令行编译、发布
- [ ] 手动方式部署到远端服务器
- [ ] 在Centos中应用命令行启动第一个控制应用程序
### (三)Linux下的第一个 ASP .NET Core WebApi应用程序
- [ ] 在Visual Studio 2019中创建ASP.NET WebApi应用程序
- [ ] 支持跨域资源访问(CORS)
- [ ] 发布并手动部署到Centos服务器中
- [ ] 在服务器中命令行测试已运行的WebApi接口
### (四)	编写前端页面访问WebApi接口
- [ ] 在VSCode中编写原生TS封装类似AJAX网络访问库
- [ ] 在静态页面中访问WebApi接口
- [ ] 使用”webpack”进行发布
### (五)	使用Nginx服务反向代理 .NET Core服务让外网访问
- [ ] Nginx中创建静态站点(Web)
- [ ] Nginx配置反向代理访问WebApi服务
- [ ] 配置各站点、配置https、域名绑定
- [ ] 在浏览器中测试结果
### (六)WebApi、Asp.Net MVC 中的单元测
### (七)ASP .NET CORE MVC常用安全配置
### (八).NET Core中的依赖注入
- [ ] 什么是依赖注入
- [ ] .NET Core应用程序中使用依赖注入
- [ ] ASP.NET Core 应用程序中使用依赖注入
- [ ] 编写一个依赖注入应用的单元测试
### (九)	访问数据库
- [ ] .NET Core平台下简单数据库访问
- [ ] ef core方式访问  
    + db first
    + code first
    + In-Memory Database Provider 方式单元测试
    + 实际连接Mysql、MSSQLSERVER情况下数据关系映射
### (十)一些简单中间件的使用
- [ ] 系统中内置的常用中间件介绍
    + 异常/错误处理Exception：UseDeveloperExceptionPage，UseDatabaseErrorPage，UseExceptionHandler
    + 严格传输安全协议:UseHttps
    + HTTPS重定向：UseHttpsRedirection
    + Cookie策略实施：UseCookiePolicy
    + 身份验证：UseAuthentication
    + 重写一个中间件
### (十一)Http无状态认证鉴权实现
- [ ] 对于Http无状态认证常用方式
    + Cookie
    + TOKEN
        + JWT方式
        + HTTP BASE Authentication方式
- [ ] 第三方认证后本地服务如何使用状态管理
    + Claims based security 
### (十二)依赖包管理
- [ ] 项目中用私有包管理器好处
- [ ] 搭建私有NuGet包管理服务器
- [ ] VS中通过项目配置文件方式配置NuGet包
- [ ] 命令行方式操作一个NuGet配置与推送到远程服务器中
- [ ] 手动发布到私有包管理服务器
- [ ] 在VS中配置发布到包到私有包管理服务器
### (十三)搭建一个简单的前后端应用示例
### (十四)使用docker工具打包.NET Core应用程序
### (十五)使用K8s部署.NET Core应用程序
### (十六)使用Service fabric进行分布式应用管理
- [ ] 在windows 10下快速搭建Service fabric开发环境
    + 安装包方式
    + PowerShell脚本命令方式
- [x] [多台云服务器中搭建安全Service Fabric运行环境](https://github.com/service-fabric/ServiceFabricPractices/blob/master/%E5%88%9B%E5%BB%BA%E4%BD%BF%E7%94%A8X509%E8%AF%81%E4%B9%A6%E4%BF%9D%E6%8A%A4%E7%9A%84%20Service%20Fabric%20%E5%AE%89%E5%85%A8%E7%BE%A4%E9%9B%86(On%20Premises).md)
- [ ] 部署示例程序到Service fabric环境中
- [ ] 命令方式进行对系统扩容与收缩
- [ ] 在自运行系统中的代码里进行系统扩容与收缩
- [ ] 手动故障点测试
### (十四)如何在Jenkins中进行CI/CD
- [ ] 把目标应用程序通过Jenkins打包成docker包然后部署到k8s中
- [ ] 把目标应用程序通过Jenkins发布到Service fabric中
### 一些示例脚本
- [ ] Service fabric生产环境的部署安装脚本
