using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a 2D board and a list of words from the dictionary, find all words in the board.
//
// Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.
//
// For example,
// Given words = ["oath","pea","eat","rain"] and board =
//
// [
//   ['o','a','a','n'],
//   ['e','t','a','e'],
//   ['i','h','k','r'],
//   ['i','f','l','v']
// ]
// Return ["eat","oath"].
// Note:
// You may assume that all inputs are consist of lowercase letters a-z.

// https://leetcode.com/problems/word-search-ii/
namespace LocalLeet
{
    public class Q212
    {
        public IList<string> FindWords(char[,] board, string[] words)
        {
            Trie trie = new Trie();
            foreach (var word in words)
            {
                trie.Add(word);
            }

            int row = board.GetLength(0);
            int col = board.GetLength(1);
            bool[,] visited = new bool[row, col];
            List<string> result = new List<string>();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Dfs(board, visited, r, c, "", trie, result);
                }
            }
            return result.Distinct().ToList();
        }

        private void Dfs(char[,] board, bool[,] visited, int r, int c, string current, Trie trie, List<string> result)
        {
            if (r < 0 || r >= board.GetLength(0) || c < 0 || c >= board.GetLength(1) || visited[r, c])
            {
                return;
            }
            current = current + board[r, c];
            if (!trie.StartWith(current))
            {
                return;
            }
            if (trie.Contains(current))
            {
                result.Add(current);
            }
            visited[r, c] = true;
            Dfs(board, visited, r + 1, c, current, trie, result);
            Dfs(board, visited, r - 1, c, current, trie, result);
            Dfs(board, visited, r, c + 1, current, trie, result);
            Dfs(board, visited, r, c - 1, current, trie, result);
            visited[r, c] = false;
        }

        public class TrieNode
        {
            public TrieNode[] Children = new TrieNode[26];
            public bool IsWord = false;
        }

        public class Trie
        {
            private TrieNode root = new TrieNode();

            public void Add(string word)
            {
                TrieNode n = root;
                foreach (char c in word)
                {
                    if (n.Children[c - 'a'] == null)
                    {
                        n.Children[c - 'a'] = new TrieNode();
                    }
                    n = n.Children[c - 'a'];
                }
                n.IsWord = true;
            }

            public bool StartWith(string word)
            {
                TrieNode n = root;
                foreach (char c in word)
                {
                    if (n.Children[c - 'a'] == null)
                    {
                        return false;
                    }
                    n = n.Children[c - 'a'];
                }
                return true;
            }

            public bool Contains(string word)
            {
                TrieNode n = root;
                foreach (char c in word)
                {
                    if (n.Children[c - 'a'] == null)
                    {
                        return false;
                    }
                    n = n.Children[c - 'a'];
                }
                return n.IsWord;
            }
        }

        [Fact]
        public void Q212_WordSearchII()
        {
            // "input":"[\"ab\",\"cd\"], [\"acdb\"]","expected":"[\"acdb\"]"
            TestHelper.Run(input => {
                var boardArray = input[0].ToStringArray();
                int boardRowCount = boardArray.Length;
                int boardColCount = boardArray[0].Length;
                var board = new char[boardRowCount, boardColCount];
                for (int i = 0; i < boardRowCount; i++)
                {
                    for (int j = 0; j < boardColCount; j++)
                    {
                        board[i, j] = boardArray[i][j];
                    }
                }
                var words = input[1].ToStringArray();
                return TestHelper.Serialize(FindWords(board, words).OrderBy(w => w).ToArray());
            });
        }
    }
}
