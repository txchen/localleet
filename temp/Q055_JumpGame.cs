using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array of non-negative integers, you are initially positioned at the first index of the array.

// Each element in the array represents your maximum jump length at that position.
// Determine if you are able to reach the last index.

// For example:
// A = [2,3,1,1,4], return true.
// A = [3,2,1,0,4], return false.

namespace LocalLeet
{
    public class Q055
    {
        public bool CanJump(int[] input)
        {
            int currentFarest = 0;
            int previousFarest = -1;
            while (true)
            {
                int nextFarest = currentFarest;
                for (int i = previousFarest + 1; i <= currentFarest; i++)
                {
                    int temp = i + input[i];
                    if (temp >= input.Length - 1)
                    {
                        return true;
                    }
                    nextFarest = Math.Max(nextFarest, temp);
                }
                if (nextFarest == currentFarest)
                {
                    return false;
                }
                previousFarest = currentFarest;
                currentFarest = nextFarest;
            }
        }

        public string SolveQuestion(string input)
        {
            return CanJump(input[0].ToIntArray()).ToString().ToLower();
        }

        [Fact]
        public void Q055_JumpGame()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
