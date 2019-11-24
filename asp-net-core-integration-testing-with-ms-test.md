创建单元测试步骤
1、Create New Project-> xUnit Test Project(.Net Core)  
2、Right click new project->Edit .csproj->Change TargetFramework to net47  
3、Add Project Reference to TestRepro  
4、Install-Package Microsoft.AspNetCore.Mvc.Testing  

Add Test file like below   
```c#
public class BasicTests
: IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public BasicTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task TestMethod1()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/values");
    }

}
``` 
6、Run Test Project  