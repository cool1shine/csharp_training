using System;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTestCase : AuthTestBase
    {

        [Test]
        public void ContactInfoFromEditForm()
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

        [Test]
        public void ContactInfoFromViewForm()
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
            Console.Out.WriteLine($"{index}");
            ContactData fromTable = applicationManager.ContactHelper.GetContactInformationFromTable(index);
            string fromView = applicationManager.ContactHelper.GetStringFromViewForm(index);

            //Verification
            Assert.AreEqual(fromTable.ViewForm, fromView);
        }
    }
}