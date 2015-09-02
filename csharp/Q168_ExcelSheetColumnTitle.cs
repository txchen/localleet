using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a positive integer, return its corresponding column title as appear in an Excel sheet.
//
// For example:
//
//     1 -> A
//     2 -> B
//     3 -> C
//     ...
//     26 -> Z
//     27 -> AA
//     28 -> AB

// https://leetcode.com/problems/excel-sheet-column-title/
namespace LocalLeet
{
    public class Q168
    {
        public String ConvertToTitle(int n)
        {
            string s = "";
            while (n > 0)
            {
                s = (char)((int)'A' + (n - 1)  % 26) + s;
                n = (n-1) / 26;
            }
            return s;
        }

        [Fact]
        public void Q168_ExcelSheetColumnTitle()
        {
            TestHelper.Run(input => "\"" + ConvertToTitle(input.EntireInput.ToInt()) + "\"");
        }
    }
}
