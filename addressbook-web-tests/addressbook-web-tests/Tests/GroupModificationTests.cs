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
            GroupData groupToBeMod = oldGroups[selectedGroup];
            applicationManager.GroupHelper.ModifyGroup(selectedGroup, modified_friends);
            Assert.AreEqual(oldGroups.Count, applicationManager.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            oldGroups[selectedGroup].Groupname = modified_friends.Groupname;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == groupToBeMod.Id)
                {
                    Assert.AreEqual("I am modified!", group.Groupname);
                }
            }
        }
    }
}