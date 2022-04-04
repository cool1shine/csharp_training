using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{   
    
    [TestFixture]
    public class GroupCreationTestCase : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                });
            }
            GroupData group = new GroupData();
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreation(GroupData group)
        {
            List<GroupData> oldGroups = applicationManager.GroupHelper.GetGroupList();
            applicationManager.GroupHelper.CreateGroup(group);
            Assert.AreEqual(oldGroups.Count + 1, applicationManager.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = applicationManager.GroupHelper.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
