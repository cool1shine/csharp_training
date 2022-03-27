using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTestCase : AuthTestBase
    {    
        [Test]
        public void GroupRemovalTest()
        {
            int pos = 0;

            CreatePreconditionForGroupTest(pos);
            List<GroupData> oldGroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.Remove(pos);
            Assert.AreEqual(oldGroups.Count - 1, applicationManager.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            oldGroups.RemoveAt(pos);
            Assert.AreEqual(oldGroups, newGroups);
            return;
        }

        [Test]
        public void AllGroupsRemovalTest()
        {
            int pos = 0;

            CreatePreconditionForGroupTest(0);
            pos = applicationManager.GroupHelper.GetGroupCount() - 1;
            while (pos >= 0)
            {
                applicationManager.GroupHelper.Remove(pos);
                pos--;
            }
            Assert.AreEqual(0, applicationManager.GroupHelper.GetGroupCount());
            return;
        }
    }
}
