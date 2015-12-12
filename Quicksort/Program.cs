using System;
using System.Linq;

internal class Solution {

    static int  _swapCounter;
    /// <summary>
    /// </summary>
    /// <param name="ar"></param>
    /// <param name="startIndex"></param>
    /// <param name="stopIndex"></param>
    /// <returns>It returns the pivot index which can be changed.</returns>
    private void quickSort(int[] ar, int startIndex, int stopIndex) {
        //  1. partitioning:
        var pivotIndex = stopIndex;
        var lastRewritten = startIndex;
        for (var current = startIndex; current < stopIndex; current++) {
            if (ar[current] > ar[pivotIndex]) break;
            lastRewritten++;
        }
        for (var current = lastRewritten; current < stopIndex; current++) {
            if (ar[current] <= ar[pivotIndex])
                Swap(ar, lastRewritten++, current);
        }
        Swap(ar, lastRewritten, pivotIndex);
        Print(ar);

        pivotIndex = lastRewritten;
        //  2. sort for left part
        if (pivotIndex - startIndex > 1)
            quickSort(ar, startIndex, pivotIndex-1);

        //  3. sort for right part
        if (stopIndex - pivotIndex > 0)
            quickSort(ar, pivotIndex, stopIndex);
    }

    /// <summary>
    /// </summary>
    /// <param name="ar"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>It returns the left index.</returns>
    private static void Swap(int[] ar, int left, int right) {
        if (left == right || ar[left] == ar[right]) return;
        var temp = ar[left];
        ar[left] = ar[right];
        ar[right] = temp;
        _swapCounter++;
    }

    private static void Print(int[] ar) {
        if (_swapCounter == 0) return;
        string result = ar.Aggregate("", (current, t) => current + (t + " "));
        // result = ar.Aggregate("", (aggr, t) => aggr + t + " ");
        Console.WriteLine(result.Trim());
        _swapCounter = 0;
    }

/* Tail starts here */

    private static void Main(string[] args) {
        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        var _ar = new int[_ar_size];
        var elements = Console.ReadLine();
        var split_elements = elements.Split(' ');
        for (var _ar_i = 0; _ar_i < _ar_size; _ar_i++) {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }
        var solution = new Solution();
        solution.
        quickSort(_ar, 0, _ar.Length - 1);
    }
}