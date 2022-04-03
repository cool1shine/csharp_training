using NUnit.Framework;
using System;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTestCase : AuthTestBase
    {

        [Test]
        public void ContactInformation()
        {
            int index;

            ContactData fullFilledContact = new ContactData("Contact", "FullyFilled")
            {
                Address = "TestingDrive123",
                Email = "mimimi@mimimi.com",
                Email2 = "ase@rg.kr",
                Email3 = "jiow@efkn.fu",
                Home = "+ 7 (999) 888 12 - 34",
                Mobile = "+ 123 8 7 9 8 888 75 - 65",
                Work = "+ 62 (274) 786 9922",
            };

            if (ThereIsFullFilledContact() == false)
            {
                CreatePreconditionForContactTest(fullFilledContact);
            }

            index = applicationManager.ContactHelper.FindIndexOfFullFilledContact();     

            ContactData fromTable = applicationManager.ContactHelper.GetContactInformationFromTable(index);
            ContactData fromForm = applicationManager.ContactHelper.GetContactInformationFromEditForm(index);

            //Verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Emails, fromForm.Emails);
            Assert.AreEqual(fromTable.Phones, fromForm.Phones);
        }
    }
}