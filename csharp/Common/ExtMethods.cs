using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LocalLeet
{
    public static class Ext
    {
        public static string[] ToStringArray(this string s)
        {
            return JsonConvert.DeserializeObject<string[]>(s);
        }

        public static string[][] ToStringArrayArray(this string s)
        {
            return JsonConvert.DeserializeObject<string[][]>(s);
        }

        public static HashSet<string> ToStringHashSet(this string s)
        {
            var elements = JsonConvert.DeserializeObject<string[]>(s);
            return new HashSet<string>(elements);
        }

        public static int[] ToIntArray(this string s)
        {
            return JsonConvert.DeserializeObject<int[]>(s);
        }

        public static int[][] ToIntArrayArray(this string s)
        {
            return JsonConvert.DeserializeObject<int[][]>(s);
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        public static double ToDouble(this string s)
        {
            return double.Parse(s);
        }

        // e.g. {3,1,#,2,#,#,4}
        public static BinaryTree ToBinaryTree(this string s)
        {
            string[] tokens = s.TrimEnd('}').TrimStart('{')
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (tokens.Length == 0)
            {
                return null;
            }
            BinaryTree root;
            root = tokens[0] == "#" ? null : new BinaryTree(int.Parse(tokens[0]));
            Queue<BinaryTree> q = new Queue<BinaryTree>();
            q.Enqueue(root);
            int index = 1;
            while (index < tokens.Length)
            {
                var t = q.Dequeue();
                if (tokens[index] != "#")
                {
                    t.Left = new BinaryTree(int.Parse(tokens[index]));
                    q.Enqueue(t.Left);
                }
                index++;
                if (index < tokens.Length && tokens[index] != "#")
                {
                    t.Right = new BinaryTree(int.Parse(tokens[index]));
                    q.Enqueue(t.Right);
                }
                index++;
            }
            return root;
        }

        // e.g. [5,3,1,null,4,null,null,2]
        public static BinaryTree ToBinaryTree2(this string s)
        {
            return s.Replace("[", "{").Replace("]", "}").Replace("null", "#").ToBinaryTree();
        }

        public static UndirectedGraphNode ToUndirectedGraphNode(this string s)
        {
            return UndirectedGraphNode.FromString(s);
        }

        public static RandomListNode ToRandomListNode(this string s)
        {
            return RandomListNode.FromString(s);
        }

        public static string SerializeString(this string s)
        {
            if (s == null)
            {
                return "null";
            }
            return "\"" + s + "\"";
        }

        public static string Deserialize(this string s)
        {
            return s.Substring(1, s.Length - 2);
        }

        public static ListNode<T> ToListNode<T>(this string s)
        {
            if (s.StartsWith("{") && s.EndsWith("}"))
            {
                s = s.Substring(1, s.Length - 2);
                if (String.IsNullOrEmpty(s))
                {
                    return null;
                }
                T[] tokens = s.Split(',').Select(t =>
                    (T)Convert.ChangeType(t, typeof(T))).ToArray();
                ListNode<T> head = new ListNode<T>(tokens[0]);
                ListNode<T> current = head;
                for (int i = 1; i < tokens.Length; i++)
                {
                    current.Next = new ListNode<T>(tokens[i]);
                    current = current.Next;
                }
                return head;
            }
            else
            {
                throw new Exception("input is not a valid listnode: " + s);
            }
        }

        public static ListNode<T> ToListNode2<T>(this string s)
        {
            return s.Replace("[", "{").Replace("]", "}").ToListNode<T>();
        }

        public static ListNode<T>[] ToListNodeArray<T>(this string s)
        {
            // e.g [{1,2,2},{1,1,2}]
            if (s.StartsWith("[") && s.EndsWith("]"))
            {
                s = s.TrimStart('[').TrimEnd(']');
                if (String.IsNullOrEmpty(s))
                {
                    return new ListNode<T>[0];
                }
                return s.Split(new[] { "}," }, StringSplitOptions.RemoveEmptyEntries).Select(t =>
                    {
                        if (!t.EndsWith("}"))
                        {
                            t += "}";
                        }
                        return t.ToListNode<T>();
                    }).ToArray();
            }
            else
            {
                throw new Exception("input is not a valid listnode array: " + s);
            }
        }

        public static string SerializeListNode<T>(this ListNode<T> l)
        {
            StringBuilder sb = new StringBuilder();
            while (l != null)
            {
                sb.Append(l.Val.ToString());
                sb.Append(",");
                l = l.Next;
            }
            return "{" + sb.ToString().TrimEnd(',') + "}";
        }

        public static string SerializeListNode2<T>(this ListNode<T> l)
        {
            return l.SerializeListNode<T>().Replace("{", "[").Replace("}", "]");
        }

        // e.g. {3,1,#,2,#,#,4}
        public static string SerializeBinaryTree(this BinaryTree root)
        {
            if (root == null)
            {
                return "{}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            Queue<BinaryTree> q = new Queue<BinaryTree>();
            q.Enqueue(root);
            while (true)
            {
                // dequeue and append to sb
                int qLength = q.Count;
                bool hasNewLayer = false;
                for (int i = 0; i < qLength; i++)
                {
                    BinaryTree tmp = q.Dequeue();
                    if (tmp != null)
                    {
                        q.Enqueue(tmp.Left);
                        q.Enqueue(tmp.Right);
                        hasNewLayer |= (tmp.Left != null);
                        hasNewLayer |= (tmp.Right != null);
                        sb.Append(tmp.Value.ToString() + ",");
                    }
                    else
                    {
                        sb.Append("#,");
                    }
                }
                if (!hasNewLayer)
                {
                    break;
                }
            }
            string result = sb.ToString();
            int lastIndex = result.LastIndexOfAny(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            return result.Substring(0, lastIndex + 1) + "}";
        }

        public static string SerializeUndirectedGraphNode(this UndirectedGraphNode node)
        {
            return UndirectedGraphNode.Serialize(node);
        }

        public static string SerializeRandomListNode(this RandomListNode node)
        {
            return RandomListNode.Serialize(node);
        }

        public static string SerializeTreeNodeWithNext(this TreeNodeWithNext root)
        {
            if (root == null)
            {
                return "{}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            var currentLevel = root;
            TreeNodeWithNext nextLevel = null;
            while (currentLevel != null)
            {
                while (currentLevel != null)
                {
                    if (nextLevel == null)
                    {
                        if (currentLevel.Left != null)
                        {
                            nextLevel = currentLevel.Left;
                        }
                        else if (currentLevel.Right != null)
                        {
                            nextLevel = currentLevel.Right;
                        }
                    }
                    sb.Append(currentLevel.Value + ",");
                    currentLevel = currentLevel.Next;
                }
                sb.Append("#,");
                currentLevel = nextLevel;
                nextLevel = null;
            }
            string result = sb.ToString();
            return result.TrimEnd(',') + "}";
        }

        public static TreeNodeWithNext ConvertToTreeNodeWithNext(this BinaryTree root)
        {
            if (root != null)
            {
                TreeNodeWithNext newRoot = new TreeNodeWithNext(root.Value);
                newRoot.Left = ConvertToTreeNodeWithNext(root.Left);
                newRoot.Right = ConvertToTreeNodeWithNext(root.Right);
                return newRoot;
            }
            return null;
        }

        public static string SerializeBinaryTreeArray(this BinaryTree[] trees)
        {
            if (trees == null)
            {
                return null;
            }
            if (trees.Length == 0)
            {
                return "[{}]";
            }
            return "[" + String.Join(",", trees.Select(t => SerializeBinaryTree(t))) + "]";
        }

        public static IEnumerable<BinaryTree> InOrderBinaryTree(this BinaryTree root)
        {
            if (root == null)
            {
                yield break;
            }
            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            stack.Push(root);
            while (root.Left != null)
            {
                stack.Push(root.Left);
                root = root.Left;
            }
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                yield return tmp;
                if (tmp.Right != null)
                {
                    stack.Push(tmp.Right);
                    tmp = tmp.Right;
                    while (tmp.Left != null)
                    {
                        stack.Push(tmp.Left);
                        tmp = tmp.Left;
                    }
                }
            }
        }

        public static IEnumerable<BinaryTree> InOrderBinaryTreeRightToLeft(this BinaryTree root)
        {
            if (root == null)
            {
                yield break;
            }
            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            stack.Push(root);
            while (root.Right != null)
            {
                stack.Push(root.Right);
                root = root.Right;
            }
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                yield return tmp;
                if (tmp.Left != null)
                {
                    stack.Push(tmp.Left);
                    tmp = tmp.Left;
                    while (tmp.Right != null)
                    {
                        stack.Push(tmp.Right);
                        tmp = tmp.Right;
                    }
                }
            }
        }
    }
}
