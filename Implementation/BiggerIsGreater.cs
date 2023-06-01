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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        char[] array = w.ToCharArray();
        string output = string.Empty;
        int i = array.Length - 1;
        while (i > 0 && array[i-1] >= array[i])
            i--;
            
        if (i <= 0)
            return "no answer";
            
        int j = array.Length - 1;
        while (array[j] <= array[i-1])
            j--;
        
        char temp = array[i - 1];
        array[i - 1] = array[j];
        array[j] = temp;
        j = array.Length - 1;
        
        while (i < j)
        {
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
            i++;
            j--;
        }
        
        foreach (char c in array)
        {
            output += c.ToString();
        }
        
        return output;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
