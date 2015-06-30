using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a 2D board and a word, find if the word exists in the grid.

// The word can be constructed from letters of sequentially adjacent cell,
// where "adjacent" cells are those horizontally or vertically neighboring.
// The same letter cell may not be used more than once.

// For example,
// Given board =

// [
//   ["ABCE"],
//   ["SFCS"],
//   ["ADEE"]
// ]
// word = "ABCCED", -> returns true,
// word = "SEE", -> returns true,
// word = "ABCB", -> returns false.

namespace LocalLeet
{
    public class Q079
    {
        public bool Exist(string[] board, string word)
        {
            if (board.Length == 0)
            {
                return false;
            }
            int rowCount = board.Length;
            int colCount = board[0].Length;
            bool[,] mark = new bool[rowCount, colCount];
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (Find(board, word, 0, mark, r, c))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Find(string[] board, string word, int index, bool[,] mark, int r, int c)
        {
            if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length)
            {
                return false;
            }
            if (board[r][c] != word[index] || mark[r, c])
            {
                return false;
            }
            if (index == word.Length - 1)
            {
                return true;
            }
            mark[r, c] = true;
            bool result = Find(board, word, index + 1, mark, r - 1, c) ||
                Find(board, word, index + 1, mark, r + 1, c) ||
                Find(board, word, index + 1, mark, r, c - 1) ||
                Find(board, word, index + 1, mark, r, c + 1);
            mark[r, c] = false;
            return result;
        }

        public string SolveQuestion(string input)
        {
            return Exist(input[0].ToStringArray(), input[1].Deserialize()).ToString().ToLower();
        }

        [Fact]
        public void Q079_WordSearch()
        {
            TestHelper.Run(input => SolveQuestion(s));
        }
    }
}
