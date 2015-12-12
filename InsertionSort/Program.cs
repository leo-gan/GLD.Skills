using System;
using System.Linq;

internal class Solution {
    private static void insertionSort(int[] ar) {
        for (var i = 1; i < ar.Length; i++) {
            insertionSortCycle(ar, i);
        }
    }

    private static void insertionSortCycle(int[] ar, int testedItemIndex) {
        var e = ar[testedItemIndex];
        for (var i = testedItemIndex - 1; i >= 0 && e < ar[i]; i--) {
            ar[i + 1] = ar[i];
            ar[i] = e;
        }
        Print(ar);
    }

    private static void Print(int[] ar) {
        var result = ar.Aggregate<int, string>(null, (current, item) => current + (item + " "));
        Console.WriteLine(result.Trim());
    }

    private static void Main(string[] args) {
        var arrSize = Convert.ToInt32(Console.ReadLine());
        var ar = new int[arrSize];
        var elements = Console.ReadLine();
        if (elements != null) {
            var splitElements = elements.Split(' ');
            for (var i = 0; i < arrSize; i++)
                ar[i] = Convert.ToInt32(splitElements[i]);
        }

        insertionSort(ar);
    }
}