using System;
using System.Collections.Generic;
using System.Linq;

namespace FullCountingSort {
    internal class Program {
        private static void Main(string[] args) {
            var recordNumber = Convert.ToInt32(Console.ReadLine());

            var recordInt = new int[recordNumber];
            var recordString = new string[recordNumber];
            var recordPositions = new List<int>[100];
            for (var i = 0; i < recordNumber; i++) {
                var recordAsStringArr = Console.ReadLine().Split(' ');
                recordInt[i] = Convert.ToInt32(recordAsStringArr[0]);
                recordString[i] = i < recordNumber/2 ? "-" : recordAsStringArr[1];
                if (recordPositions[recordInt[i]] == null) recordPositions[recordInt[i]] = new List<int>();
                recordPositions[recordInt[i]].Add(i);
            }

            foreach (var recordPosition in recordPositions.Where(recordPositionList => recordPositionList != null).SelectMany(recordPositionList => recordPositionList)) {
                Console.Write( recordString[recordPosition] + " ");
            }
        }
    }
}