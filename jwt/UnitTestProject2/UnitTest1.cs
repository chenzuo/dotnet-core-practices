using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication5.Infrastructure.Models.Vo;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            LoginRequestVo loginRequestVo = new LoginRequestVo()
            {
                IdentityId = "apy",
                Password = "163@163.com",
                UserName = "apyfc"
            };
            _testContext.WriteLine(WebApplication5.Infrastructure.Shared.JsonSerializer.SerializeObject(loginRequestVo));
        }
    }
}
