using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Addressbook_web_tests
{
    [TestClass]
    public class AssertsPractice
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(3);
            Square s2 = new Square(7);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 3);
            Assert.AreEqual(s2.Size, 7);
            Assert.AreEqual(s3.Size, 3);

            s3.Size = 256;
            Assert.AreEqual(s1.Size, 256);
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle c1 = new Circle(3);
            Circle c2 = new Circle(7);
            Circle c3 = c1;

            Assert.AreEqual(c1.Size, 3);
            Assert.AreEqual(c2.Size, 7);
            Assert.AreEqual(c3.Size, 3);

            c3.Size = 256;
            Assert.AreEqual(c1.Size, 256);
        }

        [TestMethod]
        public void TestMethodIsColored()
        {
            Square s2 = new Square(77);
            Circle c2 = new Circle(88);

            s2.IsColored = true;
            c2.IsColored = true;

            Assert.AreEqual(s2.IsColored, c2.IsColored);
        }

    }
}
