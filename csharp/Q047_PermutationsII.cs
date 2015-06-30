using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a collection of numbers that might contain duplicates, return all possible unique permutations.

// For example,
// [1,1,2] have the following unique permutations:
// [1,1,2], [1,2,1], and [2,1,1].

// https://leetcode.com/problems/permutations-ii/
namespace LocalLeet
{
    public class Q047
    {
        public int[][] PermuteUnique(int[] num)
        {
            num = num.OrderBy(i => i).ToArray();
            List<int[]> answer = new List<int[]>();
            answer.Add(num.ToArray());
            while (NextPermute(num))
            {
                answer.Add(num.ToArray());
            }
            return answer.ToArray();
        }

        private bool NextPermute(int[] num)
        {
            // step 1, find first descending num from right to left
            for (int i = num.Length - 2; i >= 0; i--)
            {
                if (num[i]< num[i+1])
                {
                    // step 2, find first one larger than num[i] from right to left
                    int j = num.Length -1;
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

        [Fact]
        public void Q047_PermutationsII()
        {
            TestHelper.Run(input => TestHelper.Serialize(PermuteUnique(input[0].ToIntArray())));
        }
    }
}
