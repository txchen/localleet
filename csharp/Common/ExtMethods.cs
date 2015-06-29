using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LocalLeet
{
    public static class Ext
    {
        public static string[] ToStringArray(this string s)
        {
            return JsonConvert.DeserializeObject<string[]>(s);
        }

        public static string[][] ToStringArrayArray(this string s)
        {
            return JsonConvert.DeserializeObject<string[][]>(s);
        }

        public static int[] ToIntArray(this string s)
        {
            return JsonConvert.DeserializeObject<int[]>(s);
        }

        public static int[][] ToIntArrayArray(this string s)
        {
            return JsonConvert.DeserializeObject<int[][]>(s);
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        public static double ToDouble(this string s)
        {
            return double.Parse(s);
        }
    }
}
