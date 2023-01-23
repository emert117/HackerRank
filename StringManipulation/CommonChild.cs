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
     * Complete the 'commonChild' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */
     static int max(int a, int b) {
        return (a > b) ? a : b;
    }
     
     static int lcs(char[] X, char[] Y, int m, int n, int [,]L) {
        if (m == 0 || n == 0)
            return 0;
 
        if (L[m, n] != -1)
            return L[m, n];
 
        if (X[m - 1] == Y[n - 1]) {
            L[m, n] = 1 + lcs(X, Y, m - 1, n - 1, L);
            return L[m, n];
        }
 
        L[m, n] = max(lcs(X, Y, m, n - 1, L), lcs(X, Y, m - 1, n, L));
        return L[m, n];
    }

    public static int commonChild(string s1, string s2)
    {
        // https://www.geeksforgeeks.org/longest-common-subsequence-dp-4/
        char[] X = s1.ToCharArray();
        char[] Y = s2.ToCharArray();
        int m = X.Length;
        int n = Y.Length;
        int[,]L = new int[m + 1, n + 1];
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                L[i, j] = -1;
            }
        }
         return lcs(X, Y, m, n, L);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = Result.commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
