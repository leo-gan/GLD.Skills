using System;

class Solution {
    private static int QuicksortSwapCounter;
    private static int InsertShiftCounter;

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
            InsertShiftCounter++;
        }
    }

    private void quickSort(int[] ar, int startIndex, int stopIndex) {
        //  1. partitioning:
        var pivotIndex = stopIndex;
        var lastRewritten = startIndex;
        for (var current = startIndex; current < stopIndex; current++) {
            if (ar[current] <= ar[pivotIndex])
                lastRewritten++;
            else break;
        }
        for (var current = lastRewritten; current < stopIndex; current++) {
            if (ar[current] <= ar[pivotIndex])
                Swap(ar, lastRewritten++, current);
        }
        Swap(ar, lastRewritten, pivotIndex);

        pivotIndex = lastRewritten;
        //  2. sort for left part
        if (pivotIndex - startIndex > 1)
            quickSort(ar, startIndex, pivotIndex - 1);

        //  3. sort for right part
        if (stopIndex - pivotIndex > 0)
            quickSort(ar, pivotIndex, stopIndex);
    }

    private static void Swap(int[] ar, int left, int right) {
        if (left == right || ar[left] == ar[right]) return;
        var temp = ar[left];
        ar[left] = ar[right];
        ar[right] = temp;
        QuicksortSwapCounter++;
    }

    static void Main(string[] args) {
        var arSize = Convert.ToInt32(Console.ReadLine());
        var quickSortArr = new int[arSize];
        var elements = Console.ReadLine();
        var splitElements = elements.Split(' ');
        for (var i = 0; i < arSize; i++)
            quickSortArr[i] = Convert.ToInt32(splitElements[i]);
        var insertArr = new int[arSize];
        quickSortArr.CopyTo(insertArr, 0);

        var solution = new Solution();
        solution.quickSort(quickSortArr, 0, quickSortArr.Length - 1);
        insertionSort(insertArr);
        Console.WriteLine(InsertShiftCounter - QuicksortSwapCounter);
    }
}