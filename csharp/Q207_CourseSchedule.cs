using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// There are a total of n courses you have to take, labeled from 0 to n - 1.
//
// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
//
// Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
//
// For example:
//
// 2, [[1,0]]
// There are a total of 2 courses to take. To take course 1 you should have finished course 0. So it is possible.
//
// 2, [[1,0],[0,1]]
// There are a total of 2 courses to take. To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

// https://leetcode.com/problems/course-schedule/
namespace LocalLeet
{
    public class Q207
    {
        public bool CanFinishImpl(int numCourses, int[][] prerequisites)
        {
            // BFS topological sort
            var dependsOn = new Dictionary<int, List<int>>();
            int[] inDegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                dependsOn[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                dependsOn[prerequisites[i][0]].Add(prerequisites[i][1]);
                inDegree[prerequisites[i][1]] += 1;
            }
            Queue<int> sortQueue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    sortQueue.Enqueue(i);
                }
            }
            while (sortQueue.Count > 0)
            {
                var c = sortQueue.Dequeue();
                numCourses -= 1;
                foreach (int d in dependsOn[c])
                {
                    if (--inDegree[d] == 0)
                    {
                        sortQueue.Enqueue(d);
                    }
                }
            }
            return numCourses == 0;
        }

        [Fact]
        public void Q207_CourseSchedule()
        {
            TestHelper.Run(input => CanFinishImpl(input[0].ToInt(), input[1].ToIntArrayArray()).ToString().ToLower());
        }
    }
}
