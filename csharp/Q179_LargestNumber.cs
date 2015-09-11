using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a list of non negative integers, arrange them such that they form the largest number.
//
// For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.
//
// Note: The result may be very large, so you need to return a string instead of an integer.

// https://leetcode.com/problems/largest-number/
namespace LocalLeet
{
    public class Q179
    {
        public string LargestNumber(int[] num)
        {
            Array.Sort(num,CompareNum);
            if (num[0] == 0)
            {
                return "0";
            }
            return String.Concat(num);
        }

        private static int CompareNum(int a, int b)
        {
            string sa = b.ToString();
            string sb = a.ToString();
            return (sa + sb).CompareTo(sb + sa);
        }

        [Fact]
        public void Q179_LargestNumber()
        {
            TestHelper.Run(input => "\"" + LargestNumber(input.EntireInput.ToIntArray()) + "\"");
        }
    }
}
