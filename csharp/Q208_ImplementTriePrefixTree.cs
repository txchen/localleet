using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Implement a trie with insert, search, and startsWith methods.
//
// Note:
// You may assume that all inputs are consist of lowercase letters a-z.

// https://leetcode.com/problems/implement-trie-prefix-tree/
namespace LocalLeet
{
    public class Q208
    {
        class TrieNode
        {
            public bool IsWord;
            TrieNode[] children;
            public TrieNode()
            {
                children = new TrieNode[26];
            }

            public TrieNode GetChild(char c)
            {
                var node = children[c - 'a'];
                return children[c - 'a'];
            }

            public TrieNode AddChild(char c)
            {
                children[c - 'a'] = children[c - 'a'] ?? new TrieNode();
                return children[c - 'a'];
            }
        }

        public class Trie
        {
            private TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            // Inserts a word into the trie.
            public void Insert(String word)
            {
                var curNode = root;
                foreach (char c in word)
                {
                    curNode = curNode.AddChild(c);
                }
                curNode.IsWord = true;
            }

            // Returns if the word is in the trie.
            public bool Search(string word)
            {
                var curNode = root;
                foreach (char c in word)
                {
                    curNode = curNode.GetChild(c);
                    if (curNode == null)
                    {
                        return false;
                    }
                }
                return curNode.IsWord;
            }

            // Returns if there is any word in the trie
            // that starts with the given prefix.
            public bool StartsWith(string word)
            {
                var curNode = root;
                foreach (char c in word)
                {
                    curNode = curNode.GetChild(c);
                    if (curNode == null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        // Your Trie object will be instantiated and called as such:
        // Trie trie = new Trie();
        // trie.Insert("somestring");
        // trie.Search("key");

        // "input":"insert(\"a\"),search(\"a\"),startsWith(\"a\")","expected":"[true,true]"}
        [Fact]
        public void Q208_ImplementTriePrefixTree()
        {
            TestHelper.Run(input => {
                Trie trie = new Trie();
                List<bool> output = new List<bool>();
                var commands = input.EntireInput.Substring(0, input.EntireInput.Length - 2);
                commands.Split(new string[] {"),"}, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(token => {
                    if (token.StartsWith("insert("))
                    {
                        trie.Insert(token.Substring(8).TrimEnd('"'));
                    }
                    else if (token.StartsWith("search("))
                    {
                        output.Add(trie.Search(token.Substring(8).TrimEnd('"')));
                    }
                    else if (token.StartsWith("startsWith("))
                    {
                        output.Add(trie.StartsWith(token.Substring(12).TrimEnd('"')));
                    }
                });
                return TestHelper.Serialize(output.ToArray());
            });
        }
    }
}
