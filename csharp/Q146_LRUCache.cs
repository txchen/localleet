using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and set.
//
// get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
// set(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

// https://leetcode.com/problems/lru-cache/
namespace LocalLeet
{
    public class Q146
    {
        // implement this class
        public class LRUCache {
            private int _capacity;
            private Dictionary<int, DoubleListNode> _dict;
            private int _count;
            private DoubleListNode _preHead;
            private DoubleListNode _tail;

            public LRUCache(int capacity)
            {
                _capacity = capacity;
                _dict = new Dictionary<int, DoubleListNode>();
                _preHead = new DoubleListNode(0, 0);
                _tail = _preHead;
            }

            public int Get(int key)
            {
                if (_dict.ContainsKey(key))
                {
                    var node = _dict[key];
                    // put this into the tail
                    PutToTail(node);
                    return node.Value;
                }
                return -1;
            }

            public void Set(int key, int value)
            {
                if (!_dict.ContainsKey(key))
                {
                    _count++;
                    var nn = new DoubleListNode(key, value);
                    _dict[key] = nn;
                    _tail.Next = nn;
                    nn.Prev = _tail;
                    _tail = nn;
                }
                else
                {
                    var node = _dict[key];
                    node.Value = value;
                    PutToTail(node);
                }

                if (_count > _capacity)
                {
                    _count--;
                    // remove the node in head
                    _dict.Remove(_preHead.Next.Key);
                    _preHead.Next = _preHead.Next.Next;
                    _preHead.Next.Prev = _preHead;
                }
            }

            private void PutToTail(DoubleListNode node)
            {
                if (node != _tail)
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                    _tail.Next = node;
                    node.Next = null;
                    node.Prev = _tail;
                    _tail = node;
                }
            }
        }

        private class DoubleListNode
        {
            public int Key;
            public int Value;
            public DoubleListNode Next;
            public DoubleListNode Prev;

            public DoubleListNode(int k, int v)
            {
                Key = k;
                Value = v;
            }
        }

        [Fact]
        public void Q146_LRUCache()
        {
            // "input":"1,[set(2,1),get(2),set(3,2),get(2),get(3)]","expected":"[1,-1,2]"
            TestHelper.Run(input => {
                string inputString = input.EntireInput;
                int capacity = int.Parse(inputString.Substring(0, inputString.IndexOf(',')));
                // extract commands
                string commandString = inputString.Substring(inputString.IndexOf(',') + 1)
                    .Trim('[').Trim(']');
                var commands = commandString.Split(new string[] {"),"}, StringSplitOptions.RemoveEmptyEntries);
                // create a cache
                LRUCache cache = new LRUCache(capacity);
                // execute each command
                List<int> output = new List<int>();
                foreach (var cmd in commands)
                {
                    if (cmd.StartsWith("set("))
                    {
                        string pair = cmd.Substring(4).Trim(')');
                        int keyToSet = int.Parse(pair.Split(',')[0]);
                        int valueToSet = int.Parse(pair.Split(',')[1]);
                        cache.Set(keyToSet, valueToSet);
                    }
                    else // get(x)
                    {
                        int keyToGet = int.Parse(cmd.Substring(4).Trim(')'));
                        output.Add(cache.Get(keyToGet));
                    }
                }
                return TestHelper.Serialize(output.ToArray());
            });
        }
    }
}
