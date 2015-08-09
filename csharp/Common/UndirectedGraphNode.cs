using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LocalLeet
{
    public class UndirectedGraphNode
    {
        public int Label;
        public IList<UndirectedGraphNode> Neighbors;

        public UndirectedGraphNode(int x)
        {
            Label = x;
            Neighbors = new List<UndirectedGraphNode>();
        }

        // We use # as a separator for each node, and , as a separator for node label and each neighbor of the node.
        // As an example, consider the serialized graph {0,1,2#1,2#2,2}.
        public static UndirectedGraphNode FromString(string s)
        {
            string[] tokens = s.TrimEnd('}').TrimStart('{')
                .Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (tokens.Length == 0)
            {
                return null;
            }
            List<int[]> nodeDataArray = tokens.Select(t =>
                t.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray())
                .ToList();
            var dict = new Dictionary<int, UndirectedGraphNode>();
            // 1st pass, build every node
            nodeDataArray.ForEach(nodeData => {
                UndirectedGraphNode node = new UndirectedGraphNode(nodeData[0]);
                dict[nodeData[0]] = node;
            });
            // 2nd pass, connect node
            nodeDataArray.ForEach(nodeData => {
                UndirectedGraphNode node = dict[nodeData[0]];
                for (int i = 1; i < nodeData.Length; i++)
                {
                    node.Neighbors.Add(dict[nodeData[i]]);
                    if (node != dict[nodeData[i]])
                    {
                        dict[nodeData[i]].Neighbors.Add(node);
                    }
                }
            });

            return dict[nodeDataArray[0][0]];
        }

        public static string Serialize(UndirectedGraphNode node)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            Dictionary<int, string> dict = new Dictionary<int, string>();
            InternalSerialize(node, dict);
            sb.Append(String.Join("#", dict.Keys.OrderBy(i => i).Select(k => dict[k])));
            sb.Append("}");
            return sb.ToString();
        }

        private static void InternalSerialize(UndirectedGraphNode node, Dictionary<int, string> dict)
        {
            if (node == null || dict.ContainsKey(node.Label))
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(node.Label);
            foreach (var neighbor in node.Neighbors)
            {
                if (neighbor.Label >= node.Label)
                {
                    sb.Append(",");
                    sb.Append(neighbor.Label);
                }
            }
            dict[node.Label] = sb.ToString();
            foreach (var neighbor in node.Neighbors)
            {
                InternalSerialize(neighbor, dict);
            }
        }
    }
}
