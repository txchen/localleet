using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array and a value, remove all instances of that value in place and return the new length.

// The order of elements can be changed. It doesn't matter what you leave beyond the new length.

namespace LocalLeet
{
    public class Q027_RemoveElement
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

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RemoveElement(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [Fact]
        public void Q027_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q027_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
