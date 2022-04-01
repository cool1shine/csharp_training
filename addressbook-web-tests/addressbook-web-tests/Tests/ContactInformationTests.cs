using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTestCase : AuthTestBase
    {
        [Test]
        public void ContactInformation()
        {
            int index = 0;

            CreatePreconditionForContactTest(index);
            ContactData fromTable = applicationManager.ContactHelper.GetContactInformationFromTable(index);
            ContactData fromForm = applicationManager.ContactHelper.GetContactInformationFromEditForm(index);

            //Verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Phones, fromForm.Phones);
        }
    }
}