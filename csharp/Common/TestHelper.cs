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
        private string _s;

        public CaseInput(string s)
        {
            _s = s;
        }

        public string EntireInput
        {
            get { return _s; }
        }

        public string this[int index]
        {
            get { return _s.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[index]; }
        }
    }

    public class TestHelper
    {
        public static void Run(Func<CaseInput, string> testAction,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            Func<string, string, bool> specialAssertAction = null)
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
                    casePassed = specialAssertAction(result, testCase.Expected);
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
                    Console.WriteLine("!! case no.{0} failed:", passedCount + 1);
                    Console.WriteLine("      input: " + testCase.Input);
                    Console.WriteLine("   expected: " + testCase.Expected);
                    Console.WriteLine("     result: " + result);
                    break;
                }
            }
            Console.WriteLine("{0,5} of {1,5} cases passed.\tDuration: {2}ms\n",
                passedCount, testCases.Length, sw.ElapsedMilliseconds);
            Assert.Equal(testCases.Length, passedCount);
        }

        public static string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }

        public static bool AreIntArrayArraysEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            int[][] a1 = s1.ToIntArrayArray();
            int[][] a2 = s2.ToIntArrayArray();
            a1 = a1.OrderBy(a => a.Length).ThenBy(a => String.Join("", a)).ToArray();
            a2 = a2.OrderBy(a => a.Length).ThenBy(a => String.Join("", a)).ToArray();
            return TestHelper.Serialize(a1) == TestHelper.Serialize(a2);
        }

        public static bool AreStringArrayArraysEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArrayArray().ToList();
            var arrActual = actual.ToStringArrayArray().ToList();
            arrExp.Sort(CompareStringArray);
            arrActual.Sort(CompareStringArray);
            return TestHelper.Serialize(arrExp.ToArray()) ==
                TestHelper.Serialize(arrActual.ToArray());
        }

        private static int CompareStringArray(string[] arr1, string[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                int res = arr1[i].CompareTo(arr2[i]);
                if (res != 0)
                {
                    return res;
                }
            }
            return 0;
        }

        public static bool AreStringArraysEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArray().OrderBy(s => s).ToArray();
            var arrActual = actual.ToStringArray().OrderBy(s => s).ToArray();
            if (arrExp.Length != arrActual.Length)
            {
                return false;
            }
            for (int i = 0; i < arrExp.Length; i++)
            {
                if (arrExp[i] != arrActual[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
