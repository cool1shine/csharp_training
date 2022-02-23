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
            ContactData contact = new ContactData("Vika", "Chika");

            applicationManager.NavigationHelper.OpenHomePage();
            applicationManager.LoginHelper.Login(admin);
            applicationManager.ContactHelper.AddNewContact(contact);
            applicationManager.ContactHelper.FillContactData(contact);
            applicationManager.ContactHelper.SubmitContactCreation();
            applicationManager.NavigationHelper.GoToHomePage();
            applicationManager.LoginHelper.Logout();
        }
    }
}
