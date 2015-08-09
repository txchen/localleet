using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.
//
// OJ's undirected graph serialization:
// Nodes are labeled uniquely.
//
// We use # as a separator for each node, and , as a separator for node label and each neighbor of the node.
// As an example, consider the serialized graph {0,1,2#1,2#2,2}.
//
// The graph has a total of three nodes, and therefore contains three parts as separated by #.
//
// First node is labeled as 0. Connect node 0 to both nodes 1 and 2.
// Second node is labeled as 1. Connect node 1 to node 2.
// Third node is labeled as 2. Connect node 2 to node 2 (itself), thus forming a self-cycle.
// Visually, the graph looks like the following:
//
//        1
//       / \
//      /   \
//     0 --- 2
//          / \
//          \_/

/**
 * Definition for undirected graph.
 * public class UndirectedGraphNode {
 *     public int Label;
 *     public IList<UndirectedGraphNode> Neighbors;
 *     public UndirectedGraphNode(int x) { Label = x; Neighbors = new List<UndirectedGraphNode>(); }
 * };
 */

// https://leetcode.com/problems/clone-graph/
namespace LocalLeet
{
    public class Q133
    {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) {
                return null;
            }
            var dict = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();
            var result = new UndirectedGraphNode(node.Label);
            dict.Add(node, result);
            Queue<UndirectedGraphNode> q = new Queue<UndirectedGraphNode>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                var toClone = q.Dequeue();
                var clonedNode = dict[toClone];
                foreach (var neighbor in toClone.Neighbors)
                {
                    if (!dict.ContainsKey(neighbor))
                    {
                        dict.Add(neighbor, new UndirectedGraphNode(neighbor.Label));
                        q.Enqueue(neighbor);
                    }
                    clonedNode.Neighbors.Add(dict[neighbor]);
                }
            }
            return result;
        }

        [Fact]
        public void Q133_CloneGraph()
        {
            TestHelper.Run(input => {
                var inputNode = input.EntireInput.ToUndirectedGraphNode();
                var outputNode = CloneGraph(inputNode);
                if (inputNode != null && object.Equals(inputNode, outputNode))
                {
                    return "Must create a new instance of node!";
                }
                return outputNode.SerializeUndirectedGraphNode();
            });
        }
    }
}
