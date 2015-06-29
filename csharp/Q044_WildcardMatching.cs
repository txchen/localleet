using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// '?' Matches any single character.
// '*' Matches any sequence of characters (including the empty sequence).

// The matching should cover the entire input string (not partial).

// The function prototype should be:
// bool isMatch(const char *s, const char *p)

// Some examples:
// isMatch("aa","a") ? false
// isMatch("aa","aa") ? true
// isMatch("aaa","aa") ? false
// isMatch("aa", "*") ? true
// isMatch("aa", "a*") ? true
// isMatch("ab", "?*") ? true
// isMatch("aab", "c*a*b") ? false

namespace LocalLeet
{
    
    public class Q044_WildcardMatching
    {
        public bool IsMatch(string input, string pattern)
        {
            // this can be non recursive
            int iIndex = 0;
            int pIndex = 0;
            int starIndex = -1;
            while (iIndex < input.Length)
            {
                if (pIndex >= pattern.Length) // no pattern left
                {
                    if (starIndex == -1)
                    {
                        return false; // previously no star, then no match
                    }
                    // start from previous star again, move input one step forward
                    int moveBack = pIndex - starIndex;
                    pIndex = pIndex - moveBack + 1;
                    iIndex = iIndex - moveBack + 2; // iIndex move one step forward, and try again
                    continue;
                }
                switch (pattern[pIndex])
                {
                    case '*':
                        // handle continous star
                        while (pIndex < pattern.Length && pattern[pIndex] == '*')
                        {
                            pIndex += 1;
                        }
                        starIndex = pIndex - 1;
                        break;
                    case '?':
                        iIndex++;
                        pIndex++;
                        break;
                    default:
                        if (pattern[pIndex] == input[iIndex])
                        {
                            iIndex++;
                            pIndex++;
                        }
                        else // not matching, back to previous star position
                        {
                            if (starIndex == -1)
                            {
                                return false;
                            }
                            int moveBack = pIndex - starIndex;
                            pIndex = pIndex - moveBack + 1;
                            iIndex = iIndex - moveBack + 2; // iIndex move one step forward, and try again
                        }
                        break;
                }
            }
            // remaining pattern can only be stars
            return pattern.Substring(pIndex).Trim('*').Length == 0;
        }

        public string SolveQuestion(string input)
        {
            return IsMatch(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q044_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q044_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
