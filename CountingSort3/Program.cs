using System;

namespace CountingSort2 {
    internal class Program {
        private static void Main(string[] args) {
            var records = Convert.ToInt32(Console.ReadLine());
            var indice = new int[records]; 
            var values = new string[records];
            var counters = new int[100];
            for (var i = 0; i < records; i++) {
                var stringItems = Console.ReadLine().Split(' ');
                indice[i] = Convert.ToInt32(stringItems[0]);
                values[i] = stringItems[1];
                counters[indice[i]]++;
            }

            var cummulativeSum = 0;
            foreach (var indexCounter in counters) {
                cummulativeSum += indexCounter;
                Console.Write(cummulativeSum + " ");
            }
        }
    }
}