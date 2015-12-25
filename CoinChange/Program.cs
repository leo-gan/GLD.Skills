using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChange {

    /// <summary>
    /// A Test: 
    /*
    166 23
     5 37 8 39 33 17 22 32 13 7 10 35 40 2 43 49 46 19 41 1 12 11 28 
     */
    /// Result: 96190959
    /// </summary>
    internal class Program {
        private static int _matches;
        private static readonly List<int> _coinSet = new List<int>();
        private static int[] _coinTypes;
        private static Int64 _desiredSum;

        private static void Main(string[] args) {
            var myArgs = Console.ReadLine().Trim().Split(' ');
            _desiredSum = Convert.ToInt64(myArgs[0]);
            var coinTypeNumber = Convert.ToInt64(myArgs[1]);
            var coinTypeStrings = Console.ReadLine().Trim().Split(' ');
            coinTypeNumber = coinTypeStrings.Length;
            _coinTypes = new int[coinTypeNumber];
            for (var i = 0; i < coinTypeNumber; i++)
                _coinTypes[i] = Convert.ToInt32(coinTypeStrings[i]);
            Array.Sort(_coinTypes);

            _coinSet.Add(_coinTypes[coinTypeNumber - 1]); // max cointType
            Process();
            Console.WriteLine(_matches);
        }

        private static void Process() {
            var sum = _coinSet.Sum();

            if (sum >= _desiredSum) {
                if (sum == _desiredSum) _matches++;
                if (!SwapLast()) return;
            }
            else {
                //AddLast();
                var curCoin = _coinSet[_coinSet.Count - 1];
                while(_coinSet.Sum() + curCoin <= _desiredSum)
                    _coinSet.Add(curCoin);

            }
            Process();
        }

        private static bool SwapLast() {
            // if last coin is min
            if (_coinSet[_coinSet.Count - 1] == _coinTypes[0]) {
                //      remove all tail min coins
                var tailCoin = _coinSet[_coinSet.Count - 1];
                for (var i = _coinSet.Count - 1; i >= 0; i--) {
                    if (_coinSet[i] != tailCoin) break;
                    _coinSet.RemoveAt(i);
                }
                //      if the last is min, return false
                if (_coinSet.Count == 0 && tailCoin == _coinTypes[0])
                    return false;
                //      take the last coin and replace it by the next smaller
                ReplaceLastBySmaller();
            }
            else
                ReplaceLastBySmaller();

            return true;
        }

        private static void ReplaceLastBySmaller() {
            var tailCoin = _coinSet[_coinSet.Count - 1];
            var tailCoinIndex = 0;
            for (; tailCoinIndex < _coinTypes.Length - 1; tailCoinIndex++) {
                if (_coinTypes[tailCoinIndex] == tailCoin) break;
            }
            if (tailCoinIndex - 1 < 0) throw new Exception("It should never happen!");
            _coinSet.RemoveAt(_coinSet.Count - 1);
            _coinSet.Add(_coinTypes[tailCoinIndex - 1]);
        }


        private static void AddLast() {
            if (_coinSet.Count == 0)
                throw new Exception("It should never happen!");
            _coinSet.Add(_coinSet[_coinSet.Count - 1]);
        }
    }
}