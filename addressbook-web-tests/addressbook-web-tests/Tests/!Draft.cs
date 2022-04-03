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
            string str = "abvc";
            str = str + "earg";
            Console.Out.WriteLine($"{str}");
        }
    }
}
