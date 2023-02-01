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
     * Complete the 'reverseShuffleMerge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string reverseShuffleMerge(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(char c in s)
        {
            if(map.ContainsKey(c)) map[c]++;
            else map.Add(c,1);
        }
        Dictionary<char,int> alph = new Dictionary<char, int>();
        foreach(var item in map.Keys)
        {
            alph.Add(item, map[item]/2);
        }
        
        //reverse string 
        var a = s.ToArray();
        Array.Reverse(a);
        s = new string(a);
        
        List<char> sol = new List<char>();
        int i = 0;
        while(sol.Count<s.Length/2)
        {
            int minchar = -1;
            while(true)
            {
                char c = s[i];
                if(alph[c]>0&&(minchar<0||c<s[minchar]))
                {
                    minchar = i;
                } 
                map[c]--;
                if(map[c]<alph[c]) break;
                i++;
            }
            
            for(int j=minchar+1;j<i+1;j++)
            {
                map[s[j]]++;
            }
            alph[s[minchar]]--;
            sol.Add(s[minchar]);
            i=minchar+1;
        }
        
        return new string(sol.ToArray());

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.reverseShuffleMerge(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
