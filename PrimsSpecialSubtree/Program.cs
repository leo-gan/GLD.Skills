﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimsSpecialSubtree {
    internal class Node {
        public Node(int id) {
            Id = id;
            Distance = int.MaxValue;
            IsVisited = false;
            MinDistanceNeigbourId = 0;
        }

        public int Id { get; set; }
        public long Distance { get; set; }
        public bool IsVisited { get; set; }
        public int MinDistanceNeigbourId { get; set; }
    }

    internal class Program {
        private static void Main(string[] args) {
                var firstLine = Console.ReadLine().Split(' ');
                var numberOfNodes = Convert.ToInt32(firstLine[0]);
                var numberOfEdges = Convert.ToInt32(firstLine[1]);
                var nodeMatrix = CreateDistanceMatrix(numberOfNodes);
                for (var i = 0; i < numberOfEdges; i++) {
                    var line = Console.ReadLine().Split(' ');
                    var nodeX = Convert.ToInt32(line[0]) - 1;
                    var nodeY = Convert.ToInt32(line[1]) - 1;
                    var edgeDistance = Convert.ToInt64(line[2]);
                    if (nodeMatrix[nodeX][nodeY] == 0 || nodeMatrix[nodeX][nodeY] > edgeDistance)
                    nodeMatrix[nodeX][nodeY] = nodeMatrix[nodeY][nodeX] = edgeDistance; // store only an edge with min distance (for edges between the same nodes)
                }
                var nodes = CreateNodeArray(numberOfNodes);
                var startNodeId = Convert.ToInt64(Console.ReadLine()) - 1;
                nodes[startNodeId].Distance = 0;

                var unlinkedNodes = CreateUnlinkedNodes(numberOfNodes, nodeMatrix);

                Console.WriteLine(Test(nodeMatrix, nodes, unlinkedNodes));
        }

        private static List<int> CreateUnlinkedNodes(int numberOfNodes, List<long[]> nodeMatrix) {
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

        private static long Test(List<long[]> nodeMatrix, Node[] nodes, List<int> unlinkedNodes) {
            while (HasUnvisitedNodes(nodes, unlinkedNodes)) {
                var curNodeId = NodeIdWithMinDistance(nodes);
                for (var i = 0; i < nodes.Length; i++) {
                    if (curNodeId == i) continue; // neighbor for itself
                    if (nodes[i].IsVisited) continue;
                    if (nodeMatrix[curNodeId][i] == 0) continue; // startId
                    if (nodes[i].Distance <= nodes[curNodeId].Distance + nodeMatrix[curNodeId][i]) continue;
                    nodes[i].Distance = nodes[curNodeId].Distance + nodeMatrix[curNodeId][i];
                    nodes[i].MinDistanceNeigbourId = curNodeId;
                }
                nodes[curNodeId].IsVisited = true;
            }

            LeaveOnlyMinDistanceEdges(nodeMatrix, nodes);
            return GetResult(nodeMatrix);
        }

        private static void LeaveOnlyMinDistanceEdges(List<long[]> nodeMatrix, Node[] nodes) {
            foreach (Node node in nodes) {
                if (node.Distance == 0)  // startNode
                    for (int y = 0; y < nodes.Length; y++)
                        nodeMatrix[node.Id][y] = 0; // clean up all  distances
                for (int y = 0; y < nodes.Length; y++) {
                    if (node.MinDistanceNeigbourId == y) continue; // leave only minDistanceNeigbours
                    nodeMatrix[node.Id][y] = 0; // clean up all other distances
                }
            }
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

        private static long GetResult(List<long[]> nodeMatrix) {
            long result = 0;
            for (var x = 0; x < nodeMatrix[0].Length; x++)
                result += nodeMatrix.Select((t, y) => nodeMatrix[x][y]).Sum();
            return result;
        }

        private static bool HasUnvisitedNodes(IEnumerable<Node> nodes, List<int> unlinkedNodes) {
            foreach (var node in nodes) {
                if (node.IsVisited) continue;
                var skippedUnlinked = unlinkedNodes.Any(unlinkedNode => node.Id == unlinkedNode);
                if (!skippedUnlinked) return true;
            }
            return false;
        }

        private static List<long[]> CreateDistanceMatrix(int numberOfNodes) {
            var distanceMatrix = new List<long[]>();
            for (var x = 0; x < numberOfNodes; x++)
                distanceMatrix.Add(new long[numberOfNodes]);
            return distanceMatrix;
        }
    }
}