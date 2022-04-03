using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class SearchTestCase : AuthTestBase
    {
        [Test]
        public void NumberOfResultsByStringFromContact()
        {
            int index = 2;
            string request = "t";
            int numberOfResults;
            int numberOfContactsOnPage;

            CreatePreconditionForContactTest(index);

            applicationManager.ContactHelper.EnterStringToSearchField(request);
            numberOfResults = applicationManager.ContactHelper.GetNumberOfResults();
            numberOfContactsOnPage = applicationManager.ContactHelper.GetNumberOfVisibleContacts();
            Assert.AreEqual(numberOfContactsOnPage, numberOfResults);
        }
    }
}
