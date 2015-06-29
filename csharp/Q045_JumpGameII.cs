using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given an array of non-negative integers, you are initially positioned at the first index of the array.

// Each element in the array represents your maximum jump length at that position.

// Your goal is to reach the last index in the minimum number of jumps.

// For example:
// Given array A = [2,3,1,1,4]

// The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)

namespace LocalLeet
{
    
    public class Q045_JumpGameII
    {
        public int Jump(int[] input)
        {
            // scan from end to start, is too slow. try from start
            if (input.Length == 1)
            {
                return 0;
            }
            int answer = 1;
            int previousFarest = 0;
            int previousNearest = 0;
            while (true)
            {
                int nextFarest = 0;
                for (int i = previousNearest; i <= previousFarest; i++)
                {
                    int jump = i + input[i];
                    if (jump >= input.Length - 1)
                    {
                        return answer;
                    }
                    nextFarest = Math.Max(nextFarest, jump);
                }
                answer++;
                previousNearest = previousFarest + 1;
                previousFarest = nextFarest;
            }
        }

        public string SolveQuestion(string input)
        {
            return Jump(input.ToIntArray()).ToString();
        }

        [TestMethod]
        public void Q045_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q045_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
