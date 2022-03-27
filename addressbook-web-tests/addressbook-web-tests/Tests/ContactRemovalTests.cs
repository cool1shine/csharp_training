using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTestCase : AuthTestBase
    {
        [Test]
        public void ContactRemoval()
        {
            int position = 2;

            CreatePreconditionForContactTest(position);
            List<ContactData> oldContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            applicationManager.ContactHelper.RemoveContact(position);
            Assert.AreEqual(oldContacts.Count - 1, applicationManager.ContactHelper.GetContactCount());
            List<ContactData> newContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            oldContacts.RemoveAt(position);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void AllContactsRemoval()
        {
            CreatePreconditionForContactTest(0);
            applicationManager.ContactHelper.RemoveAllContacts();
            Assert.AreEqual(0, applicationManager.ContactHelper.GetContactCount());
        }
    }
}
