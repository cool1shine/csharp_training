using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTestCase : AuthTestBase
    {        
        [Test]
        public void ContactCreation()
        {            
            ContactData contact = new ContactData("Vika", "Chika");
            contact.Company = "GGG";
            List<ContactData> oldContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            applicationManager.ContactHelper.CreateNewContact(contact);
            List<ContactData> newContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreation()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            applicationManager.ContactHelper.CreateNewContact(contact);
            List<ContactData> newContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
