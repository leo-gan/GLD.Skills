using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraSortestReach2 {
    internal class Node {
        public Node(int id) {
            Id = id;
            Distance = int.MaxValue;
            IsVisited = false;
        }

        public int Id { get; set; }
        public int Distance { get; set; }
        public bool IsVisited { get; set; }
    }

    internal class Program {
        private static void Main(string[] args) {
            var numberOfTests = Convert.ToInt32(Console.ReadLine());

            var results = new List<string>();

            for (var test = 0; test < numberOfTests; test++) {
                var firstLine = Console.ReadLine().Split(' ');
                var numberOfNodes = Convert.ToInt32(firstLine[0]);
                var numberOfEdges = Convert.ToInt32(firstLine[1]);
                var nodeMatrix = CreateDistanceMatrix(numberOfNodes);
                for (var i = 0; i < numberOfEdges; i++) {
                    var line = Console.ReadLine().Split(' ');
                    var nodeX = Convert.ToInt32(line[0]) - 1;
                    var nodeY = Convert.ToInt32(line[1]) - 1;
                    nodeMatrix[nodeX][nodeY] = nodeMatrix[nodeY][nodeX] = Convert.ToInt32(line[2]);
                }
                var nodes = CreateNodeArray(numberOfNodes);
                var startNodeId = Convert.ToInt32(Console.ReadLine()) - 1;
                nodes[startNodeId].Distance = 0;

                var unlinkedNodes = CreateUnlinkedNodes(numberOfNodes, nodeMatrix);

                results.Add(Test(nodeMatrix, nodes, unlinkedNodes));
            }

            foreach (var result in results) {
                Console.WriteLine(result);
            }
        }

        private static List<int> CreateUnlinkedNodes(int numberOfNodes, int[][] nodeMatrix) {
            var unlinkedNodes = new List<int>();
            for (var x = 0; x < numberOfNodes; x++) {
                var numberOfLinks = 0;
                for (var y = 0; y < numberOfNodes; y++) {
                    if (y == x) continue;
                    if (nodeMatrix[x][y] != 0) numberOfLinks++;
                }
                if (numberOfLinks == 0) unlinkedNodes.Add(x);
            }
            return unlinkedNodes;
        }

        private static Node[] CreateNodeArray(int numberOfNodes) {
            var nodes = new Node[numberOfNodes];
            for (var index = 0; index < nodes.Length; index++)
                nodes[index] = new Node(index);
            return nodes;
        }

        private static string Test(IReadOnlyList<int[]> nodeMatrix, IReadOnlyList<Node> nodes, List<int> unlinkedNodes) {
            while (HasUnvisitedNodes(nodes, unlinkedNodes)) {
                // picks the unvisited vertex with the lowest-distance,
                var nodeIdWithMinDistance = 0;
                nodeIdWithMinDistance = NodeIdWithMinDistance(nodes, nodeIdWithMinDistance);
                //calculates the distance through it to each unvisited neighbor, 
                for (var i = 0; i < nodes.Count; i++) {
                    if (nodeIdWithMinDistance == i) continue; // neighbor for itself
                    if (nodes[i].IsVisited) continue;
                    if (nodeMatrix[nodeIdWithMinDistance][i] == 0) continue;
                    if (nodes[i].Distance > nodes[nodeIdWithMinDistance].Distance + nodeMatrix[nodeIdWithMinDistance][i]) 
                        nodes[i].Distance = nodes[nodeIdWithMinDistance].Distance + nodeMatrix[nodeIdWithMinDistance][i];
                    //and updates the neighbor's distance if smaller. 
                    //if (nodes[i].Distance <= minDistance || nodes[i].Distance == 0)
                    //    nodes[i].Distance += nodeMatrix[nodeIdWithMinDistance][i];
                }
                //Mark visited (set to red) when done with neighbors.
                nodes[nodeIdWithMinDistance].IsVisited = true;
            }
            return GetResult(nodes);
        }

        private static int NodeIdWithMinDistance(IReadOnlyList<Node> nodes, int nodeIdWithMinDistance) {
            var firstId = true;
            var minDistance = int.MaxValue;
            foreach (var node in nodes.Where(node => !node.IsVisited)) {
                if (firstId) {
                    nodeIdWithMinDistance = node.Id;
                    minDistance = node.Distance;
                    firstId = false;
                }
                if (node.Distance >= minDistance) continue;
                nodeIdWithMinDistance = node.Id;
                minDistance = node.Distance;
           }
            return nodeIdWithMinDistance;
        }

        private static string GetResult(IEnumerable<Node> nodes) {
            var result = nodes.Where(node => node.Distance != 0).Aggregate<Node, string>(null, (current, node) => current + ((node.Distance == int.MaxValue ? -1 : node.Distance) + " "));
            return result.Trim();
        }

        private static bool HasUnvisitedNodes(IEnumerable<Node> nodes, List<int> unlinkedNodes) {
            foreach (var node in nodes) {
                if (node.IsVisited) continue;
                var skippedUnlinked = unlinkedNodes.Any(unlinkedNode => node.Id == unlinkedNode);
                if (!skippedUnlinked) return true;
            }
            return false;
        }

        private static int[][] CreateDistanceMatrix(int numberOfNodes) {
            var distanceMatrix = new int[numberOfNodes][];
            int x;
            for (x = 0; x < numberOfNodes; x++) {
                distanceMatrix[x] = new int[numberOfNodes];
                for (var y = 0; y < numberOfNodes; y++)
                    distanceMatrix[x][y] = 0;
            }
            return distanceMatrix;
        }
    }
}