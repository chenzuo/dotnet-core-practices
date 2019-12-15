#### ASP.NET Core Identity Series – Integrating Entity Framework 
<font color=#069>Microsoft.Extensions.Identity.Core</font> is the minimum ASP.NET Core Identity package you need to install in order to get start working with the core functionality of the library. We have seen how to do this in the [Getting Started](./asp-net-core-identity-series-getting-started.md) part of these ASP.NET Core Identity Series blog posts. As a quick reminder, what we did on the first part is implement and register a custom IUserStore along with a custom user entity to be used by the library’s managers. User entities were quite simple and saved at an in-memory store.  

```c#
// User Entity
public class AppUser
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string NormalizeUserName { get; set; }
    public string PasswordHash { get; set; }
}
 
// Implement a custom IUserStore
public class AppUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser></AppUser>
 
// register services at Startup
services.AddIdentityCore<AppUser>(options => { });
services.AddScoped<IUserStore<AppUser>, AppUserStore>();
```  
