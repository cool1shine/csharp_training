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

            navigationHelper.OpenHomePage();
            loginHelper.Login(admin);
            navigationHelper.GoToGroupsPage();
            groupHelper.CreateNewGroup();
            groupHelper.FillGroupForm(friends);
            groupHelper.SubmitGroupCreation();
            navigationHelper.GoToGroupsPage();
            loginHelper.Logout();
        }
    }
}
