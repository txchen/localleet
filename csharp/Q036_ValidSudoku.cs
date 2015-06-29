using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.

// The Sudoku board could be partially filled, where empty cells are filled with the character '.'.

namespace LocalLeet
{

    public class Q036_ValidSudoku
    {
        public bool IsValidSudoku(int[,] board)
        {
            int length = board.GetLength(0);
            HashSet<int> chk = new HashSet<int>();
            // check rows
            for (int r = 0; r < length; r++)
            {
                chk.Clear();
                for (int c = 0; c < length; c++)
                {
                    if (board[r, c] != 0 && !chk.Add(board[r, c]))
                    {
                        return false;
                    }
                }
            }
            // check columns
            for (int c = 0; c < length; c++)
            {
                chk.Clear();
                for (int r = 0; r < length; r++)
                {
                    if (board[r, c] != 0 && !chk.Add(board[r, c]))
                    {
                        return false;
                    }
                }
            }
            // check blocks
            for (int left = 0; left < length; left += 3)
            {
                for (int top = 0; top < length; top += 3)
                {
                    chk.Clear();
                    for (int r = top; r < top + 3; r++)
                    {
                        for (int c = left; c < left + 3; c++)
                        {
                            if (board[r, c] != 0 && !chk.Add(board[r, c]))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static int[,] ParseSudokuData(string s)
        {
            int[,] result = new int[9, 9];
            var tokens = s.TrimStart('[').TrimEnd(']').Split(',');
            for (int r = 0; r < 9; r++)
            {
                var token = tokens[r].Trim('"');
                for (int c = 0; c < 9; c++)
                {
                    result[c, r] = token[c] == '.' ? 0 : int.Parse(token[c].ToString());
                }
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            int[,] data = ParseSudokuData(input);
            return IsValidSudoku(data).ToString().ToLower();
        }

        [TestMethod]
        public void Q036_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q036_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
