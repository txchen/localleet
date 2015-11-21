using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Find the total area covered by two rectilinear rectangles in a 2D plane.
//
// Each rectangle is defined by its bottom left corner and top right corner as shown in the figure.
//
// Assume that the total area is never beyond the maximum possible value of int.

// https://leetcode.com/problems/rectangle-area/
namespace LocalLeet
{
    public class Q223
    {
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int answer = 0;
            answer += (C - A) * (D - B);
            answer += (G - E) * (H - F);
            // minus overlap
            int xOverlap = 0;
            if (E <= A && A <= G)
            {
                xOverlap = C <= G ? (C - A) : (G - A);
            }
            else if (A <= E && E <= C)
            {
                xOverlap = G <= C ? (G - E) : (C - E);
            }
            if (xOverlap > 0)
            {
                int yOverlap = 0;
                if (F <= B && B <= H)
                {
                    yOverlap = D <= H ? (D - B) : (H - B);
                }
                else if (B <= F && F <= D)
                {
                    yOverlap = H <= D ? (H - F) : (D - F);
                }
                if (yOverlap > 0)
                {
                    answer -= xOverlap * yOverlap;
                }
            }
            return answer;
        }

        [Fact]
        public void Q223_RectangleArea()
        {
            TestHelper.Run(input => ComputeArea(input[0].ToInt(),
                input[1].ToInt(), input[2].ToInt(), input[3].ToInt(), input[4].ToInt(),
                input[5].ToInt(), input[6].ToInt(), input[7].ToInt()).ToString());
        }
    }
}
