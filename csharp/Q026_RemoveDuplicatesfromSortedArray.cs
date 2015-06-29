using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

// Do not allocate extra space for another array, you must do this in place with constant memory.

// For example,
// Given input array A = [1,1,2],

// Your function should return [1,2].

namespace LocalLeet
{

    public class Q026_RemoveDuplicatesfromSortedArray
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

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RemoveDuplicates(input.ToIntArray()));
        }

        [TestMethod]
        public void Q026_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q026_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
