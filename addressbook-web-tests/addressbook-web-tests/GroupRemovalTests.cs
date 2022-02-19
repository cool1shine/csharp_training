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

            OpenHomePage();
            Login(admin);
            GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            GoToGroupsPage();
            Logout();
        }
    }
}
