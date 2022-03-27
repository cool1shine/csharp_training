using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginValidCredentials()
        {
            AccountData user = new AccountData("admin", "secret");
            applicationManager.LoginHelper.Login(user);
            Assert.IsTrue(applicationManager.LoginHelper.IsLoggedIn(user));
        }

        [Test]
        public void LoginInvalidCredentials()
        {
            AccountData user = new AccountData("admin", "ыускуе");
            applicationManager.LoginHelper.Logout();
            applicationManager.LoginHelper.Login(user);
            Assert.IsFalse(applicationManager.LoginHelper.IsLoggedIn(user));
        }
    }
}
