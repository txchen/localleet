using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.
//
// For example,
// Given nums = [1,3,-1,-3,5,3,6,7], and k = 3.
//
// Window position                Max
// ---------------               -----
// [1  3  -1] -3  5  3  6  7       3
//  1 [3  -1  -3] 5  3  6  7       3
//  1  3 [-1  -3  5] 3  6  7       5
//  1  3  -1 [-3  5  3] 6  7       5
//  1  3  -1  -3 [5  3  6] 7       6
//  1  3  -1  -3  5 [3  6  7]      7
// Therefore, return the max sliding window as [3,3,5,5,6,7].
//
// Note:
// You may assume k is always valid, ie: 1 ≤ k ≤ input array's size for non-empty array.

// https://leetcode.com/problems/sliding-window-maximum/
namespace LocalLeet
{
    public class Q239
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 0)
            {
                return new int[0];
            }
            // maintain a LinkedList in c#, every step:
            // 1. remove one element from left(first)
            // 2. before add new element to right (last), pop all the elements from right and left that
            //    are smaller than the new one, because they have no chance to be biggest
            int[] answer = new int[nums.Length - k + 1];
            var list = new LinkedList<Tuple<int, int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Count > 0 && list.First.Value.Item2 == (i - k))
                {
                    list.RemoveFirst();
                }
                while (list.Count > 0 && list.Last.Value.Item1 < nums[i])
                {
                    list.RemoveLast();
                }
                while (list.Count > 0 && list.First.Value.Item1 < nums[i])
                {
                    list.RemoveFirst();
                }
                if (i - k + 1 >= 0)
                {
                    if (list.Count == 0)
                    {
                        answer[i - k + 1] = nums[i];
                    }
                    else
                    {
                        answer[i - k + 1] = Math.Max(list.Last.Value.Item1, list.First.Value.Item1);
                    }
                }
                list.AddLast(Tuple.Create(nums[i], i));
            }
            return answer;
        }

        [Fact]
        public void Q239_SlidingWindowMaximum()
        {
            TestHelper.Run(input => TestHelper.Serialize(MaxSlidingWindow(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
