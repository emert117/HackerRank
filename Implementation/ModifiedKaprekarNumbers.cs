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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */

    public static void kaprekarNumbers(int p, int q)
    {
        var result = new StringBuilder();

        for (int n = p; n <= q; n++)
        {
            if (isKaprekarNumber(n))
                result.Append(n.ToString() + " ");
        }

        if (result.Length == 0)
            Console.WriteLine("INVALID RANGE");
        else
            Console.WriteLine(result.ToString());   
    }

    private static bool isKaprekarNumber(int i)
    {
        bool result = false;

        long n = Convert.ToInt64(i);

        string square = (n * n).ToString();

        string left, right;

        left = square.Substring(0, square.Length / 2);
        right = square.Substring(square.Length / 2);

        if (left.Length == 0)
            left = "0";

        if (Convert.ToInt32(left) + Convert.ToInt32(right) == n)
            result = true;


        return (result);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
