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
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int sherlockAndAnagrams(string s)
    {        
        int count = 0;
        string[] stringList = new string[(s.Length * (s.Length + 1)) / 2];
        int index = 0;
        Dictionary<string,int> hash = new Dictionary<string, int>();
        
        // list of all substrings 
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                stringList[index] = s.Substring(i, j - i + 1);
                index++;
            }
        }
        
        // create a hash map of the sorted sub-strings
        foreach (var str in stringList)
        {
            var keyString = string.Concat(str.OrderBy(x => x));
            if (hash.ContainsKey(keyString))
            {
                hash[keyString]++;
            }
            else
            {
                hash[keyString] = 1;
            }
        }
        
        //for each key in hash map use the formula C(n,2) to find the combinations
        foreach (var key in hash.Keys)
        {
            if (hash[key] <= 1)
            {
                continue;
            }
            else
            {
                count = count + ((hash[key] * (hash[key] - 1) )/ 2);
            }
        }

        return count;
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
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
