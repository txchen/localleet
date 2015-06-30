using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Write a program to solve a Sudoku puzzle by filling the empty cells.

// Empty cells are indicated by the character '.'.

// You may assume that there will be only one unique solution.

namespace LocalLeet
{
    public class Q037
    {
        public int[,] SolveSudoku(int[,] board)
        {
            SolveSudokuBool(board);
            return board;
        }

        private bool SolveSudokuBool(int[,] board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r, c] == 0)
                    {
                        for (int i = 1; i <= 9; i++)
                        {
                            board[r, c] = i;
                            // fill and continue
                            if (IsValid(board, r, c) && SolveSudokuBool(board))
                            {
                                return true;
                            }
                        }
                        board[r, c] = 0; // backtrack
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValid(int[,] board, int r, int c)
        {
            // check same col
            for (int i = 0; i < 9; i++)
            {
                if (board[i, c] == board[r, c] && i != r)
                {
                    return false;
                }
            }
            // check same row
            for (int j = 0; j < 9; j++)
            {
                if (board[r, j] == board[r, c] && j != c)
                {
                    return false;
                }
            }
            // check blocks
            int rr = r / 3 * 3;
            int cc = c / 3 * 3;
            for (int i = rr; i < rr + 3; i++)
            {
                for (int j = cc; j < cc + 3; j++)
                {
                    if (board[i, j] == board[r, c] && (i != r || j != c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string SerializeSodoku(int[,] board)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int r = 0; r < 9; r++)
            {
                sb.Append("\"");
                for (int c = 0; c < 9; c++)
                {
                    sb.Append(board[c, r].ToString());
                }
                sb.Append("\",");
            }
            return sb.ToString().TrimEnd(',') + "]";
        }

        [Fact]
        public void Q037_SudokuSolver()
        {
            TestHelper.Run(input =>
            {
                int[,] data = Q036.ParseSudokuData(input[0]);
                return SerializeSodoku(SolveSudoku(data));
            });
        }
    }
}
