using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.
//
// Ensure that numbers within the set are sorted in ascending order.
//
// Example 1:
// Input: k = 3, n = 7
//
// Output:
// [[1,2,4]]
//
// Example 2:
// Input: k = 3, n = 9
//
// Output:
// [[1,2,6], [1,3,5], [2,3,4]]

// https://leetcode.com/problems/combination-sum-iii/
namespace LocalLeet
{
    public class Q216
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var result = new List<IList<int>>();
            Dfs(result, new List<int>(), k, n);
            return result;
        }

        private void Dfs(IList<IList<int>> result, IList<int> temp, int k, int n)
        {
            if (k == temp.Count && n == 0)
            {
                result.Add(new List<int>(temp));
                return;
            }
            if (temp.Count >= k)
            {
                return;
            }
            int currentMin = temp.Count > 0 ? temp[temp.Count - 1] + 1 : 1;
            for (int i = currentMin; i <= 9 && i <= n; i++)
            {
                temp.Add(i);
                Dfs(result, temp, k, n - i);
                temp.RemoveAt(temp.Count - 1);
            }
        }

        [Fact]
        public void Q216_CombinationSumIII()
        {
            TestHelper.Run(input => TestHelper.Serialize(CombinationSum3(input[0].ToInt(), input[1].ToInt())));
        }
    }
}
