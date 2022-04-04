using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTestCase : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> groups = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(15))
                {
                    Address = GenerateRandomString(60),
                    Email = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30),
                    Home = GenerateRandomString(30),
                    Mobile = GenerateRandomString(30),
                    Work = GenerateRandomString(30),
                });
            }
            ContactData group = new ContactData();
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]

        public void ContactCreation(ContactData group)
        {            
            List<ContactData> oldContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            applicationManager.ContactHelper.CreateNewContact(group);
            Assert.AreEqual(oldContacts.Count + 1, applicationManager.ContactHelper.GetContactCount());
            List<ContactData> newContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            oldContacts.Add(group);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        //[Test]
        //public void EmptyContactCreation()
        //{
        //    ContactData contact = new ContactData("", "");

        //    List<ContactData> oldContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
        //    applicationManager.ContactHelper.CreateNewContact(contact);
        //    Assert.AreEqual(oldContacts.Count + 1, applicationManager.ContactHelper.GetContactCount());
        //    List<ContactData> newContacts = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
        //    oldContacts.Add(contact);
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);
        //}
    }
}
