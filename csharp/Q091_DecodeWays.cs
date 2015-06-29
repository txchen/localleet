using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// A message containing letters from A-Z is being encoded to numbers using the following mapping:

// 'A' -> 1
// 'B' -> 2
// ...
// 'Z' -> 26
// Given an encoded message containing digits, determine the total number of ways to decode it.

// For example,
// Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

// The number of ways decoding "12" is 2.

namespace LocalLeet
{
    
    public class Q091_DecodeWays
    {
        public int NumDecodings(string s)
        {
            int[] answer = new int[s.Length + 1]; // answer[i] means s.substring(0, i)'s decode ways
            if (s == "" || s[0] == '0')
            {
                return 0;
            }
            answer[0] = 1;
            for (int i = 1; i <= s.Length; i++)
            {
                int currentAnswer = 0;
                if (s[i - 1] != '0') // can take 1 char
                {
                    currentAnswer += answer[i - 1];
                }
                if (i > 1)
                {
                    if (s[i - 2] == '1' || (s[i - 2] == '2' && int.Parse(s[i - 1].ToString()) <= 6))
                    {
                        currentAnswer += answer[i - 2];
                    }
                }
                answer[i] = currentAnswer;
            }

            return answer[s.Length];
        }

        public string SolveQuestion(string input)
        {
            return NumDecodings(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q091_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q091_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
