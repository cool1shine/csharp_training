using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class BaseTest
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupTest()
        {
            AccountData user = new AccountData("admin", "secret");
            applicationManager = new ApplicationManager();
            applicationManager.NavigationHelper.OpenHomePage();
            applicationManager.LoginHelper.Login(user);
        }

        [TearDown]
        public void TearDownTest()
        {
            applicationManager.LoginHelper.Logout();
            applicationManager.StopTest();
        }
        
    }
}
