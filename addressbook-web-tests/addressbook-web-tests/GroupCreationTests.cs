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

            OpenHomePage();
            Login(admin);
            GoToGroupsPage();
            CreateNewGroup();
            FillGroupForm(friends);
            SubmitGroupCreation();
            GoToGroupsPage();
            Logout();
        }
    }
}
