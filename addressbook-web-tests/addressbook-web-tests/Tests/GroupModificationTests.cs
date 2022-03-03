using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModifcationTestCase : BaseTest
    {
        [Test]
        public void GroupModification()
        {
            int selectedGroup = 1;
            GroupData modified_friends = new GroupData(null);

            modified_friends.Header = null;
            modified_friends.Footer = "xxx";

            applicationManager.GroupHelper.ModifyGroup(selectedGroup, modified_friends);
        }

    }
}
