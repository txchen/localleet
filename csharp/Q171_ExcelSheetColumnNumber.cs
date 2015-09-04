using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a column title as appear in an Excel sheet, return its corresponding column number.
//
// For example:
//
//     A -> 1
//     B -> 2
//     C -> 3
//     ...
//     Z -> 26
//     AA -> 27
//     AB -> 28

// https://leetcode.com/problems/excel-sheet-column-number/
namespace LocalLeet
{
    public class Q171
    {
        public int TitleToNumber(string s)
        {
            int answer = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int n = c - 'A' + 1;
                answer = answer * 26 + n;
            }
            return answer;
        }

        [Fact]
        public void Q171_ExcelSheetColumnNumber()
        {
            TestHelper.Run(input => TitleToNumber(input.EntireInput.Deserialize()).ToString());
        }
    }
}
