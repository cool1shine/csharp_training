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
            GroupData modified_friends = new GroupData("modified_bastards");

            modified_friends.Header = "smoke";
            modified_friends.Footer = "a lot";

            applicationManager.GroupHelper.ModifyGroup(selectedGroup, modified_friends);
        }

    }
}
