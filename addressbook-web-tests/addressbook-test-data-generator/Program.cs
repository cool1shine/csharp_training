using System;
using System.IO;
using Addressbook_web_tests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                string rnd01 = TestBase.GenerateRandomString(10);
                string rnd02 = TestBase.GenerateRandomString(10);
                string rnd03 = TestBase.GenerateRandomString(10);
                writer.WriteLine(String.Format("${0},${1},${2}", rnd01, rnd02, rnd03));
                Console.WriteLine(String.Format("${0},${1},${2}", rnd01, rnd02, rnd03));
            }
        }
    }
}
