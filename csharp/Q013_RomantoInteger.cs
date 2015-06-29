using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a roman numeral, convert it to an integer.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LocalLeet
{

    public class Q013_RomantoInteger
    {
        static Dictionary<string, int> dict = null;
        Q012_IntegertoRoman itr = new Q012_IntegertoRoman();
        int RomanToInt(string s)
        {
            if (dict == null)
            {
                dict = new Dictionary<string, int>();
                for (int i = 1; i < 4000; i++)
                {
                    dict.Add(itr.IntToRoman(i), i);
                }
            }
            return dict[s];
        }

        public string SolveQuestion(string input)
        {
            return RomanToInt(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q013_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q013_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
