using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTestCase : AuthTestBase
    {    
        [Test]
        public void GroupRemovalTest()
        {
            int pos = 1;

            applicationManager.GroupHelper.Remove(pos);                     
        }
    }
}
