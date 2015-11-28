using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Implement the following operations of a stack using queues.
//
// push(x) -- Push element x onto stack.
// pop() -- Removes the element on top of the stack.
// top() -- Get the top element.
// empty() -- Return whether the stack is empty.
// Notes:
// You must use only standard operations of a queue -- which means only push to back, peek/pop from front, size, and is empty operations are valid.
// Depending on your language, queue may not be supported natively. You may simulate a queue by using a list or deque (double-ended queue), as long as you use only standard operations of a queue.
// You may assume that all operations are valid (for example, no pop or top operations will be called on an empty stack).

// https://leetcode.com/problems/implement-stack-using-queues/
namespace LocalLeet
{
    public class Q225
    {
        public class Stack
        {
            private Queue<int> _queue = new Queue<int>();
            // Push element x onto stack.
            public void Push(int x)
            {
                _queue.Enqueue(x);
            }

            // Removes the element on top of the stack.
            public void Pop()
            {
                int size = _queue.Count;
                for (int i = 0; i < size - 1; i++)
                {
                    _queue.Enqueue(_queue.Dequeue());
                }
                _queue.Dequeue();
            }

            // Get the top element.
            public int Top()
            {
                int size = _queue.Count;
                for (int i = 0; i < size - 1; i++)
                {
                    _queue.Enqueue(_queue.Dequeue());
                }
                int x = _queue.Dequeue();
                _queue.Enqueue(x);
                return x;
            }

            // Return whether the stack is empty.
            public bool Empty()
            {
                return _queue.Count == 0;
            }
        }

        [Fact]
        public void Q225_ImplementStackUsingQueues()
        {
            // "input":"push(1),push(2),push(3),top","expected":"[3]"
            TestHelper.Run(input => {
                Stack stk = new Stack();
                List<object> output = new List<object>();
                input.EntireInput.Split(',').ToList().ForEach(token => {
                    if (token.StartsWith("push("))
                    {
                        stk.Push(int.Parse(token.Substring(5).TrimEnd(')')));
                    }
                    else if (token == "pop")
                    {
                        stk.Pop();
                    }
                    else if (token == "empty")
                    {
                        output.Add(stk.Empty());
                    }
                    else if (token == "top")
                    {
                        output.Add(stk.Top());
                    }
                });
                return TestHelper.Serialize(output.ToArray());
            });
        }
    }
}
