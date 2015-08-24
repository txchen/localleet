using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Find the contiguous subarray within an array (containing at least one number) which has the largest product.
//
// For example, given the array [2,3,-2,4],
// the contiguous subarray [2,3] has the largest product = 6.

// https://leetcode.com/problems/maximum-product-subarray/
namespace LocalLeet
{
    public class Q152
    {
        public int MaxProduct(int[] sums)
        {
            int answer = sums[0];
            int tempMax = sums[0];
            int tempMin = sums[0];

            for (int i = 1; i < sums.Length; i++)
            {
                int newTempMax = Math.Max(Math.Max(sums[i], sums[i] * tempMin), sums[i] * tempMax);
                int newTempMin = Math.Min(Math.Min(sums[i], sums[i] * tempMin), sums[i] * tempMax);
                answer = Math.Max(answer, newTempMax);
                tempMax = newTempMax;
                tempMin = newTempMin;
            }

            return answer;
        }

        [Fact]
        public void Q152_MaximumProductSubarray()
        {
            TestHelper.Run(input => MaxProduct(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
