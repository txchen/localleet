using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// There are two sorted arrays A and B of size m and n respectively. Find the median of the two sorted arrays.
// The overall run time complexity should be O(log (m+n)).

namespace LocalLeet
{
    public class Q004
    {
        public double FindMedianSortedArrays(int[] a, int[] b)
        {
            var c = a.Concat(b).OrderBy(i => i).ToArray();
            return (c[c.Length / 2] + c[(c.Length - 1) / 2]) / 2.0;
        }

        [Fact]
        public void Q004_MedianofTwoSortedArrays()
        {
            TestHelper.Run(input =>
                FindMedianSortedArrays(input[0].ToIntArray(), input[1].ToIntArray()).ToString("F5"));
        }
    }
}
