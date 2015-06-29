using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a collection of numbers, return all possible permutations.

// For example,
// [1,2,3] have the following permutations:
// [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].

namespace LocalLeet
{
    public class Q046_Permutations
    {
        public int[][] Permute(int[] num)
        {
            List<int[]> answer = new List<int[]>();
            int[] indexes = Enumerable.Range(0, num.Length).ToArray();
            answer.Add(indexes.Select(i => num[i]).ToArray());
            while (NextPermute(indexes))
            {
                answer.Add(indexes.Select(i => num[i]).ToArray());
            }
            return answer.ToArray();
        }

        private bool NextPermute(int[] num)
        {
            // step 1, find first descending num from right to left
            for (int i = num.Length - 2; i >= 0; i--)
            {
                if (num[i] < num[i + 1])
                {
                    // step 2, find first one larger than num[i] from right to left
                    int j = num.Length - 1;
                    while (num[i] >= num[j])
                    {
                        j--;
                    }
                    // step 3, swap i and j
                    int tmp = num[i];
                    num[i] = num[j];
                    num[j] = tmp;
                    // step 4, reverse i+1..end
                    int left = i + 1;
                    int right = num.Length - 1;
                    while (left < right)
                    {
                        int t = num[left];
                        num[left] = num[right];
                        num[right] = t;
                        left++;
                        right--;
                    }
                    return true;
                }
            }
            return false;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Permute(input.ToIntArray()));
        }

        [Fact]
        public void Q046_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q046_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
