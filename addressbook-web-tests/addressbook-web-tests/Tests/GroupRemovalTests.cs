﻿using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTestCase : AuthTestBase
    {    
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.GroupHelper.Remove(1);                     
        }
    }
}
