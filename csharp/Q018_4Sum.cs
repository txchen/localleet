using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target?
// Find all unique quadruplets in the array which gives the sum of target.

// Note:
// Elements in a quadruplet (a,b,c,d) must be in non-descending order. (ie, a ? b ? c ? d)
// The solution set must not contain duplicate quadruplets.
//    For example, given array S = {1 0 -1 0 -2 2}, and target = 0.

//    A solution set is:
//    (-1,  0, 0, 1)
//    (-2, -1, 1, 2)
//    (-2,  0, 0, 2)

// https://leetcode.com/problems/4sum/
namespace LocalLeet
{
    public class Q018
    {
        public int[][] FourSum(int[] num, int target)
        {
            List<int[]> answer = new List<int[]>();
            num = num.OrderBy(n => n).ToArray();
            // should be O(N^3)
            for (int a = 0; a < num.Length - 3; a++)
            {
                for (int b = a + 1; b < num.Length - 2; b++)
                {
                    int c = b + 1;
                    int d = num.Length - 1; // shrink to middle to scan, thus O(N^3)
                    while (c < d)
                    {
                        int current = num[a] + num[b] + num[c] + num[d];
                        if (current == target)
                        {
                            if (!answer.Any(t => t[0] == num[a] && t[1] == num[b] && t[2] == num[c] && t[3] == num[d]))
                            {
                                answer.Add(new int[] { num[a], num[b], num[c], num[d] });
                            }
                            c++;
                            d--;
                        }
                        else if (current > target)
                        {
                            d--;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q018_4Sum()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(FourSum(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
