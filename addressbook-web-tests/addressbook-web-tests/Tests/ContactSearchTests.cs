using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactSearchTestCase : AuthTestBase
    {
        [Test]
        public void NumberOfResultsByStringFromContact()
        {
            int pre = 2;
            string request = "eh";
            int numberOfResults;
            int numberOfContactsOnPage;

            CreatePreconditionForContactTest(pre);

            applicationManager.ContactHelper.EnterStringToSearchField(request);
            numberOfResults = applicationManager.ContactHelper.GetNumberOfResults();
            numberOfContactsOnPage = applicationManager.ContactHelper.GetNumberOfVisibleContacts();
            Assert.AreEqual(numberOfContactsOnPage, numberOfResults);
        }
    }
}
