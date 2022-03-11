﻿using NUnit.Framework;

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
                                   
            applicationManager.GroupHelper.CreateGroup(friends);
        }

        [Test]
        public void EmptyGroupCreation()
        {
            GroupData friends = new GroupData("");
            applicationManager.GroupHelper.CreateGroup(friends);
        }
    }
}
