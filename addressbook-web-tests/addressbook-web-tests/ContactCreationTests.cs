using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTestCase : BaseTest
    {        
        [Test]
        public void ContactCreation()
        {
            AccountData admin = new AccountData("admin", "secret");
            ContactData contact = new ContactData("Olya", "Chika");

            OpenHomePage();
            Login(admin);
            AddNewContact(contact);
            FillContactData(contact);
            SubmitContactCreation();
            GoToHomePage();
            Logout();
        }
    }
}
