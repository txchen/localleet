using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// The demons had captured the princess (P) and imprisoned her in the bottom-right corner of a dungeon. The dungeon consists of M x N rooms laid out in a 2D grid. Our valiant knight (K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.
//
// The knight has an initial health point represented by a positive integer. If at any point his health point drops to 0 or below, he dies immediately.
//
// Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty (0's) or contain magic orbs that increase the knight's health (positive integers).
//
// In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
//
//
// Write a function to determine the knight's minimum initial health so that he is able to rescue the princess.
//
// For example, given the dungeon below, the initial health of the knight must be at least 7 if he follows the optimal path RIGHT-> RIGHT -> DOWN -> DOWN.
//
// -2 (K)	-3	3
// -5	-10	1
// 10	30	-5 (P)
//
// Notes:
//
// The knight's health has no upper bound.
// Any room can contain threats or power-ups, even the first room the knight enters and the bottom-right room where the princess is imprisoned.

// https://leetcode.com/problems/dungeon-game/
namespace LocalLeet
{
    public class Q174
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int row = dungeon.Length;
            int col = dungeon[0].Length;
            int[][] answer = new int[row][];
            for (int i = 0; i < row; i++)
            {
                answer[i] = new int[col];
            }

            answer[row - 1][col - 1] = dungeon[row - 1][col - 1] > 0 ? 1 : 1 - dungeon[row - 1][col - 1];
            // right edge
            for (int r = row -2; r >=0; r--)
            {
                answer[r][col - 1] = answer[r + 1][col - 1] - dungeon[r][col - 1];
                answer[r][col - 1] = Math.Max(1, answer[r][col-1]);
            }
            // bottom edge
            for (int c = col - 2; c >= 0; c--)
            {
                answer[row - 1][c] = answer[row - 1][c + 1] - dungeon[row - 1][c];
                answer[row - 1][c] = Math.Max(1, answer[row - 1][c]);
            }
            for (int c = col - 2; c >= 0; c--)
            {
                for (int r = row - 2; r >= 0; r--)
                {
                    answer[r][c] = Math.Min(answer[r + 1][c], answer[r][c + 1]) - dungeon[r][c];
                    answer[r][c] = Math.Max(1, answer[r][c]);
                }
            }
            return answer[0][0];
        }

        [Fact]
        public void Q174_DungeonGame()
        {
            TestHelper.Run(input => CalculateMinimumHP(input.EntireInput.ToIntArrayArray()).ToString());
        }
    }
}
