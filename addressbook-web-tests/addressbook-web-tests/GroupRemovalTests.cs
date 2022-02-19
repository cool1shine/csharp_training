using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTestCase : BaseTest
    {    
        [Test]
        public void GroupRemovalTest()
        {
            AccountData admin = new AccountData("admin", "secret");

            navigationHelper.OpenHomePage();
            loginHelper.Login(admin);
            navigationHelper.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            navigationHelper.GoToGroupsPage();
            loginHelper.Logout();
        }
    }
}
