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
            List<ContactData> newContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            oldContacts.RemoveAt(position);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void AllContactsRemoval()
        {
            applicationManager.ContactHelper.RemoveAllContacts();
        }
    }
}
