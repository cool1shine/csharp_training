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


            applicationManager.NavigationHelper.OpenHomePage();
            applicationManager.LoginHelper.Login(admin);
            applicationManager.NavigationHelper.GoToGroupsPage();
            applicationManager.GroupHelper.SelectGroup(1);
            applicationManager.GroupHelper.RemoveGroup();
            applicationManager.NavigationHelper.GoToGroupsPage();
            applicationManager.LoginHelper.Logout();
        }
    }
}
