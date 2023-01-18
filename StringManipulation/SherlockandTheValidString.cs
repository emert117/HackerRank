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
     * Complete the 'isValid' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isValid(string s)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        
        for (int i = 0; i < s.Length; i++)
        {
            if (freq.ContainsKey(s[i])) freq[s[i]]++;                
            else freq.Add(s[i], 1);
        }
    
        int badChars = 0;
        List<int> vals = freq.Values.ToList();
        int mode = vals.GroupBy(x => x).
                                OrderByDescending(g => g.Count()).
                                First().
                                Key;
    
        for (int j = 0; j < vals.Count; j++)
        {
            if (vals[j] != mode) badChars += Math.Min(vals[j], Math.Abs(vals[j] - mode));
            if (badChars > 1) return "NO";
        }
        return "YES";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
