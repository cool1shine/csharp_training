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

            applicationManager.ContactHelper.CreateNewContact(contact);
                       
        }

        [Test]
        public void EmptyContactCreation()
        {
            ContactData contact = new ContactData("", "");

            applicationManager.ContactHelper.CreateNewContact(contact);

        }
    }
}
