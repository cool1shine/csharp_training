using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupApplicationManager()
        {
            applicationManager = ApplicationManager.GetInstance();
        }
    }
}
