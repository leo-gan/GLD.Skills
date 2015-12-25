using System;
using System.Collections.Generic;

namespace SortestReach {
    internal class Program {
        private static void Main(string[] args) {
            var testNumber = Convert.ToInt32(Console.ReadLine());
            var numberOfNodes = new int[testNumber];
            var numberOfEdges = new int[testNumber];
            var adjacencyList = new List<int>[testNumber][];
            var startNode = new int[testNumber];

            for (var test = 0; test < testNumber; test++) {
                var firstLine = Console.ReadLine().Split(' ');
                numberOfNodes[test] = Convert.ToInt32(firstLine[0]);
                numberOfEdges[test] = Convert.ToInt32(firstLine[1]);
                //var nodeMatrix = new int[numberOfNodes, numberOfNodes];
                adjacencyList[test] = new List<int>[numberOfNodes[test]];
                for (var i = 0; i < numberOfEdges[test]; i++) {
                    var line = Console.ReadLine().Split(' ');
                    var nodeX = Convert.ToInt32(line[0]) - 1;
                    var nodeY = Convert.ToInt32(line[1]) - 1;
                    //nodeMatrix[nodeX, nodeY] = 1;
                    if (adjacencyList[test][nodeX] == null) adjacencyList[test][nodeX] = new List<int>();
                    adjacencyList[test][nodeX].Add(nodeY);
                }
                startNode[test] = Convert.ToInt32(Console.ReadLine()) - 1;
            }

            for (var test = 0; test < testNumber; test++)
                Test(numberOfNodes[test], numberOfEdges[test], adjacencyList[test], startNode[test]);
        }

        private static void Test(int numberOfNodes, int numberOfEdges, List<int>[] adjacencyList, int startNode) {
            
        }
    }
}