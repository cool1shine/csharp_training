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

            applicationManager.ContactHelper.RemoveContact(position);
        }

        [Test]
        public void AllContactsRemoval()
        {
            applicationManager.ContactHelper.RemoveAllContacts();
        }
    }
}
