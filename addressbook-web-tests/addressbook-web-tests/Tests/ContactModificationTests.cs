using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTestCase : AuthTestBase
    {
        [Test]
        public void ContactModification()
        {
            int position = 2;
            ContactData modifiedContact = new ContactData("Vika_mod", "Chika_mod");
           
            applicationManager.ContactHelper.ModifyContact(position, modifiedContact);
        }
    }
}
