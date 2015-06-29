using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array of integers, find two numbers such that they add up to a specific target number.

// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

// You may assume that each input would have exactly one solution.

// Input: numbers={2, 7, 11, 15}, target=9
// Output: index1=1, index2=2

namespace LocalLeet
{
    public class Q001
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target) {
                        return new int[] { i + 1, j + 1 };
                    }
                }
            }
            return new int[0];
        }

        [Fact]
        public void Q001_TwoSum()
        {
            TestHelper.Run(input =>
                String.Join(", ", TwoSum(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
