using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class BaseTest
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupTest()
        {
            applicationManager = new ApplicationManager();
        }

        [TearDown]
        public void TearDownTest()
        {
            applicationManager.StopTest();
        }
        
    }
}
