using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

// A region is captured by flipping all 'O's into 'X's in that surrounded region .

// For example,

// X X X X
// X O O X
// X X O X
// X O X X
// After running your function, the board should be:

// X X X X
// X X X X
// X X X X
// X O X X

// https://leetcode.com/problems/surrounded-regions/
namespace LocalLeet
{
    public class Q130
    {
        public string[] Solve(string[] board)
        {
            if (board.Length == 0)
            {
                return board;
            }
            var charMap = board.Select(r => r.ToCharArray()).ToArray();
            // only edge can survive, scan the edge, find O, mark connected area to 'Z' (temp)
            for (int r = 0; r < charMap.Length; r++)
            {
                MarkForSurvive(charMap, r, 0);
                MarkForSurvive(charMap, r, charMap[0].Length - 1);
            }
            for (int c = 0; c < charMap[0].Length; c++)
            {
                MarkForSurvive(charMap, 0, c);
                MarkForSurvive(charMap, charMap.Length - 1, c);
            }
            // now change 'Z' to 'O', change 'O' to 'X'
            for (int r = 0; r < charMap.Length; r++)
            {
                for (int c = 0; c < charMap[0].Length; c++)
                {
                    if (charMap[r][c] == 'O')
                    {
                        charMap[r][c] = 'X';
                    }
                    if (charMap[r][c] == 'Z')
                    {
                        charMap[r][c] = 'O';
                    }
                }
            }
            return charMap.Select(arr => new String(arr)).ToArray();
        }

        private void MarkForSurvive(char[][] board, int r, int c)
        {
            if (board[r][c] == 'O')
            {
                Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
                q.Enqueue(Tuple.Create(r, c));
                while (q.Count > 0)
                {
                    var position = q.Dequeue();
                    if (board[position.Item1][position.Item2] == 'O')
                    {
                        board[position.Item1][position.Item2] = 'Z';
                        TryEnqueue(board, position.Item1 + 1, position.Item2, q);
                        TryEnqueue(board, position.Item1 - 1, position.Item2, q);
                        TryEnqueue(board, position.Item1, position.Item2 + 1, q);
                        TryEnqueue(board, position.Item1, position.Item2 - 1, q);
                    }
                }
            }
        }

        private void TryEnqueue(char[][] board, int r, int c, Queue<Tuple<int, int>> q)
        {
            if (r >= 0 && r < board.Length &&
                c >= 0 && c < board[0].Length &&
                board[r][c] == 'O')
            {
                q.Enqueue(Tuple.Create(r, c));
            }
        }

        [Fact]
        public void Q130_SurroundedRegions()
        {
            TestHelper.Run(input => TestHelper.Serialize(Solve(input[0].ToStringArray())));
        }
    }
}
