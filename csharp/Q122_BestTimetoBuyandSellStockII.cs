using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Say you have an array for which the ith element is the price of a given stock on day i.

// Design an algorithm to find the maximum profit. You may complete as many transactions as you like
// (ie, buy one and sell one share of the stock multiple times).
// However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
namespace LocalLeet
{
    public class Q122
    {
        public int MaxProfitII(int[] prices)
        {
            if (prices.Length <= 1)
            {
                return 0;
            }
            int answer = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                answer += Math.Max(0, prices[i] - prices[i - 1]);
            }
            return answer;
        }

        [Fact]
        public void Q122_BestTimetoBuyandSellStockII()
        {
            TestHelper.Run(input => MaxProfitII(input[0].ToIntArray()).ToString());
        }
    }
}
