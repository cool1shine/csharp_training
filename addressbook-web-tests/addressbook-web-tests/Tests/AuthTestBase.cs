using NUnit.Framework;

namespace Addressbook_web_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        protected void SetupLogin()
        {
            AccountData user = new AccountData("admin", "secret");
            applicationManager.LoginHelper.Login(user);
        }

        protected void CreatePreconditionForGroupTest(int pos)
        {
            if (applicationManager.GroupHelper.IsSelectedGroupPresented(pos) == false)
            {
                while (applicationManager.GroupHelper.IsSelectedGroupPresented(pos) == false)
                {
                    GroupData groupTest = new GroupData("Group test");
                    applicationManager.GroupHelper.CreateGroup(groupTest);
                }
            }
        }

        protected void CreatePreconditionForContactTest(int pos)
        {
            if (applicationManager.ContactHelper.IsSelectedContactPresented(pos) == false)
            {
                while (applicationManager.ContactHelper.IsSelectedContactPresented(pos) == false)
                {
                    ContactData contactTest = new ContactData("Test", "Contact");
                    applicationManager.ContactHelper.CreateNewContact(contactTest);
                }
            }
        }

        protected void CreatePreconditionForContactTest(ContactData newContact)
        {
            applicationManager.ContactHelper.CreateNewContact(newContact);
        }

        protected bool ThereIsFullFilledContact()
        {
            return applicationManager.ContactHelper.ICanFindFullFilledContact();
        }
    }
}
