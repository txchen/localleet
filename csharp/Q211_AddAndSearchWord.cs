using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Design a data structure that supports the following two operations:
//
// void addWord(word)
// bool search(word)
// search(word) can search a literal word or a regular expression string containing only letters a-z or .. A . means it can represent any one letter.
//
// For example:
//
// addWord("bad")
// addWord("dad")
// addWord("mad")
// search("pad") -> false
// search("bad") -> true
// search(".ad") -> true
// search("b..") -> true
// Note:
// You may assume that all words are consist of lowercase letters a-z.

// https://leetcode.com/problems/add-and-search-word-data-structure-design/
namespace LocalLeet
{
    public class Q211
    {
        class WordDictionary
        {
            class TrieNode
            {
                public TrieNode[] Children = new TrieNode[26];
                public bool IsWord;
            }

            private TrieNode _root = new TrieNode();

            // Adds a word into the data structure.
            public void AddWord(String word)
            {
                var curNode = _root;
                foreach (char c in word)
                {
                    curNode.Children[c - 'a'] = curNode.Children[c - 'a'] ?? new TrieNode();
                    curNode = curNode.Children[c - 'a'];
                }
                curNode.IsWord = true;
            }

            // Returns if the word is in the data structure. A word could
            // contain the dot character '.' to represent any one letter.
            public bool Search(string word)
            {
                return Search(word, 0, _root);
            }

            private bool Search(string word, int index, TrieNode node)
            {
                if (index == word.Length)
                {
                    return node.IsWord;
                }
                var curChar = word[index];
                if (curChar == '.')
                {
                    foreach (var nextNode in node.Children)
                    {
                        if (nextNode != null)
                        {
                            if (Search(word, index + 1, nextNode))
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    var nextNode = node.Children[curChar - 'a'];
                    if (nextNode == null)
                    {
                        return false;
                    }
                    return Search(word, index + 1, nextNode);
                }
                return false;
            }
        }

        [Fact]
        public void Q211_AddAndSearchWord()
        {
            // "input":"addWord(\"ab\"),search(\"a.\")","expected":"[true]"
            TestHelper.Run(input => {
                WordDictionary dic = new WordDictionary();
                List<bool> output = new List<bool>();
                var commands = input.EntireInput.Substring(0, input.EntireInput.Length - 2);
                commands.Split(new string[] {"),"}, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(token => {
                    if (token.StartsWith("addWord("))
                    {
                        dic.AddWord(token.Substring(9).TrimEnd('"'));
                    }
                    else if (token.StartsWith("search("))
                    {
                        output.Add(dic.Search(token.Substring(8).TrimEnd('"')));
                    }
                });
                return TestHelper.Serialize(output.ToArray());
            });
        }
    }
}
