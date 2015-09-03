using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a positive integer, return its corresponding column title as appear in an Excel sheet.
//
// For example:
//
//     1 -> A
//     2 -> B
//     3 -> C
//     ...
//     26 -> Z
//     27 -> AA
//     28 -> AB

// https://leetcode.com/problems/excel-sheet-column-title/
namespace LocalLeet
{
    public class Q169
    {
        public int MajorityElement(int[] num)
        {
            int answer = 0;
            int count = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (answer != num[i])
                {
                    count = count == 0 ? 0 : count -1;
                    if (count == 0)
                    {
                        count = 1;
                        answer = num[i];
                    }
                }
                else
                {
                    answer = num[i];
                    count++;
                }
            }
            return answer;
        }

        [Fact]
        public void Q169_MajorityElement()
        {
            TestHelper.Run(input => MajorityElement(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
