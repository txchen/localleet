using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Say you have an array for which the ith element is the price of a given stock on day i.

// If you were only permitted to complete at most one transaction
// (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.

namespace LocalLeet
{
    public class Q121
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
            {
                return 0;
            }
            int lowest = prices[0];
            int answer = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < lowest)
                {
                    lowest = prices[i];
                }
                answer = Math.Max(answer, prices[i] - lowest);

            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return MaxProfit(input[0].ToIntArray()).ToString();
        }

        [Fact]
        public void Q121_BestTimetoBuyandSellStock()
        {
            TestHelper.Run(input => SolveQuestion(s));
        }
    }
}
