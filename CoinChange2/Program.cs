using System;
using System.Collections.Generic;

namespace CoinChange2 {
    internal class Program {
        private static void Main(string[] args) {
            var myArgs = Console.ReadLine().Trim().Split(' ');
            var _desiredSum = Convert.ToInt64(myArgs[0]);
            var coinTypeNumber = Convert.ToInt64(myArgs[1]);
            var coinTypeStrings = Console.ReadLine().Trim().Split(' ');
            coinTypeNumber = coinTypeStrings.Length;
            var _coinTypes = new int[coinTypeNumber];
            for (var i = 0; i < coinTypeNumber; i++)
                _coinTypes[i] = Convert.ToInt32(coinTypeStrings[i]);
            Array.Sort(_coinTypes);
            int _matches;
            var _coinSet = new List<int>();

            Process();
            Console.WriteLine(_matches);
        }
    }
}