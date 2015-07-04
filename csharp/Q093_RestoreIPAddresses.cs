using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string containing only digits, restore it by returning all possible valid IP address combinations.

// For example:
// Given "25525511135",

// return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)

// https://leetcode.com/problems/restore-ip-addresses/
namespace LocalLeet
{
    public class Q093
    {
        public string[] RestoreIpAddresses(string s)
        {
            return RestoreIpAddresses(s, 4);
        }

        private string[] RestoreIpAddresses(string s, int count)
        {
            if (s.Length > count * 3 || s.Length < count)
            {
                return new string[0];
            }
            List<string> answer = new List<string>();
            // try take 1, 2, 3
            for (int j = 1; j <= 3; j++)
            {
                if (s.Length >= j)
                {
                    var current = s.Substring(0, j);
                    if (int.Parse(current) <= 255 && int.Parse(current).ToString() == current)
                    {
                        if (s.Length > j)
                        {
                            var remainings = RestoreIpAddresses(s.Substring(j), count - 1);
                            remainings.ToList().ForEach(r => answer.Add(current + "." + r));
                        }
                        if (s.Length == j && count == 1)
                        {
                            answer.Add(current);
                        }
                    }
                }
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q093_RestoreIPAddresses()
        {
            TestHelper.Run(input => TestHelper.Serialize(RestoreIpAddresses(input.EntireInput.Deserialize())));
        }
    }
}
