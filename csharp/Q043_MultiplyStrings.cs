using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given two numbers represented as strings, return multiplication of the numbers as a string.

// Note: The numbers can be arbitrarily large and are non-negative.

namespace LocalLeet
{
    public class Q043
    {
        public string Multiply(string num1, string num2)
        {
            int[] numA = num1.Select(c => int.Parse(c.ToString())).ToArray();
            int[] numB = num2.Select(c => int.Parse(c.ToString())).ToArray();
            int[] answer = new int[num1.Length + num2.Length];
            for (int j = numB.Length - 1; j >= 0; j--)
            {
                int carry = 0;
                for (int i = numA.Length - 1; i >= 0; i--)
                {
                    int tmp = numA[i] * numB[j] + carry + answer[i + j + 1];
                    carry = tmp / 10;
                    answer[i + j + 1] = tmp % 10;
                }
                if (carry > 0)
                {
                    answer[j] = carry;
                }
            }
            string res = String.Join("", answer.Select(i => i.ToString())).TrimStart('0');
            return res == String.Empty ? "0" : res;
        }

        [Fact]
        public void Q043_MultiplyStrings()
        {
            TestHelper.Run(input =>
                "\"" + Multiply(input[0].Deserialize(), input[1].Deserialize()) + "\"");
        }
    }
}
