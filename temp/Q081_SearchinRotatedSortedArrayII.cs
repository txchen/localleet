using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Follow up for "Search in Rotated Sorted Array": Q033
// What if duplicates are allowed?

// Would this affect the run-time complexity? How and why?

// Write a function to determine if a given target is in the array.

namespace LocalLeet
{
    public class Q081
    {
        public bool SearchRotated(int[] input, int target)
        {
            return Search(input, target, 0, input.Length - 1);
        }

        private bool Search(int[] a, int target, int start, int end)
        {
            if (start > end)
            {
                return false;
            }
            bool sorted = a[start] < a[end];
            int attempt = a[(start + end) / 2];
            if (target == attempt)
            {
                return true;
            }
            else if (target > attempt)
            {
                if (sorted)
                {
                    return Search(a, target, (start + end) / 2 + 1, end);
                }
            }
            else // target < attempt
            {
                if (sorted)
                {
                    return Search(a, target, start, (start + end) / 2 - 1);
                }
            }
            bool leftAnswer = Search(a, target, start, (start + end) / 2 - 1);
            if (leftAnswer)
            {
                return leftAnswer;
            }
            return Search(a, target, (start + end) / 2 + 1, end);
        }

        public string SolveQuestion(string input)
        {
            return SearchRotated(input[0].ToIntArray(), input[1].ToInt()).ToString().ToLower();
        }

        [Fact]
        public void Q081_SearchinRotatedSortedArrayII()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
