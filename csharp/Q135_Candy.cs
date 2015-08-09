using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// There are N children standing in a line. Each child is assigned a rating value.
//
// You are giving candies to these children subjected to the following requirements:
// * Each child must have at least one candy.
// * Children with a higher rating get more candies than their neighbors.
//
// What is the minimum candies you must give?

// https://leetcode.com/problems/candy/
namespace LocalLeet
{
    public class Q135
    {
        public int Candy(int[] ratings)
        {
            int[] candies = new int[ratings.Length];
            candies[0] = 1;
            for (int i = 1; i< ratings.Length; i++)
            {
                if (ratings[i] > ratings[i -1])
                {
                    candies[i] = candies[i -1] +1;
                }
                else
                {
                    candies[i] = 1;
                }
            }
            for (int j = ratings.Length -2; j >= 0; j--)
            {
                if (ratings[j] > ratings[j+1])
                {
                    candies[j] = Math.Max(candies[j], candies[j+1] + 1);
                }
            }
            return candies.Sum(c => c);
        }

        [Fact]
        public void Q135_Candy()
        {
            TestHelper.Run(input => Candy(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
