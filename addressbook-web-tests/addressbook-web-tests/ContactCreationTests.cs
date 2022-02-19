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

            navigationHelper.OpenHomePage();
            loginHelper.Login(admin);
            contactHelper.AddNewContact(contact);
            contactHelper.FillContactData(contact);
            contactHelper.SubmitContactCreation();
            navigationHelper.GoToHomePage();
            loginHelper.Logout();
        }
    }
}
