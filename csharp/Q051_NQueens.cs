using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// The n-queens puzzle is the problem of placing n queens on an n�n chessboard such that no two queens attack each other.
// Given an integer n, return all distinct solutions to the n-queens puzzle.

// Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

// For example,
// There exist two distinct solutions to the 4-queens puzzle:

//[
// [".Q..",  // Solution 1
//  "...Q",
//  "Q...",
//  "..Q."],

// ["..Q.",  // Solution 2
//  "Q...",
//  "...Q",
//  ".Q.."]
//]

namespace LocalLeet
{

    public class Q051_NQueens
    {
        public string[][] SolveNQueens(int n)
        {
            int colMask = 0;
            int slashMask = 0;
            int backSlashMask = 0; // use 3 masks to store the current status
            List<int[]> answers = new List<int[]>(); // answer = int[], each row's index -> then convert to string
            int[] answer = new int[n];
            SolveNQueensRec(answers, colMask, slashMask, backSlashMask, 0, n, answer);
            return ConvertAnswers(answers);
        }

        private string[][] ConvertAnswers(List<int[]> answers)
        {
            List<string[]> res = new List<string[]>();
            foreach (var answer in answers)
            {
                string[] a = new string[answer.Length];
                for (int i = 0; i < answer.Length; i++)
                {
                    a[i] = new string('.', answer[i]) + "Q" + new string('.', answer.Length - 1 - answer[i]);
                }
                res.Add(a);
            }
            return res.ToArray();
        }

        private void SolveNQueensRec(List<int[]> answers, int colMask, int slashMask, int backSlashMask,
            int currentRow, int n, int[] answer)
        {
            for (int i = 0; i < n; i++)
            {
                int mask = colMask | slashMask | backSlashMask;
                if ((mask & 1 << i) == 0) // mean it maybe a valid position
                {
                    answer[currentRow] = i;
                    if (currentRow == n - 1) // we got an answer
                    {
                        answers.Add(answer.ToArray());
                        continue;
                    }
                    // try next level, first set the mask
                    int newColMask = colMask | 1 << i;
                    int newSlashMask = (slashMask | 1 << i) << 1;
                    int newBackSlashMask = (backSlashMask | 1 << i) >> 1;
                    SolveNQueensRec(answers, newColMask, newSlashMask, newBackSlashMask, currentRow + 1, n, answer);
                }
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SolveNQueens(input.ToInt()));
        }

        [TestMethod]
        public void Q051_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q051_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
