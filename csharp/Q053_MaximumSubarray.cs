using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

// For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
// the contiguous subarray [4,−1,2,1] has the largest sum = 6.

namespace LocalLeet
{

    public class Q053_MaximumSubarray
    {
        public int MaxSubArray(int[] input)
        {
            int answer = input[0];
            int currentSum = input[0] > 0 ? input[0] : 0;
            for (int i = 1; i < input.Length; i++)
            {
                currentSum += input[i];
                answer = Math.Max(answer, currentSum);
                if (currentSum <= 0)
                {
                    currentSum = 0;
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return MaxSubArray(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q053_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q053_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
