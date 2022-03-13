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
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            oldGroups.RemoveAt(pos);
            Assert.AreEqual(oldGroups, newGroups);
            return;
        }
    }
}
