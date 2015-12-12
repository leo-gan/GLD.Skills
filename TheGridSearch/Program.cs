using System;
using System.IO;

internal class Solution {
    private static void Main(string[] args) {
        var rows = File.ReadAllLines(args[0]);
        var t = Convert.ToInt32(rows[0]);
        for (var a0 = 0; a0 < t; a0++) {
            var tokens_R = rows[1].Split(' ');
            var R = Convert.ToInt32(tokens_R[0]);
            var C = Convert.ToInt32(tokens_R[1]);
            var G = new string[R];
            for (var G_i = 0; G_i < R; G_i++)
                G[G_i] = rows[G_i + 2];
            var tokens_r = rows[2 + R].Split(' ');
            var r = Convert.ToInt32(tokens_r[0]);
            var c = Convert.ToInt32(tokens_r[1]);
            var P = new string[r];
            for (var P_i = 0; P_i < r; P_i++)
                P[P_i] = rows[2 + R + 1 + P_i];
            var isFound = false;
            for (var w = 0; w < R - r; w++) {
                for (var k = 0; k < C - c; k++) {
                    if (!IsGridFound(G, P, k, w)) continue;
                    isFound = true;
                    break;
                }
                if (isFound) break;
            }
            Console.WriteLine(isFound ? "YES" : "NO");
        }
    }

    private static bool IsGridFound(string[] data, string[] pattern, int leftStartColumn, int topStartRow) {
        var patternColumns = pattern[0].Length;
        var patternRows = pattern.Length;
        // loop on rows
        for (var row = 0; row < patternRows; row++)
            // apply search on a row
            if (data[topStartRow + row].Substring(leftStartColumn, patternColumns) != pattern[row])
                return false;
        return true;
    }
}