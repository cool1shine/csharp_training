using System;
using System.Text;
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

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int n = 0; n <  l; n++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
