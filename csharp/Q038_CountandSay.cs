using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// The count-and-say sequence is the sequence of integers beginning as follows:
// 1, 11, 21, 1211, 111221, ...

// 1 is read off as "one 1" or 11.
// 11 is read off as "two 1s" or 21.
// 21 is read off as "one 2, then one 1" or 1211.

// Given an integer n, generate the nth sequence.

// Note: The sequence of integers will be represented as a string.

namespace LocalLeet
{
    
    public class Q038_CountandSay
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

        public string SolveQuestion(string input)
        {
            return "\"" + CountAndSay(input.ToInt()) + "\"";
        }

        [TestMethod]
        public void Q038_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q038_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
