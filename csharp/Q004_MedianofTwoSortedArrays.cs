using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// There are two sorted arrays A and B of size m and n respectively. Find the median of the two sorted arrays.
// The overall run time complexity should be O(log (m+n)).

namespace LocalLeet
{

    public class Q004_MedianofTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] a, int[] b)
        {
            var c = a.Concat(b).OrderBy(i => i).ToArray();
            return (c[c.Length / 2] + c[(c.Length - 1) / 2]) / 2.0;
        }

        public string SolveQuestion(string input)
        {
            return FindMedianSortedArrays(input.GetToken(0).ToIntArray(), input.GetToken(1).ToIntArray()).ToString("F5");
        }

        [TestMethod]
        public void Q004_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q004_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
