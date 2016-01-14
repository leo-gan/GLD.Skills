using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UtopianTree
{
    class Program
    {
        static void Main(string[] args) {
            var tests = Convert.ToInt32(Console.ReadLine());
            var results = "";
            for (int test = 0; test < tests; test++) {
                var cycles = Convert.ToInt32(Console.ReadLine());
                results += TreeHigh(cycles) + Environment.NewLine;
            }
            Console.WriteLine(results);
        }

        private static string TreeHigh(int cycles) {
            long high = 1;
            for (var cycle = 0; cycle < cycles; cycle++)
                if (cycle%2 == 1)
                    high += 1;
                else
                    high *= 2;
            return high.ToString();
        }
    }
}
