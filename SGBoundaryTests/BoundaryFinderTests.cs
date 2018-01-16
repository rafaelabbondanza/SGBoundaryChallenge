using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGBoundaryChallenge;

namespace SGBoundaryTests
{
    [TestClass]
    public class BoundaryFinderTests
    {
        [TestMethod]
        public void TestBlobCase()
        {
            string input =
                  "0000000000\n"
                + "0011100000\n"
                + "0011111000\n"
                + "0010001000\n"
                + "0011111000\n"
                + "0000101000\n"
                + "0000101000\n"
                + "0000111000\n"
                + "0000000000\n"
                + "0000000000\n";

            bool[,] blob = Util.InputToMatrix(input);

            BoundaryFinder finder = new BoundaryFinder();
            Boundaries boundaries = finder.FindBoundaries(blob, 10);

            Assert.AreEqual(2, boundaries.Left);
            Assert.AreEqual(1, boundaries.Top);
            Assert.AreEqual(6, boundaries.Right);
            Assert.AreEqual(7, boundaries.Bottom);
        }

        [TestMethod]
        public void TestEmptyCase()
        {
            string input =
                  "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n"
                + "0000000000\n";

            bool[,] blob = Util.InputToMatrix(input);

            BoundaryFinder finder = new BoundaryFinder();
            Boundaries boundaries = finder.FindBoundaries(blob, 10);

            Assert.AreEqual(-1, boundaries.Left);
            Assert.AreEqual(-1, boundaries.Right);
            Assert.AreEqual(-1, boundaries.Bottom);
            Assert.AreEqual(-1, boundaries.Top);
            Assert.AreEqual(100, boundaries.CellReads);

        }

        [TestMethod]
        public void TestFullCase()
        {
            string input =
                  "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n"
                + "1111111111\n";

            bool[,] blob = Util.InputToMatrix(input);

            BoundaryFinder finder = new BoundaryFinder();
            Boundaries boundaries = finder.FindBoundaries(blob, 10);

            Assert.AreEqual(0, boundaries.Left);
            Assert.AreEqual(9, boundaries.Right);
            Assert.AreEqual(9, boundaries.Bottom);
            Assert.AreEqual(0, boundaries.Top);
            Assert.AreEqual(100, boundaries.CellReads);
        }

        [TestMethod]
        public void TestSmallCase()
        {
            string input = "01\n00\n";

            bool[,] blob = Util.InputToMatrix(input);

            BoundaryFinder finder = new BoundaryFinder();
            Boundaries boundaries = finder.FindBoundaries(blob, 2);

            Assert.AreEqual(1, boundaries.Left);
            Assert.AreEqual(1, boundaries.Right);
            Assert.AreEqual(0, boundaries.Bottom);
            Assert.AreEqual(0, boundaries.Top);
        }

        [TestMethod]
        public void TestTinyCase()
        {
            string input = "1\n";

            bool[,] blob = Util.InputToMatrix(input);

            BoundaryFinder finder = new BoundaryFinder();
            Boundaries boundaries = finder.FindBoundaries(blob, 1);

            Assert.AreEqual(0, boundaries.Left);
            Assert.AreEqual(0, boundaries.Top);
            Assert.AreEqual(0, boundaries.Right);
            Assert.AreEqual(0, boundaries.Bottom);
            Assert.AreEqual(1, boundaries.CellReads);
        }

        [TestMethod]
        public void TestVertLineCase()
        {
            string input =
                  "010\n"
                + "010\n"
                + "010";

            bool[,] blob = Util.InputToMatrix(input);

            BoundaryFinder finder = new BoundaryFinder();
            Boundaries boundaries = finder.FindBoundaries(blob, 3);

            Assert.AreEqual(1, boundaries.Left);
            Assert.AreEqual(0, boundaries.Top);
            Assert.AreEqual(1, boundaries.Right);
            Assert.AreEqual(2, boundaries.Bottom);
        }
    }
}
