using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTestCase : BaseTest
    {        
        [Test]
        public void ContactCreation()
        {            
            ContactData contact = new ContactData("Vika", "Chika");

            applicationManager.ContactHelper.CreateNewContact(contact);
                       
        }
    }
}
