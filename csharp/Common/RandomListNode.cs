using System;
using System.Text;
using System.Collections.Generic;

namespace LocalLeet
{
    public class RandomListNode
    {
        public int Val;
        public RandomListNode Next;
        public RandomListNode Random;

        public RandomListNode(int x)
        {
            Val = x;
        }

        // sample {1,2,#,2}
        // the first half is the label of each node, in this case, 1 and 2
        // the second half is the label of each random node, # means null
        // so this means 1's next is 2, 1's random is null, 2's random is itself
        public static RandomListNode FromString(string s)
        {
            string[] tokens = s.TrimEnd('}').TrimStart('{')
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                return null;
            }
            Dictionary<string, RandomListNode> dict = new Dictionary<string, RandomListNode>();
            RandomListNode pre = new RandomListNode(-1);
            var temp = pre;
            for (int i = 0; i < tokens.Length / 2; i++)
            {
                temp.Next = new RandomListNode(int.Parse(tokens[i]));
                dict[tokens[i]] = temp.Next;
                temp = temp.Next;
            }
            temp = pre.Next;
            for (int i = tokens.Length / 2; i < tokens.Length; i++)
            {
                if (tokens[i] != "#")
                {
                    temp.Random = dict[tokens[i]];
                }
                temp = temp.Next;
            }
            return pre.Next;
        }

        public static string Serialize(RandomListNode node)
        {
            if (node == null)
            {
                return "{}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            var temp = node;
            while (temp != null)
            {
                sb.Append(temp.Val.ToString());
                sb.Append(",");
                temp = temp.Next;
            }
            temp = node;
            while (temp != null)
            {
                if (temp.Random != null)
                {
                    sb.Append(temp.Random.Val.ToString());
                }
                else
                {
                    sb.Append("#");
                }
                sb.Append(",");
                temp = temp.Next;
            }
            // remove last ,
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
