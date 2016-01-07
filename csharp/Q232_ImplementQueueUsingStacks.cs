using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Implement the following operations of a queue using stacks.
//
// push(x) -- Push element x to the back of queue.
// pop() -- Removes the element from in front of queue.
// peek() -- Get the front element.
// empty() -- Return whether the queue is empty.
// Notes:
// You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
// Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque (double-ended queue), as long as you use only standard operations of a stack.
// You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).

// https://leetcode.com/problems/implement-queue-using-stacks/
namespace LocalLeet
{
    public class Q232
    {
        public class Queue
        {
            private Stack<int> _stk1 = new Stack<int>();
            private Stack<int> _stk2 = new Stack<int>();
            // Push element x to the back of queue.
            public void Push(int x)
            {
                while (_stk2.Count > 0)
                {
                    _stk1.Push(_stk2.Pop());
                }
                _stk1.Push(x);
            }

            // Removes the element from front of queue.
            public void Pop()
            {
                while (_stk1.Count > 0)
                {
                    _stk2.Push(_stk1.Pop());
                }
                _stk2.Pop();
            }

            // Get the front element.
            public int Peek()
            {
                while (_stk1.Count > 0)
                {
                    _stk2.Push(_stk1.Pop());
                }
                return _stk2.Peek();
            }

            // Return whether the queue is empty.
            public bool Empty()
            {
                return (_stk1.Count + _stk2.Count) == 0;
            }
        }

        [Fact]
        public void Q232_ImplementQueueUsingStacks()
        {
            // "input":"push(1),push(2),peek,pop,peek,pop,empty","expected":"[1,2,true]"
            TestHelper.Run(input => {
                Queue q = new Queue();
                List<object> output = new List<object>();
                input.EntireInput.Split(',').ToList().ForEach(token => {
                    if (token.StartsWith("push("))
                    {
                        q.Push(int.Parse(token.Substring(5).TrimEnd(')')));
                    }
                    else if (token == "pop")
                    {
                        q.Pop();
                    }
                    else if (token == "empty")
                    {
                        output.Add(q.Empty());
                    }
                    else if (token == "peek")
                    {
                        output.Add(q.Peek());
                    }
                });
                return TestHelper.Serialize(output.ToArray()).ToLower();
            });
        }
    }
}
