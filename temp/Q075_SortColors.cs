using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent,
// with the colors in the order red, white and blue.

// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

// Note:
// You are not suppose to use the library's sort function for this problem.

// Follow up:
// A rather straight forward solution is a two-pass algorithm using counting sort.
// First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's,
// then 1's and followed by 2's.
// Could you come up with an one-pass algorithm using only constant space?

namespace LocalLeet
{
    public class Q075
    {
        public int[] SortColors(int[] input)
        {
            int zeroIndex = 0;
            int twoIndex = input.Length - 1;
            int scan = 0;
            while (scan <= twoIndex)
            {
                if (input[scan] == 0)
                {
                    if (scan > zeroIndex)
                    {
                        input[scan] = input[zeroIndex];
                        input[zeroIndex++] = 0;
                    }
                    else
                    {
                        zeroIndex++;
                        scan++;
                    }
                }
                else if (input[scan] == 2)
                {
                    if (scan < twoIndex)
                    {
                        input[scan] = input[twoIndex];
                        input[twoIndex--] = 2;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    scan++;
                }
            }
            return input;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SortColors(input[0].ToIntArray()));
        }

        [Fact]
        public void Q075_SortColors()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
