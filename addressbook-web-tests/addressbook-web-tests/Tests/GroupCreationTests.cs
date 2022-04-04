using System;
using System.IO;
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

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromFile")]
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
