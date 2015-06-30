using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

// Do not allocate extra space for another array, you must do this in place with constant memory.

// For example,
// Given input array A = [1,1,2],

// Your function should return [1,2].

// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
namespace LocalLeet
{
    public class Q026
    {
        public int[] RemoveDuplicates(int[] a)
        {
            if (a.Length == 0)
            {
                return new int[0];
            }
            int writeIndex = 0;
            for (int readIndex = 1; readIndex < a.Length; )
            {
                if (a[readIndex] != a[writeIndex])
                {
                    writeIndex++;
                    a[writeIndex] = a[readIndex];
                    while (readIndex < a.Length && a[readIndex] == a[writeIndex])
                    {
                        readIndex++;
                    }
                }
                else
                {
                    readIndex++;
                }
            }
            return a.Take(writeIndex + 1).ToArray();
        }

        [Fact]
        public void Q026_RemoveDuplicatesfromSortedArray()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(RemoveDuplicates(input[0].ToIntArray())));
        }
    }
}
