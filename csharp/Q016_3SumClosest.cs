using System;
using System.Collections.Generic;
using System.Linq;

// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target.
// Return the sum of the three integers. You may assume that each input would have exactly one solution.

//    For example, given array S = {-1 2 1 -4}, and target = 1.

//    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

namespace LocalLeet
{
    public class Q016_3SumClosest
    {
        public int ThreeSumClosest(int[] num, int target)
        {
            num = num.OrderBy(n => n).ToArray();
            int answer = num[0] + num[1] + num[2];
            // should be O(N^2)
            for (int a = 0; a < num.Length - 2; a++)
            {
                int b = a + 1;
                int c = num.Length - 1; // shrink to middle to scan, thus O(N^2)
                while (b < c)
                {
                    int current = num[a] + num[b] + num[c];
                    int diff = current - target;
                    if (diff == 0)
                    {
                        return target;
                    }
                    else if (diff > 0)
                    {
                        c--;
                    }
                    else
                    {
                        b++;
                    }
                    if (Math.Abs(target - answer) > Math.Abs(diff))
                    {
                        answer = current;
                    }
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return ThreeSumClosest(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()).ToString();
        }

        [Fact]
        public void Q016_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q016_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
