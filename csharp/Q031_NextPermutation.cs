using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

// If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

// The replacement must be in-place, do not allocate extra memory.

// Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
// 1,2,3 �� 1,3,2
// 3,2,1 �� 1,2,3
// 1,1,5 �� 1,5,1

namespace LocalLeet
{
    public class Q031_NextPermutation
    {
        public int[] NextPermutation(int[] num)
        {
            // next permutation rule: from end to start, find first s[y] > s[y-1]
            // then from end to s[y], find first number s[x] > s[y-1]
            // swap s[x], s[y-1], then reverse s[y]..end
            int reverseStart = 0;
            int reverseEnd = num.Length - 1;
            for (int y = num.Length -1; y >= 1; y--)
            {
                if (num[y] > num[y - 1])
                {
                    reverseStart = y;
                    for (int x = num.Length - 1; x >= y; x--)
                    {
                        if (num[x] > num[y - 1]) // swap
                        {
                            int tmp = num[x];
                            num[x] = num[y - 1];
                            num[y - 1] = tmp;
                            break;
                        }
                    }
                    break;
                }
            }
            while (reverseStart < reverseEnd)
            {
                int tmp = num[reverseStart];
                num[reverseStart] = num[reverseEnd];
                num[reverseEnd] = tmp;
                reverseStart++;
                reverseEnd--;
            }
            return num;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(NextPermutation(input.ToIntArray()));
        }

        [Fact]
        public void Q031_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q031_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
