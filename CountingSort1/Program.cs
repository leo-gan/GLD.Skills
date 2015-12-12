using System;
using System.Linq;

internal class Solution {
    private static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Convert.ToInt32(Console.ReadLine());
        var stringItems = Console.ReadLine().Split(' ');
        var counters = new int[100];
        foreach (var stingItem in stringItems)
            counters[Convert.ToInt32(stingItem)]++;

        var result = counters.Aggregate<int, string>(null, (current, t) => current + (t + " "));

        Console.WriteLine(result.Trim());
    }
}