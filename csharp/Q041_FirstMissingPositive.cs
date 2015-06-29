using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an unsorted integer array, find the first missing positive integer.

// For example,
// Given [1,2,0] return 3,
// and [3,4,-1,1] return 2.

// Your algorithm should run in O(n) time and uses constant space.

namespace LocalLeet
{

    public class Q041_FirstMissingPositive
    {
        public int FirstMissingPositive(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int currentValue = A[i];
                int shouldBeAt = currentValue - 1;
                while (i != shouldBeAt && shouldBeAt >= 0 && shouldBeAt <= A.Length -1)
                {
                    // swap i and shouldBeAt, put the value in the 'correct' position
                    if (A[i] == A[shouldBeAt])
                    {
                        break;
                    }
                    A[i] = A[shouldBeAt];
                    A[shouldBeAt] = currentValue;
                    currentValue = A[i];
                    shouldBeAt = currentValue - 1;
                }
            }
            // now scan from start to end, find the first wrong number
            // the data should be [1, 2, 3, 4, 5....], the first wrong number is the answer
            for (int j = 0; j < A.Length; j++)
            {
                if (A[j] != j + 1)
                {
                    return j + 1;
                }
            }
            return A.Length + 1;
        }

        public string SolveQuestion(string input)
        {
            return FirstMissingPositive(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q041_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q041_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
