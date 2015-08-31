using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Compare two version numbers version1 and version2.
// If version1 > version2 return 1, if version1 < version2 return -1, otherwise return 0.
//
// You may assume that the version strings are non-empty and contain only digits and the . character.
// The . character does not represent a decimal point and is used to separate number sequences.
// For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.
//
// Here is an example of version numbers ordering:
//
// 0.1 < 1.1 < 1.2 < 13.37

// https://leetcode.com/problems/compare-version-numbers/
namespace LocalLeet
{
    public class Q165
    {
        public int CompareVersion(string version1, string version2)
        {
            string[] v1s = version1.Split('.');
            string[] v2s = version2.Split('.');
            int i = 0;
            for (; i < v1s.Length; i++)
            {
                int p1 = int.Parse(v1s[i]);
                int p2 = 0;
                if (i < v2s.Length)
                {
                    p2 = int.Parse(v2s[i]);
                }
                if (p1 != p2)
                {
                    return p1.CompareTo(p2);
                }
            }
            while (i < v2s.Length)
            {
                if (int.Parse(v2s[i]) > 0)
                {
                    return -1;
                }
                i++;
            }
            return 0;
        }

        [Fact]
        public void Q165_CompareVersionNumbers()
        {
            TestHelper.Run(input => CompareVersion(input[0].Deserialize(), input[1].Deserialize()).ToString());
        }
    }
}
