using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
//
// push(x) -- Push element x onto stack.
// pop() -- Removes the element on top of the stack.
// top() -- Get the top element.
// getMin() -- Retrieve the minimum element in the stack.

// https://leetcode.com/problems/min-stack/
namespace LocalLeet
{
    public class Q155
    {
        // implement this class
        public class MinStack
        {
            private Stack<int> data = new Stack<int>();
            private Stack<int> minData = new Stack<int>();
            public void Push(int x)
            {
                data.Push(x);
                if (minData.Count == 0)
                {
                    minData.Push(x);
                }
                else
                {
                    minData.Push(Math.Min(x, minData.Peek()));
                }
            }

            public void Pop()
            {
                data.Pop();
                minData.Pop();
            }

            public int Top()
            {
                return data.Peek();
            }

            public int GetMin()
            {
                return minData.Peek();
            }
        }

        [Fact]
        public void Q155_MinStack()
        {
            // {"input":"push(-2),push(0),push(-1),getMin,top,pop,getMin","expected":"[-2,-1,-2]"},
            TestHelper.Run(input => {
                var stk = new MinStack();
                List<int> output = new List<int>();
                input.EntireInput.Split(',').ToList().ForEach(c => {
                    if (c.StartsWith("push"))
                    {
                        stk.Push(int.Parse(c.Substring(5).TrimEnd(')')));
                    }
                    else if (c == "getMin")
                    {
                        output.Add(stk.GetMin());
                    }
                    else if (c == "top")
                    {
                        output.Add(stk.Top());
                    }
                    else if (c == "pop")
                    {
                        stk.Pop();
                    }
                });
                return TestHelper.Serialize(output.ToArray());
            });
        }
    }
}
