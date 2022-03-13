using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModifcationTestCase : AuthTestBase
    {
        [Test]
        public void GroupModification()
        {
            int selectedGroup = 0;
            GroupData modified_friends = new GroupData("I'm modified!");

            modified_friends.Header = null;
            modified_friends.Footer = null;

            CreatePreconditionForGroupTest(selectedGroup);
            applicationManager.GroupHelper.ModifyGroup(selectedGroup, modified_friends);
        }

    }
}
