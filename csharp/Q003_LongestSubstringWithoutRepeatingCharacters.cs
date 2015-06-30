using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string, find the length of the longest substring without repeating characters.
// For example, the longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3.
// For "bbbbb" the longest substring is "b", with the length of 1.

namespace LocalLeet
{
    public class Q003
    {
        int LengthOfLongestSubstring(string s)
        {
            char[] charArr = s.ToArray();
            int result = 0;
            int left = 0;
            int right = 0;
            HashSet<char> set = new HashSet<char>();
            while (right < s.Length)
            {
                if (set.Add(charArr[right])) // no dup
                {
                    result = Math.Max(result, right - left + 1);
                }
                else
                {
                    while (true)
                    {
                        if (charArr[left] != charArr[right])
                        {
                            set.Remove(charArr[left]);
                            left++;
                        }
                        else
                        {
                            left++;
                            break;
                        }
                    }
                }
                right++;
            }
            return result;
        }

        [Fact]
        public void Q003_LongestSubstringWithoutRepeatingCharacters()
        {
            TestHelper.Run(input => LengthOfLongestSubstring(input[0].Deserialize()).ToString());
        }
    }
}
