using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// The count-and-say sequence is the sequence of integers beginning as follows:
// 1, 11, 21, 1211, 111221, ...

// 1 is read off as "one 1" or 11.
// 11 is read off as "two 1s" or 21.
// 21 is read off as "one 2, then one 1" or 1211.

// Given an integer n, generate the nth sequence.

// Note: The sequence of integers will be represented as a string.

// https://leetcode.com/problems/count-and-say/
namespace LocalLeet
{
    public class Q038
    {
        public string CountAndSay(int n)
        {
            string s = "1";
            for (int i = 1; i < n; i++)
            {
                s = CountAndSay(s);
            }
            return s;
        }

        private string CountAndSay(string s)
        {
            StringBuilder sb = new StringBuilder();
            int read = 0;
            while (read < s.Length)
            {
                char currentValue = s[read];
                int nextRead = read;
                while (nextRead < s.Length && s[nextRead] == currentValue)
                {
                    nextRead++;
                }
                sb.Append((nextRead - read).ToString());
                sb.Append(currentValue.ToString());
                read = nextRead;
            }
            return sb.ToString();
        }

        [Fact]
        public void Q038_CountandSay()
        {
            TestHelper.Run(input =>
                "\"" + CountAndSay(input[0].ToInt()) + "\"");
        }
    }
}
