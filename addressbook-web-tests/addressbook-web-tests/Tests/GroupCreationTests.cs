using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTestCase : BaseTest
    {
        [Test]
        public void GroupCreation()
        {
            GroupData friends = new GroupData("bastards");

            friends.Header = "drink";
            friends.Footer = "vodka";
                                   
            applicationManager.GroupHelper.CreateGroup(friends);
        }

        [Test]
        public void EmptyGroupCreation()
        {
            GroupData friends = new GroupData("");

            friends.Header = "";
            friends.Footer = ""; 

            applicationManager.GroupHelper.CreateGroup(friends);
        }
    }
}
