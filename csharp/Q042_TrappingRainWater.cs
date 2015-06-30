using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

// For example,
// Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.

// https://leetcode.com/problems/trapping-rain-water/
namespace LocalLeet
{
    public class Q042
    {
        public int TrapWater(int[] inputs)
        {
            // for each bar, it can contains Min(highest in left side, highest in right side) - height
            int[] leftHighestArr = new int[inputs.Length];
            int[] rightHighestArr = new int[inputs.Length];
            int leftHighest = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] > leftHighest)
                {
                    leftHighest = inputs[i];
                }
                leftHighestArr[i] = leftHighest;
            }
            int rightHighest = 0;
            for (int j = inputs.Length - 1; j >= 0; j--)
            {
                if (inputs[j] > rightHighest)
                {
                    rightHighest = inputs[j];
                }
                rightHighestArr[j] = rightHighest;
            }
            // sum
            int answer = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                answer += Math.Min(leftHighestArr[i], rightHighestArr[i]) - inputs[i];
            }
            return answer;
        }

        [Fact]
        public void Q042_TrappingRainWater()
        {
            TestHelper.Run(input => TrapWater(input[0].ToIntArray()).ToString());
        }
    }
}
