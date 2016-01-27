using System;

namespace SherlokAndMovingTiles {
    internal class Solution {
        private static void Main(string[] args) {
            var line = Console.ReadLine().Split(' ');
            var L = Convert.ToDouble(line[0]);
            var S1 = Convert.ToDouble(line[1]);
            var S2 = Convert.ToDouble(line[2]);
            var tests = Convert.ToInt32(Console.ReadLine());
            var results = new double[tests];
            for (var test = 0; test < tests; test++) {
                var q = Convert.ToDouble(Console.ReadLine());
                results[test] =
                    Math.Sqrt(2.0)
                    *(L - Math.Sqrt(q))
                    /Math.Abs(S1 - S2)
                ;
            }

            for (var test = 0; test < tests; test++) {
                Console.WriteLine(results[test]);
            }
        }
    }
}