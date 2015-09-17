using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Say you have an array for which the ith element is the price of a given stock on day i.
//
// Design an algorithm to find the maximum profit. You may complete at most k transactions.
//
// Note:
// You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
namespace LocalLeet
{
    public class Q188
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (k >= prices.Length / 2)
            {
                int answer = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i-1])
                    {
                        answer += prices[i] - prices[i-1];
                    }
                }
                return answer;
            }
            // dp
            int[,] dp = new int[k + 1, prices.Length+1];
            for (int i = 1; i <= k; i++ )
            {
                int leastLoss = prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    dp[i, j] = Math.Max(prices[j] - leastLoss, dp[i, j-1]);
                    leastLoss = Math.Min(leastLoss, prices[j] -dp[i-1, j-1]);
                }
            }
            return dp[k, prices.Length -1];
        }

        [Fact]
        public void Q188_BestTimeToBuyAndSellStockIV()
        {
            TestHelper.Run(input => MaxProfit(input[0].ToInt(), input[1].ToIntArray()).ToString());
        }
    }
}
