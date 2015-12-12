using System;

namespace CountingSort2 {
    internal class Program {
        private static void Main(string[] args) {
            int records = Convert.ToInt32(Console.ReadLine());
            int[] indice = new int[records]; 
            string[] values = new string[records];
            var counters = new int[100];
            for (int i = 0; i < records; i++) {
                var stringItems = Console.ReadLine().Split(' ');
                indice[i] = Convert.ToInt32(stringItems[0]);
                values[i] = stringItems[1];
                counters[indice[i]]++;
            }

            int cummulativeSum = 0;
            for (var index = 0; index < counters.Length; index++) {
                cummulativeSum += counters[index];
                Console.Write(cummulativeSum + " ");
            }
        }
    }
}