using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Follow up for "Remove Duplicates": Q026
// What if duplicates are allowed at most twice?

// For example,
// Given sorted array A = [1,1,1,2,2,3],

// Your function should return length = 5, and A is now [1,1,2,2,3].

namespace LocalLeet
{
    public class Q080_RemoveDuplicatesfromSortedArrayII
    {
        public int[] RemoveDuplicates(int[] input)
        {
            int write = 0;
            int read = 0;
            int readStart = 0;
            while (read <= input.Length)
            {
                if (read == input.Length || input[readStart] != input[read])
                {
                    if (read - readStart >= 2)
                    {
                        input[write] = input[write + 1] = input[readStart];
                        write += 2;
                    }
                    else if (read - readStart == 1)
                    {
                        input[write] = input[readStart];
                        write++;
                    }
                    readStart = read;
                }
                read++;
            }
            return input.Take(write).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RemoveDuplicates(input[0].ToIntArray()));
        }

        [Fact]
        public void Q080_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
