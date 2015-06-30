using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0?
// Find all unique triplets in the array which gives the sum of zero.

// Note:
// Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ? b ? c)
// The solution set must not contain duplicate triplets.
//    For example, given array S = {-1 0 1 2 -1 -4},

//    A solution set is:
//    (-1, 0, 1)
//    (-1, -1, 2)

// https://leetcode.com/problems/3sum/
namespace LocalLeet
{
    public class Q015
    {
        public int[][] ThreeSum(int[] num)
        {
            List<int[]> answer = new List<int[]>(); num = num.OrderBy(n => n).ToArray();            // should be O(N^2)
            for (int a = 0; a < num.Length - 2; a++)
            {
                if (a > 0 && num[a] == num[a - 1])
                {
                    continue;
                }
                int b = a + 1;
                int c = num.Length - 1;
                // shrink to middle to scan, thus O(N^2)
                while (b < c)
                {
                    int current = num[a] + num[b] + num[c];
                    if (current == 0)
                    {
                        answer.Add(new int[] { num[a], num[b], num[c] });
                        b++;
                        while (b < c && num[b] == num[b - 1])
                        {
                            b++;
                        }
                    }
                    else if (current > 0)
                    {
                        c--;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q015_3Sum()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(ThreeSum(input[0].ToIntArray())));
        }
    }
}
