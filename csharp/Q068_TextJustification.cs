using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array of words and a length L,
// format the text such that each line has exactly L characters and is fully (left and right) justified.

// You should pack your words in a greedy approach;
// that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary
// so that each line has exactly L characters.

// Extra spaces between words should be distributed as evenly as possible.
// If the number of spaces on a line do not divide evenly between words,
// the empty slots on the left will be assigned more spaces than the slots on the right.

// For the last line of text, it should be left justified and no extra space is inserted between words.

// For example,
// words: ["This", "is", "an", "example", "of", "text", "justification."]
// L: 16.

// Return the formatted lines as:
// [
//   "This    is    an",
//   "example  of text",
//   "justification.  "
// ]
// Note: Each word is guaranteed not to exceed L in length.
// Corner Cases:
//   A line other than the last line might contain only one word. What should you do in this case?
//   In this case, that line should be left-justified.

namespace LocalLeet
{

    public class Q068_TextJustification
    {
        public string[] FullJustify(string[] words, int length)
        {
            List<string> answer = new List<string>();
            int currentLength = -1;
            List<string> currentLine = new List<string>();
            foreach (var word in words)
            {
                currentLength = currentLength + 1 + word.Length;
                if (currentLength > length)
                {
                    PrintNewLine(currentLine, length, answer);
                    currentLength = word.Length;
                }
                currentLine.Add(word);
            }
            if (currentLine.Count > 0)
            {
                answer.Add(String.Join(" ", currentLine.ToArray()));
            }

            return answer.Select(a => a.PadRight(length)).ToArray();
        }

        private void PrintNewLine(List<String> words, int length, List<String> answer)
        {
            int spaceCount = words.Count - 1;
            int totalSpace = length - words.Sum(w => w.Length);
            StringBuilder sb = new StringBuilder();
            sb.Append(words[0]);
            for (int i = 1; i < words.Count; i++)
            {
                int spaceLength = totalSpace / spaceCount;
                if (i <= totalSpace % spaceCount)
                {
                    spaceLength++;
                }
                sb.Append(new String(' ', spaceLength));
                sb.Append(words[i]);
            }
            answer.Add(sb.ToString());
            words.Clear();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(FullJustify(input.GetToken(0).ToStringArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q068_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q068_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
