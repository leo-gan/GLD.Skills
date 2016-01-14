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
                    nodeMatrix[nodeX][nodeY] = nodeMatrix[nodeY][nodeX] = 6;
                }
                var nodes = CreateNodeArray(numberOfNodes);
                var startNodeId = Convert.ToInt64(Console.ReadLine()) - 1;
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

        private static string Test(IReadOnlyList<int[]> nodeMatrix, Node[] nodes, List<int> unlinkedNodes) {
            while (HasUnvisitedNodes(nodes, unlinkedNodes)) {
                var curNodeId = NodeIdWithMinDistance(nodes);
                for (var i = 0; i < nodes.Length; i++) {
                    if (curNodeId == i) continue; // neighbor for itself
                    if (nodes[i].IsVisited) continue;
                    if (nodeMatrix[curNodeId][i] == 0) continue; // startId
                    if (nodes[i].Distance > nodes[curNodeId].Distance + nodeMatrix[curNodeId][i])
                        nodes[i].Distance = nodes[curNodeId].Distance + nodeMatrix[curNodeId][i];
                }
                nodes[curNodeId].IsVisited = true;
            }
            return GetResult(nodes);
        }

        private static int NodeIdWithMinDistance(IReadOnlyList<Node> nodes) {
            var firstId = true;
            var nodeIdWithMinDistance = 0;
            foreach (var node in nodes.Where(node => !node.IsVisited)) {
                if (firstId) {
                    nodeIdWithMinDistance = node.Id;
                    firstId = false;
                    continue;
                }
                if (node.Distance >= nodes[nodeIdWithMinDistance].Distance) continue;
                nodeIdWithMinDistance = node.Id;
            }
            return nodeIdWithMinDistance;
        }

        private static string GetResult(IEnumerable<Node> nodes) {
            var result = nodes.Where(node => node.Distance != 0)
                .Aggregate<Node, string>(null,
                    (current, node) => current + ((node.Distance == int.MaxValue || node.Distance < 0 ? -1 : node.Distance) + " "));
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
            //    for (var y = 0; y < numberOfNodes; y++)
            //        distanceMatrix[x][y] = 0;
            }
            return distanceMatrix;
        }
    }
}