using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an absolute path for a file (Unix-style), simplify it.

// For example,
// path = "/home/", => "/home"
// path = "/a/./b/../../c/", => "/c"

// Corner Cases:
//  Did you consider the case where path = "/../"?
//  In this case, you should return "/".
//  Another corner case is the path might contain multiple slashes '/' together, such as "/home//foo/".
//  In this case, you should ignore redundant slashes and return "/home/foo".

// https://leetcode.com/problems/simplify-path/
namespace LocalLeet
{
    public class Q071
    {
        public string SimplifyPath(string path)
        {
            var parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<String> stk = new Stack<string>();
            foreach (var part in parts)
            {
                if (part == "..")
                {
                    if (stk.Count > 0)
                    {
                        stk.Pop();
                    }
                }
                else if (part != ".")
                {
                    stk.Push(part);
                }
            }
            return "/" + String.Join("/", stk.Select(s => s).Reverse());
        }

        [Fact]
        public void Q071_SimplifyPath()
        {
            TestHelper.Run(input => "\"" + SimplifyPath(input.EntireInput.Deserialize()) + "\"");
        }
    }
}
