using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement atoi to convert a string to an integer.

namespace LocalLeet
{

    public class Q008_StringtoInteger
    {
        public int Atoi(string str)
        {
            // This one is not interesting
            bool neg = false;
            str = str.Trim();
            int i = 0;
            if (str.StartsWith("-")) {
                neg = true;
                i = 1;
            }
            else if (str.StartsWith("+"))
            {
                i = 1;
            }
            long answer = 0;
            for (; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    answer = answer * 10 + long.Parse(str[i].ToString());
                    if (answer > int.MaxValue)
                    {
                        return neg ? int.MinValue : int.MaxValue;
                    }
                }
                else
                {
                    break;
                }
            }
            return (int)(neg ? 0 - answer: answer);
        }

        public string SolveQuestion(string input)
        {
            return Atoi(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q008_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q008_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
