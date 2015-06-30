using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace LocalLeet
{
    public class CaseData
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string Expected { get; set; }
    }

    public class CaseInput
    {
        private string[] _inputParameters;

        public CaseInput(string s)
        {
            _inputParameters = s.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string this[int index]
        {
            get { return _inputParameters[index]; }
        }
    }

    public class TestHelper
    {
        public static void Run(Func<CaseInput, string> testAction,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            Func<CaseInput, string, bool> specialAssertAction = null)
        {
            string callingFileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            string callingQuestion = callingFileName.Split('_')[0];
            Console.WriteLine("**** Judging for question: {0} ****", callingFileName);

            // read from case data
            string caseFileName = "../cases/" + callingQuestion + ".json";
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(caseFileName))
            {
                Assert.True(false,
                    String.Format("Case data file: '{0}' does not exist, please create the data file", caseFileName));
            }

            var testCases = JsonConvert.DeserializeObject<CaseData[]>(File.ReadAllText(caseFileName));
            if (testCases.Length == 0)
            {
                Assert.True(false, "Cannot get test cases from the data file, please check your data file");
            }

            int passedCount = 0;
            var sw = Stopwatch.StartNew();
            foreach (var testCase in testCases)
            {
                var input = new CaseInput(testCase.Input);
                string result = testAction(input);
                bool casePassed = true;
                if (specialAssertAction != null)
                {
                    casePassed = specialAssertAction(input, testCase.Expected);
                }
                else
                {
                    casePassed = result == testCase.Expected;
                }

                if (casePassed)
                {
                    passedCount += 1;
                }
                else
                {
                    Console.WriteLine("!! case failed:");
                    Console.WriteLine("      input: " + testCase.Input);
                    Console.WriteLine("   expected: " + testCase.Expected);
                    Console.WriteLine("     result: " + result);
                    break;
                }
            }
            Console.WriteLine("{0} of {1} cases passed.\tDuration: {2}ms\n",
                passedCount, testCases.Length, sw.ElapsedMilliseconds);
            Assert.Equal(testCases.Length, passedCount);
        }
        
        public static string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
