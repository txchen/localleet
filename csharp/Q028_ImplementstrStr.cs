using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement strStr().

// Returns a pointer to the first occurrence of needle in haystack, or null if needle is not part of haystack.

// https://leetcode.com/problems/implement-strstr/
namespace LocalLeet
{
    public class Q028
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

        [Fact]
        public void Q028_ImplementstrStr()
        {
            TestHelper.Run(input =>
                StrStr(input[0].Deserialize(), input[1].Deserialize()).SerializeString());
        }
    }
}
