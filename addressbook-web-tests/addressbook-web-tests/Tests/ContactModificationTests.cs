using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTestCase : AuthTestBase
    {
        [Test]
        public void ContactModification()
        {
            int position = 1;
            ContactData modifiedContact = new ContactData("Vika_mod", "Chika_mod");
            modifiedContact.Email = "mail@imail.malili";

            CreatePreconditionForContactTest(position);
            List<ContactData> beforeMod = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            applicationManager.ContactHelper.ModifyContact(position, modifiedContact);
            List<ContactData> afterMod = new List<ContactData>(applicationManager.ContactHelper.GetContactList());
            beforeMod[position] = modifiedContact;
            beforeMod.Sort();
            afterMod.Sort();
            Assert.AreEqual(beforeMod, afterMod);
        }
    }
}
