using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

// For example,
// Given [100, 4, 200, 1, 3, 2],
// The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

// Your algorithm should run in O(n) complexity.

namespace LocalLeet
{
    public class Q128_LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] num)
        {
            // put all the number in a hashset, then detect for each number
            HashSet<int> hs = new HashSet<int>(num);
            int answer = 1;
            foreach (var n in num)
            {
                if (hs.Remove(n))
                {
                    int detect = n;
                    int tempAnswer = 1;
                    while (hs.Remove(++detect))
                    {
                        tempAnswer++;
                    }
                    detect = n;
                    while (hs.Remove(--detect))
                    {
                        tempAnswer++;
                    }
                    answer = Math.Max(answer, tempAnswer);
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return LongestConsecutive(input.ToIntArray()).ToString();
        }

        [Fact]
        public void Q128_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q128_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
