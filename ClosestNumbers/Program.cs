using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestNumbers {
    class Program {
        static void Main(string[] args) {
            var arraySize = Convert.ToInt32(Console.ReadLine());
            var stringItems = Console.ReadLine().Split(' ');

            var sortedSet = new SortedSet<int>();
            foreach (var item in stringItems)
                sortedSet.Add(Convert.ToInt32(item));
            var array = sortedSet.ToArray();
            var min = sortedSet.Max;
            var minPairs = new List<Element>();
            for (var i = 1; i < array.Length; i++) {
                var curMin = Math.Abs(array[i - 1] - array[i]);
                if (curMin == min) 
                    minPairs.Add(new Element(array[i - 1], array[i]));
                if (curMin < min) {
                    minPairs.Clear();
                    minPairs.Add(new Element(array[i - 1], array[i]));
                    min = curMin;
                }
            }
            foreach (var pair in minPairs)
                Console.Write(pair.Left + " " + pair.Right + " " +
                              "");
        }
    }

    internal class Element {
        public int Left;
        public int Right;

        public Element(int left, int right) {
            Left = left;
            Right = right;
        }
    }
}
