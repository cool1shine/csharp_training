using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Addressbook_web_tests
{
    [TestClass]
    public class Draft
    {
        [TestMethod]
        public void ConsoleOut()
        {
            int n = 7;
            Console.Out.WriteLine($"{n}");
        }
    }
}
