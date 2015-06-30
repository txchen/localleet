using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array and a value, remove all instances of that value in place and return the new length.

// The order of elements can be changed. It doesn't matter what you leave beyond the new length.

// https://leetcode.com/problems/remove-element/
namespace LocalLeet
{
    public class Q027
    {
        int[] RemoveElement(int[] a, int toRemove)
        {
            int writeIndex = 0;
            for (int readIndex = 0; readIndex < a.Length; readIndex++)
            {
                if (a[readIndex] != toRemove)
                {
                    a[writeIndex++] = a[readIndex];
                }
            }
            return a.Take(writeIndex).ToArray();
        }

        [Fact]
        public void Q027_RemoveElement()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(RemoveElement(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
