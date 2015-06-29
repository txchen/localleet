using System;
using System.Collections.Generic;
using System.Linq;

// Given a digit string, return all possible letter combinations that the number could represent.

// A mapping of digit to letters (just like on the telephone buttons) is given below.

// Input:Digit string "23"
// Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

namespace LocalLeet
{
    public class Q017_LetterCombinationsofaPhoneNumber
    {
        Dictionary<char, char[]> dict = new Dictionary<char, char[]>() {
            {'2', "abc".ToArray()},
            {'3', "def".ToArray()},
            {'4', "ghi".ToArray()},
            {'5', "jkl".ToArray()},
            {'6', "mno".ToArray()},
            {'7', "pqrs".ToArray()},
            {'8', "tuv".ToArray()},
            {'9', "wxyz".ToArray()},
        };
        public string[] LetterCombinations(string digits)
        {
            List<string> answer = new List<string>() { "" };
            foreach (var c in digits)
            {
                List<string> newAnswer = new List<string>();
                foreach (var old in answer)
                {
                    foreach (var cc in dict[c])
                    {
                        newAnswer.Add(old + cc);
                    }
                }
                answer = newAnswer;
            }
            return answer.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LetterCombinations(input.Deserialize()));
        }

        [Fact]
        public void Q017_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q017_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
