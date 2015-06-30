using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// The set [1,2,3,��,n] contains a total of n! unique permutations.

// By listing and labeling all of the permutations in order,
// We get the following sequence (ie, for n = 3):

// "123"
// "132"
// "213"
// "231"
// "312"
// "321"
// Given n and k, return the kth permutation sequence.

// Note: Given n will be between 1 and 9 inclusive.

namespace LocalLeet
{
    public class Q060
    {
        public string GetPermutation(int n, int k)
        {
            string result = "";
            List<int> nums = Enumerable.Range(1, n).ToList();
            while (n > 0)
            {
                int countOfNextPerm = Factorial(n - 1);
                int index = (k - 1) / countOfNextPerm;
                result += nums[index];
                nums.RemoveAt(index); // remove the char, and continue
                k -= countOfNextPerm * index;
                n--;
            }
            return result;
        }

        public int Factorial(int n)
        {
            int res = 1;
            while (n > 0)
            {
                res *= n--;
            }
            return res;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + GetPermutation(input[0].ToInt(), input[1].ToInt()) + "\"";
        }

        [Fact]
        public void Q060_PermutationSequence()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
