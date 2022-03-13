using System.Collections.Generic;
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
            GroupData modified_friends = new GroupData("I am modified!");

            modified_friends.Header = null;
            modified_friends.Footer = null;

            CreatePreconditionForGroupTest(selectedGroup);
            List<GroupData> oldGroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.ModifyGroup(selectedGroup, modified_friends);
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            oldGroups[selectedGroup].Groupname = modified_friends.Groupname;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
