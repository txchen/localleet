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
// Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
//
// There may be multiple correct orders, you just need to return one of them. If it is impossible to finish all courses, return an empty array.
//
// For example:
//
// 2, [[1,0]]
// There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1]
//
// 4, [[1,0],[2,0],[3,1],[3,2]]
// There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0. So one correct course order is [0,1,2,3]. Another correct ordering is[0,2,1,3].
//
// Note:
// The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.

// https://leetcode.com/problems/course-schedule-ii/
namespace LocalLeet
{
    public class Q210
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // BFS topological sort
            var answer = new List<int>();
            var dependsOn = new Dictionary<int, List<int>>();
            int[] inDegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                dependsOn[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                dependsOn[prerequisites[i][1]].Add(prerequisites[i][0]);
                inDegree[prerequisites[i][0]] += 1;
            }
            Queue<int> sortQueue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    sortQueue.Enqueue(i);
                    answer.Add(i);
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
                        answer.Add(d);
                    }
                }
            }
            if (numCourses == 0)
            {
                return answer.ToArray();
            }
            return new int[0];
        }

        [Fact]
        public void Q210_CourseScheduleII()
        {
            TestHelper.Run(input => TestHelper.Serialize(FindOrder(input[0].ToInt(), input[1].ToIntArrayArray())));
        }
    }
}
