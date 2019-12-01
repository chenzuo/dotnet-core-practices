### ASP.NET Core Identity Series – Getting Started 
ASP.NET Core Identity is Microsoft’s membership system widely known to .NET developers for managing application users. And by managing we mean everything that has to do with a user account such as creating one, login functionality (cookies, tokens, Multi-Factor Authentication, etc..), resetting passwords, using external login providers or even providing access to certain resources. This membership system has always been quite easy to be used and plugged in a .NET application providing easy access to extremely useful helper methods around authentication that would be a pain in the ass to implement ourselves. Moreover, developers have highly associated it with Entity Framework and a specific SQL Schema used to support all the membership functionality. On the other hand, because of the fact that the library is so easy to be used without having any expertise on Identity and Security, developers many times find it difficult to extend it or customize its default behavior and fit their application needs. This can only be done only if there is deep knowledge on how the library works behind the scenes on its **kernel** and this is what we are gonna see on this post.

More specifically we will study the ASP.NET Core Identity library’s core components and the way they are architected and coupled together to provide the basic **user management** features. Through the ASP.NET Core Identity blog post series, we will be building step by step an ASP.NET Core Web application and explaining Identity features as we add them. Before start building the application though we need to learn the basics in theory.   
>The source code for the series is available [here](https://github.com/chsakell/aspnet-core-identity/). Each part will have a related branch on the repository. You can either follow along with the tutorial or simply clone the repository. In case you choose the latter make sure you checkout the **getting-started** branch as follow: 
```sh
git clone https://github.com/chsakell/aspnet-core-identity
cd .\aspnet-core-identity
git fetch
git checkout getting-started
```

This post is the first part of the **ASP.NET Core Identity Series**:
+ [x]Part 1: [Getting Started](https://chsakell.com/2018/04/28/asp-net-core-identity-series-getting-started/)  
+ Part 2: [Integrate Entity Framework](https://chsakell.com/2018/05/11/asp-net-core-identity-series-integrating-entity-framework/)  
+ Part 3: [Deep Dive in authorization](https://chsakell.com/2018/06/13/asp-net-core-identity-series-deep-dive-in-authorization/)  
+ Part 4: [OAuth 2.0, OpenID Connect & IdentityServer](https://chsakell.com/2019/03/11/asp-net-core-identity-series-oauth-2-0-openid-connect-identityserver/)  
+ Part 5: [External Provider authentication & registration strategy](https://chsakell.com/2019/07/28/asp-net-core-identity-series-external-provider-authentication-registration-strategy/)  
+ Part 6: [Two-Factor Authentication](https://chsakell.com/2019/08/18/asp-net-core-identity-series-two-factor-authentication/)  

#### ASP.NET Core Identity Basics
