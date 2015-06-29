using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a sorted array and a target value, return the index if the target is found.
// If not, return the index where it would be if it were inserted in order.

// You may assume no duplicates in the array.

// Here are few examples.
// [1,3,5,6], 5 �� 2
// [1,3,5,6], 2 �� 1
// [1,3,5,6], 7 �� 4
// [1,3,5,6], 0 �� 0

namespace LocalLeet
{

    public class Q035_SearchInsertPosition
    {
        public int SearchInsert(int[] input, int target)
        {
            int left = 0, right = input.Length;
            while (left < right)
            {
                int mid = (left + right) /2;
                if (input[mid] == target)
                {
                    return mid;
                }
                else if (input[mid] > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return right;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SearchInsert(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q035_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q035_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
