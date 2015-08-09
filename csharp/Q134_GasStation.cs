using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// There are N gas stations along a circular route, where the amount of gas at station i is gas[i].
//
// You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). You begin the journey with an empty tank at one of the gas stations.
//
// Return the starting gas station's index if you can travel around the circuit once, otherwise return -1.
//
// Note:
// The solution is guaranteed to be unique.

// https://leetcode.com/problems/gas-station/
namespace LocalLeet
{
    public class Q134
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int answer = 0;
            int minTotalDiff = int.MaxValue;
            int totalDiff = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                totalDiff += gas[i] - cost[i];
                if (totalDiff < minTotalDiff)
                {
                    minTotalDiff = totalDiff;
                    answer = i + 1;
                }
            }
            if (totalDiff < 0)
            {
                return -1;
            }
            return answer % gas.Length;
        }

        [Fact]
        public void Q134_GasStation()
        {
            TestHelper.Run(input => CanCompleteCircuit(input[0].ToIntArray() , input[1].ToIntArray()).ToString());
        }
    }
}
