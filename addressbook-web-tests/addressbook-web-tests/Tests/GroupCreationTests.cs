using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTestCase : BaseTest
    {
        [Test]
        public void GroupCreation()
        {
            AccountData admin = new AccountData("admin", "secret");
            GroupData friends = new GroupData("bastards");

            friends.Header = "drink";
            friends.Footer = "vodka";

            applicationManager.NavigationHelper.OpenHomePage();
            applicationManager.LoginHelper.Login(admin);
            applicationManager.NavigationHelper.GoToGroupsPage();
            applicationManager.GroupHelper.CreateNewGroup();
            applicationManager.GroupHelper.FillGroupForm(friends);
            applicationManager.GroupHelper.SubmitGroupCreation();
            applicationManager.NavigationHelper.GoToGroupsPage();
            applicationManager.LoginHelper.Logout();
        }
    }
}
