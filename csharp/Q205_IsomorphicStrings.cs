using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given two strings s and t, determine if they are isomorphic.
//
// Two strings are isomorphic if the characters in s can be replaced to get t.
//
// All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.
//
// For example,
// Given "egg", "add", return true.
//
// Given "foo", "bar", return false.
//
// Given "paper", "title", return true.

// https://leetcode.com/problems/isomorphic-strings/
namespace LocalLeet
{
    public class Q205
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> dict1 = new Dictionary<char, char>();
            Dictionary<char, char> dict2 = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict1.ContainsKey(s[i]))
                {
                    dict1[s[i]] = t[i];
                }
                else if (dict1[s[i]] != t[i])
                {
                    return false;
                }

                if (!dict2.ContainsKey(t[i]))
                {
                    dict2[t[i]] = s[i];
                }
                else if (dict2[t[i]] != s[i])
                {
                    return false;
                }
            }
            return true;
        }

        private string Unescape(string txt)
        {
            if (string.IsNullOrEmpty(txt)) { return txt; }
            StringBuilder retval = new StringBuilder(txt.Length);
            for (int ix = 0; ix < txt.Length; )
            {
                int jx = txt.IndexOf('\\', ix);
                if (jx < 0 || jx == txt.Length - 1) jx = txt.Length;
                retval.Append(txt, ix, jx - ix);
                if (jx >= txt.Length) break;
                switch (txt[jx + 1])
                {
                    case 'n': retval.Append('\n'); break;  // Line feed
                    case 'r': retval.Append('\r'); break;  // Carriage return
                    case 't': retval.Append('\t'); break;  // Tab
                    case '\\': retval.Append('\\'); break; // Don't escape
                    case '"': retval.Append('"'); break;
                    default:                                 // Unrecognized, copy as-is
                        retval.Append('\\').Append(txt[jx + 1]); break;
                }
                ix = jx + 2;
            }
            return retval.ToString();
        }

        [Fact]
        public void Q205_IsomorphicStrings()
        {
            TestHelper.Run(input => IsIsomorphic(Unescape(input[0].Deserialize()),
                Unescape(input[1].Deserialize())).ToString().ToLower());
        }
    }
}
