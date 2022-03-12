using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTestCase : AuthTestBase
    {
        [Test]
        public void GroupCreation()
        {
            GroupData friends = new GroupData("bastards");            

            friends.Header = "drink";
            friends.Footer = "vodka";

            List<GroupData> oldGroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.CreateGroup(friends);
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreation()
        {
            GroupData friends = new GroupData("");

            List<GroupData> oldGroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.CreateGroup(friends);
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreation()
        {
            GroupData friends = new GroupData("'");

            List<GroupData> oldGroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.CreateGroup(friends);
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
