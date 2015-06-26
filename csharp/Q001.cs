using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Given an array of integers, find two numbers such that they add up to a specific target number.

// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

// You may assume that each input would have exactly one solution.

// Input: numbers={2, 7, 11, 15}, target=9
// Output: index1=1, index2=2

namespace LeetSharp
{
    public class Q001_TwoSum
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return String.Join(", ", TwoSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [Fact]
        public void Q001_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q001_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
