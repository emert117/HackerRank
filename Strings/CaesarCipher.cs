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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string encrypted = string.Empty;
        for(int i=0; i<s.Length; i++)
        {
            if (!Char.IsLetter(s[i]))
            {
                encrypted += s[i];                
            }
            else
            {
                int index = alphabet.IndexOf(Char.ToLower(s[i]));
                int rotatedIndex = (index + k) % alphabet.Length;
                if (Char.IsUpper(s[i]))
                    encrypted += Char.ToUpper(alphabet[rotatedIndex]);
                else
                    encrypted += alphabet[rotatedIndex];
            }
        }
        
        return encrypted;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
