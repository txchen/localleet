using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Validate if a given string is numeric.

// Some examples:
// "0" => true
// " 0.1 " => true
// "abc" => false
// "1 a" => false
// "2e10" => true

// Note: It is intended for the problem statement to be ambiguous.
// You should gather all requirements up front before implementing one.

namespace LocalLeet
{
    public class Q065_ValidNumber
    {
        public bool IsNumber(string s)
        {
            s = s.Trim();
            var tokens = s.Split('e');
            if (tokens.Length > 2)
            {
                return false;
            }
            bool hasDot = false;
            return tokens.All(t =>
            {
                if (String.IsNullOrEmpty(t))
                {
                    return false;
                }
                if (!char.IsDigit(t[0]) && t[0] != '+' && t[0] != '-' && t[0] != '.')
                {
                    return false;
                }
                if (!char.IsDigit(t[t.Length - 1]) && t[t.Length - 1] != '.')
                {
                    return false;
                }
                if (t[0] == '-' || t[0] == '+')
                {
                    t = t.Substring(1);
                }
                int countOfDigit = 0;
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i] == '.')
                    {
                        if (hasDot)
                        {
                            return false;
                        }
                        hasDot = true;
                    }
                    else if (!char.IsDigit(t[i]))
                    {
                        return false;
                    }
                    else
                    {
                        countOfDigit++;
                    }
                }
                if (countOfDigit == 0)
                {
                    return false;
                }
                hasDot = true; // second part cannot have '.'
                return true;
            });
        }

        public string SolveQuestion(string input)
        {
            return IsNumber(input[0].Deserialize()).ToString().ToLower();
        }

        [Fact]
        public void Q065_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q065_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
