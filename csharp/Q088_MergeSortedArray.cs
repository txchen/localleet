using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given two sorted integer arrays A and B, merge B into A as one sorted array.

// Note:
// You may assume that A has enough space to hold additional elements from B.
// The number of elements initialized in A and B are m and n respectively.

// https://leetcode.com/problems/merge-sorted-array/
namespace LocalLeet
{
    public class Q088
    {
        public int[] Merge(int[] a, int[] b)
        {
            int aLen = a.Length;
            int bLen = b.Length;
            int[] newa = new int[aLen + bLen];
            for (int j = 0; j < a.Length; j++)
            {
                newa[j] = a[j];
            }
            a = newa;
            // now start working, a[] has empty slot in the end, so start from end
            int i = a.Length - 1;
            int ia = aLen - 1;
            int ib = bLen - 1;
            while (i >= 0)
            {
                if (ib < 0)
                {
                    a[i--] = a[ia--];
                    continue;
                }
                if (ia < 0)
                {
                    a[i--] = b[ib--];
                    continue;
                }
                if (a[ia] > b[ib])
                {
                    a[i--] = a[ia--];
                }
                else
                {
                    a[i--] = b[ib--];
                }
            }
            return a;
        }

        [Fact]
        public void Q088_MergeSortedArray()
        {
            TestHelper.Run(input => TestHelper.Serialize(Merge(input[0].ToIntArray(), input[1].ToIntArray())));
        }
    }
}
