using System;

namespace CountingSort2 {
    internal class Program {
        private static void Main(string[] args) {
            Convert.ToInt32(Console.ReadLine());
            var stringItems = Console.ReadLine().Split(' ');
            var counters = new int[100];
            foreach (var stingItem in stringItems)
                counters[Convert.ToInt32(stingItem)]++;

            string result = null;
            for (var index = 0; index < counters.Length; index++)
                for (var i = 0; i < counters[index]; i++)
                    Console.Write(index + " ");
        }
    }
}