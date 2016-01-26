using System;

namespace SherlokAndMovingTiles {
    internal class Program {
        private static void Main(string[] args) {
            var line = Console.ReadLine().Split(' ');
            double L = Convert.ToInt64(line[0]);
            double S1 = Convert.ToInt64(line[1]);
            double S2 = Convert.ToInt64(line[2]);
            var tests = Convert.ToInt32(Console.ReadLine());
            for (var test = 0; test < tests; test++) {
                double q = Convert.ToInt32(Console.ReadLine());
                if (S1 == S2) 
                    Console.WriteLine("Infinity");
                else
                    Console.WriteLine(
                        Math.Sqrt(2)
                        *(L - Math.Sqrt(q))
                        /Math.Abs(S1 - S2)
                        );
            }
        }
    }
}