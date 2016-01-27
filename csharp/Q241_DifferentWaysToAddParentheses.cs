using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators. The valid operators are +, - and *.
//
// Example 1
// Input: "2-1-1".
//
// ((2-1)-1) = 0
// (2-(1-1)) = 2
// Output: [0, 2]
//
// Example 2
// Input: "2*3-4*5"
//
// (2*(3-(4*5))) = -34
// ((2*3)-(4*5)) = -14
// ((2*(3-4))*5) = -10
// (2*((3-4)*5)) = -10
// (((2*3)-4)*5) = 10
// Output: [-34, -14, -10, -10, 10]

// https://leetcode.com/problems/different-ways-to-add-parentheses/
namespace LocalLeet
{
    public class Q241
    {
        public IList<int> DiffWaysToCompute(string input)
        {
            var result = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (c == '+' || c == '-' || c == '*')
                {
                    var leftParts = DiffWaysToCompute(input.Substring(0, i));
                    var rightParts = DiffWaysToCompute(input.Substring(i + 1));
                    foreach (var l in leftParts)
                    {
                        foreach (var r in rightParts)
                        {
                            switch (c)
                            {
                                case '+':
                                    result.Add(l + r);
                                    break;
                                case '-':
                                    result.Add(l - r);
                                    break;
                                case '*':
                                default:
                                    result.Add(l * r);
                                    break;
                            }
                        }
                    }
                }
            }
            if (result.Count == 0)
            {
                result.Add(int.Parse(input));
            }
            return result.OrderBy(i => i).ToList();
        }

        [Fact]
        public void Q241_DifferentWaysToAddParentheses()
        {
            TestHelper.Run(input => TestHelper.Serialize(DiffWaysToCompute(input.EntireInput.Deserialize())));
        }
    }
}
