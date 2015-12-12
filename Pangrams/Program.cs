using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var testString = File.ReadAllText(args[0]).ToUpper();
        var retVal = "Pangram";
        for ( var i = 65; i <= 90; i++)
            //if (NotFound(testString, Convert.ToChar(i))) retVal = "Not Pangram";
            if (!testString.Contains( Convert.ToString(Convert.ToChar(i)))) retVal = "Not Pangram";
        Console.WriteLine(retVal);
    }
}