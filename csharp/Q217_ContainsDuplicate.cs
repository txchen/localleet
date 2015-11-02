using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an array of integers, find if the array contains any duplicates. Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.

// https://leetcode.com/problems/contains-duplicate/
namespace LocalLeet
{
    public class Q217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>();
            foreach (int n in nums)
            {
                if (!hs.Add(n))
                {
                    return true;
                }
            }
            return false;
        }

        [Fact]
        public void Q217_ContainsDuplicate()
        {
            TestHelper.Run(input => ContainsDuplicate(input.EntireInput.ToIntArray()).ToString().ToLower());
        }
    }
}
