using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'abbreviation' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING a
     *  2. STRING b
     */

    private static Dictionary<string,bool> _cache;

    public static string abbreviation(string a, string b)
    {
        _cache = new Dictionary<string,bool>();
        return recursiveMatch(a, b, a.Length -1, b.Length -1)
            ? "YES"
            : "NO";
    }
    
    private static bool recursiveMatch(string a, string b, int aIndex, int bIndex)
    {
        string key = $"{aIndex}-{bIndex}";
        //Console.WriteLine($"A Index: {aIndex} B Index: {bIndex}");
        if (_cache.ContainsKey(key))
        {
            //Console.WriteLine("From cache");
            return _cache[key];
        }
        else if (aIndex < 0 && bIndex < 0)
        {
            return _cache[key] = true;
        }
        else if (aIndex < 0 && bIndex > 0)
        {
            return _cache[key] = false;
        }
        else if (aIndex >= 0 && bIndex < 0)
        {
            while (aIndex >= 0)
            {
                if (isUpperCase(a[aIndex]))
                    return _cache[key] = false;
                aIndex--;
            }
            return _cache[key] = true;
        }
        else if (isUpperCase(a[aIndex]))
        {
            if (a[aIndex] == b[bIndex])
                return _cache[key] = recursiveMatch(a, b, aIndex -1, bIndex -1);
            else
                return _cache[key] = false;
        }
        else
        {
            if (a[aIndex] - 32 == b[bIndex])
            {
                // Use or skip
                return _cache[key] = recursiveMatch(a, b, aIndex -1, bIndex -1)
                    || recursiveMatch(a, b, aIndex -1, bIndex);
            }
            else
                return _cache[key] = recursiveMatch(a, b, aIndex -1, bIndex); // skip
        }
    }
    
    private static bool isUpperCase(char c)
    {
        return 65 <= c && c <= 90;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = Result.abbreviation(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}