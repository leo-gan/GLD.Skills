using System;
using System.Collections.Generic;

namespace Search.SherlockAndArray {
    internal class Program {
        private static int _curMiddleIndex;
        private static long _leftSum;
        private static long _rightSum;
        private static int[] _intItems;

        private static void Main(string[] args) {
            var tests = Convert.ToInt32(Console.ReadLine());
            var results = new List<bool>();

            for (var i = 0; i < tests; i++) {
                var itemNumber = Convert.ToInt32(Console.ReadLine());
                var items = Console.ReadLine().Split(' ');
                _intItems = new int[items.Length];
                for (var j = 0; j < _intItems.Length; j++)
                    _intItems[j] = Convert.ToInt32(items[j]);
                _curMiddleIndex = _intItems.Length/2;
                _leftSum = 0;
                _rightSum = 0;

                results.Add(Test(0, _intItems.Length - 1));
            }
            foreach (var result in results) {
                Console.WriteLine(result ? "YES" : "NO");
            }
        }

        private static bool Test(int leftIndex, int rightIndex) {
            if (rightIndex - leftIndex < 2) return false;
            if (_intItems.Length == 1) return true;
            // take a middle of array:
            var _curMiddleIndex = leftIndex + (rightIndex + 1 - leftIndex)/2;
            // calculate left total
            var leftSum = 0;
            for (var i = leftIndex; i < _curMiddleIndex; i++)
                leftSum += _intItems[i];
            // calculate right total
            var rightSum = 0;
            for (var i = _curMiddleIndex + 1; i < rightIndex + 1; i++)
                rightSum += _intItems[i];
            // if LT == RT return true;
            if (_leftSum + leftSum == _rightSum + rightSum)
                return true;
            if (_leftSum + leftSum < _rightSum + rightSum) {
                _leftSum += leftSum;
                return Test(_curMiddleIndex, rightIndex);
            }
            _rightSum += rightSum;
            return Test(leftIndex, _curMiddleIndex);
        }
    }
}