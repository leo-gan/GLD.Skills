using System;
using System.Linq;

internal class Solution {
    private static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        var words = new string[_ar_size];
        for (var i = 0; i < _ar_size; i++) {
            words[i] = Console.ReadLine();
            words[i] = Sort(words[i]);
        }
        for (var i = 0; i < _ar_size; i++) {
            Console.WriteLine(words[i]);
        }
    }

    private static string Sort(string word) {
        // convert to char[]
        var arr = word.ToCharArray();
        var intArr = new int[arr.Length];
        for (var index = 0; index < arr.Length; index++) {
            intArr[index] = Convert.ToInt32(arr[index]);
        }

        var counter = 0;
        for (var index = 1; index < arr.Length; index++) {
            if (intArr[index - 1] == intArr[index]) counter++;
            if (counter == arr.Length - 1) return "no answer";
        }
        // sort
        Array.Sort(intArr);
        Array.Reverse(intArr);

        // convert back to string
        return intArr.Aggregate("", (current, t) => current + Convert.ToChar(t).ToString());
    }
}