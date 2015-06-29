using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
// (you may want to display this pattern in a fixed font for better legibility)

// P   A   H   N
// A P L S I I G
// Y   I   R
// And then read line by line: "PAHNAPLSIIGYIR"
// Write the code that will take a string and make this conversion given a number of rows:

// string convert(string text, int nRows);
// convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".

namespace LocalLeet
{

    public class Q006_ZigZagConversion
    {
        public string Convert(string s, int nRows)
        {
            if (nRows == 1)
            {
                return s;
            }
            // row i: i -> + 2 * (n -i -1) -> + 2 * i
            StringBuilder sb = new StringBuilder(s.Length);
            for (int r = 0; r < nRows; r++)
            {
                int hop = 2 * (nRows - 1);
                int currentHop = 2 * (nRows - r - 1);
                for (int i = r, j = 0; i < s.Length; j++)
                {
                    sb.Append(s[i]);
                    i = i + (currentHop == 0 ? hop : currentHop);
                    currentHop = hop - currentHop;
                }
            }
            return sb.ToString();
        }

        public string SolveQuestion(string input)
        {
            return "\"" + Convert(input.GetToken(0).Deserialize(), input.GetToken(1).ToInt()) + "\"";
        }

        [TestMethod]
        public void Q006_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q006_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
