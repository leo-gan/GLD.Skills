using System;

namespace Greedy.AlgorithmicCrush {
    internal class Program {
        private static void Main(string[] args) {
            var line = Console.ReadLine().Split(' ');
            var arraySize = Convert.ToInt32(line[0]);
            var opNumber = Convert.ToInt32(line[1]);

            var array = new long[arraySize];
            var spikes = new long[arraySize];
                // it keeps the spikes (for minId == maxID), where values goes up and dowm on a single index

            for (var op = 0; op < opNumber; op++) {
                line = Console.ReadLine().Split(' ');
                var minId = Convert.ToInt32(line[0]) - 1;
                var maxId = Convert.ToInt32(line[1]) - 1;
                if (minId > maxId) {
                    var temp = minId;
                    minId = maxId;
                    maxId = temp;
                }
                var additive = Convert.ToInt64(line[2]);
                array[minId] += additive;
                array[maxId] -= additive;
                if (minId == maxId) spikes[maxId] = additive;
            }
            long max = 0, sum = 0;
            for (var i = 0; i < arraySize; i++) {
                sum += array[i];
                if (max < sum) max = sum;
                if (spikes[i] == 0) continue;
                if (max < sum + spikes[i]) max = sum + spikes[i];
            }
            Console.WriteLine(max);
        }
    }
}