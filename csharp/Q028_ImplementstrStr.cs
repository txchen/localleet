using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement strStr().

// Returns a pointer to the first occurrence of needle in haystack, or null if needle is not part of haystack.

namespace LocalLeet
{

    public class Q028_ImplementstrStr
    {
        public string StrStr(string haystack, string needle)
        {
            // should use KMP, but that's too complicated:
            // http://www.ruanyifeng.com/blog/2013/05/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm.html
            // summarize: build a prefix table first, then search
            if (String.IsNullOrEmpty(needle))
            {
                return haystack;
            }
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] == needle[j])
                    {
                        if (j == needle.Length - 1)
                        {
                            return haystack.Substring(i);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return null;
        }

        public string SolveQuestion(string input)
        {
            return StrStr(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).SerializeString();
        }

        [TestMethod]
        public void Q028_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q028_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
