using System;
using System.Collections.Generic;

namespace SGBoundaryChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string case1 =
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

            string empty =
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

            string full =
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

            List<string> cases = new List<string> { case1, empty, full };

            foreach(string input in cases)
            {
                Console.Write(input);

                bool[,] blob = Util.InputToMatrix(input);

                BoundaryFinder finder = new BoundaryFinder();
                Boundaries boundaries = finder.FindBoundaries(blob, 10);

                Console.WriteLine($"Top: {boundaries.Top}");
                Console.WriteLine($"Left: {boundaries.Left}");
                Console.WriteLine($"Bottom: {boundaries.Bottom}");
                Console.WriteLine($"Right: {boundaries.Right}");
                Console.WriteLine($"Reads: {boundaries.CellReads}");

            }

            Console.ReadLine();
        }
    }
}
