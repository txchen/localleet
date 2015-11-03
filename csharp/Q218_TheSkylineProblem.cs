using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. Now suppose you are given the locations and height of all the buildings as shown on a cityscape photo (Figure A), write a program to output the skyline formed by these buildings collectively (Figure B).
//
// The geometric information of each building is represented by a triplet of integers [Li, Ri, Hi], where Li and Ri are the x coordinates of the left and right edge of the ith building, respectively, and Hi is its height. It is guaranteed that 0 ≤ Li, Ri ≤ INT_MAX, 0 < Hi ≤ INT_MAX, and Ri - Li > 0. You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.
//
// For instance, the dimensions of all buildings in Figure A are recorded as: [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .
//
// The output is a list of "key points" (red dots in Figure B) in the format of [ [x1,y1], [x2, y2], [x3, y3], ... ] that uniquely defines a skyline. A key point is the left endpoint of a horizontal line segment. Note that the last key point, where the rightmost building ends, is merely used to mark the termination of the skyline, and always has zero height. Also, the ground in between any two adjacent buildings should be considered part of the skyline contour.
//
// For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].
//
// Notes:
//
// The number of buildings in any input list is guaranteed to be in the range [0, 10000].
// The input list is already sorted in ascending order by the left x position Li.
// The output list must be sorted by the x position.
// There must be no consecutive horizontal lines of equal height in the output skyline. For instance, [...[2 3], [4 5], [7 5], [11 5], [12 7]...] is not acceptable; the three lines of height 5 should be merged into one in the final output as such: [...[2 3], [4 5], [12 7], ...]

// https://leetcode.com/problems/the-skyline-problem/
namespace LocalLeet
{
    public class Q218
    {
        public IList<int[]> GetSkyline(int[,] buildings)
        {
            List<int[]> filteredBuildings = new List<int[]>();
            List<int> xPos = new List<int>();
            // firstly, remove the overlap/dead buildings
            for (int n = 0; n < buildings.GetLength(0); n++)
            {
                bool isDead = false;
                foreach (int[] b in filteredBuildings)
                {
                    // if height and right both smaller than existing buidling, it is dead.
                    if (buildings[n, 1] <= b[1] && buildings[n, 2] <= b[2])
                    {
                        isDead = true;
                        break;
                    }
                }
                if (!isDead)
                {
                    filteredBuildings.Add(new int[3] {buildings[n, 0], buildings[n, 1], buildings[n, 2]});
                    xPos.Add(buildings[n, 0]);
                    xPos.Add(buildings[n, 1]);
                }
            }
            xPos = xPos.Distinct().ToList();
            xPos.Sort();
            // now, go through each xPos, gen the result
            List<int[]> result = new List<int[]>();
            int lastHeight = 0;
            foreach (int x in xPos)
            {
                int newHeight = 0;
                foreach (int[] b in filteredBuildings)
                { // filteredBuildings sorted by left edges
                    if (b[0] > x)
                    { // building is at right side of the x, no need to check further
                        break;
                    }
                    if (b[0] <= x && x < b[1])
                    {
                        newHeight = Math.Max(newHeight, b[2]);
                    }
                }
                if (newHeight != lastHeight)
                {
                    result.Add(new int[2]{x, newHeight});
                    lastHeight = newHeight;
                }
            }
            return result;
        }

        [Fact]
        public void Q218_TheSkylineProblem()
        {
            TestHelper.Run(input => TestHelper.Serialize(GetSkyline(input.EntireInput.ToInt2DArray())));
        }
    }
}
