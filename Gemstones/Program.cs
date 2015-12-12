using System;
using System.Linq;

internal class Solution {
    private static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var rockNumber = Convert.ToInt32(Console.ReadLine());
        var rocks = new string[rockNumber];
        for (var rockIndex = 0; rockIndex < rockNumber; rockIndex++) {
            rocks[rockIndex] = Console.ReadLine();
        }

        // remove equal chars from the first rock string: "aabbccccd" -> "abcd"
        var firstRockChars = rocks[0].ToCharArray();
        var reducedString = firstRockChars[0].ToString(); // start from the first char
        for (var curRockCharIndex = 1; curRockCharIndex < firstRockChars.Length; curRockCharIndex++) {
            var testedChar = firstRockChars[curRockCharIndex];
            var isCharRepeated = false;
            for (var nextCharIndex = 0; nextCharIndex < curRockCharIndex; nextCharIndex++) {
                if (testedChar != firstRockChars[nextCharIndex]) continue;
                isCharRepeated = true;
                break;
            }
            if (!isCharRepeated) reducedString += testedChar;
        }
        //Console.WriteLine(reducedString); // debug
        firstRockChars = reducedString.ToCharArray();

        // take first rock and compare its chars with other rock chars
        var gems = new int[firstRockChars.Length];
        for (var firstRockCharIndex = 0; firstRockCharIndex < firstRockChars.Length; firstRockCharIndex++) {
            gems[firstRockCharIndex] = 0;
            for (var rockIndex = 1; rockIndex < rockNumber; rockIndex++) {
                var curRockChars = rocks[rockIndex].ToCharArray();
                if (curRockChars.Any(t => firstRockChars[firstRockCharIndex] == t))
                    gems[firstRockCharIndex]++;
            }
        }
        var gemNumber = gems.Count(t => t == rockNumber - 1);

        Console.WriteLine(gemNumber);
    }
}