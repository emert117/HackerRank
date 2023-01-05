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
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */

    public static void checkMagazine(List<string> magazine, List<string> note)
    {
        Hashtable magTable = new Hashtable();
        foreach(string word in magazine)
        {
            if (magTable.ContainsKey(word))
                magTable[word] = (int)magTable[word] + 1;
            else
                magTable[word] = 0;
        }
        
        Hashtable noteTable = new Hashtable();
        foreach(string word in note)
        {
            if (noteTable.ContainsKey(word))
                noteTable[word] = (int)noteTable[word] + 1;
            else
                noteTable[word] = 0;
        }
        
        foreach(DictionaryEntry  pair in noteTable)
        {
            if (!magTable.ContainsKey(pair.Key))
            {
                Console.WriteLine("No");
                return;
            }
            
            if ((int)pair.Value > (int)magTable[pair.Key])
            {
                Console.WriteLine("No");
                return;
            }
        }
        
        Console.WriteLine("Yes");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        List<string> magazine = Console.ReadLine().TrimEnd().Split(' ').ToList();

        List<string> note = Console.ReadLine().TrimEnd().Split(' ').ToList();

        Result.checkMagazine(magazine, note);
    }
}
