using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.

// Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].

// The largest rectangle is shown in the shaded area, which has area = 10 unit.

// For example,
// Given height = [2,1,5,6,2,3],
// return 10.

// https://leetcode.com/problems/largest-rectangle-in-histogram/
namespace LocalLeet
{
    public class Q084
    {
        public int LargestRectangleArea(int[] height)
        {
            // suppose answer's height is height[i], means answer = h[i] * (1 + Li + Ri)
            // Li = how many adjscent left bars are higher than h[i]
            // Ri = how many adjscent right bars are higher than h[i]
            int[] answer = new int[height.Length];
            // first pass, from left to right, store Li into answer[i]
            Stack<int> stk = new Stack<int>(); // store index;
            stk.Push(0);
            for (int i = 1; i < height.Length; i++)
            {
                // pop until peek() is smaller than h[i]
                while (stk.Count > 0 && height[stk.Peek()] >= height[i])
                {
                    stk.Pop();
                }
                answer[i] += i - (stk.Count > 0 ? stk.Peek() : -1) - 1;
                stk.Push(i);
            }
            // second pass, from right to left, store Ri into answer[i]
            stk.Clear();
            stk.Push(height.Length - 1);
            for (int i = height.Length - 2; i >= 0; i--)
            {
                // pop until peek() is smaller than h[i]
                while (stk.Count > 0 && height[stk.Peek()] >= height[i])
                {
                    stk.Pop();
                }
                answer[i] += (stk.Count > 0 ? stk.Peek() : height.Length) - i - 1;
                stk.Push(i);
            }
            int finalAnswer = 0;
            for (int i = 0; i < height.Length; i++)
            {
                finalAnswer = Math.Max(finalAnswer, (1 + answer[i]) * height[i]);
            }
            return finalAnswer;
        }

        [Fact]
        public void Q084_LargestRectangleinHistogram()
        {
            TestHelper.Run(input => LargestRectangleArea(input[0].ToIntArray()).ToString());
        }
    }
}
