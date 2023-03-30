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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        string result = "";

        if(year < 1918) {
            if(year%4 == 0) {
                result = string.Concat("12.09.", year.ToString());
            }
            else {
                result = string.Concat("13.09.", year.ToString());
            }
        }
        else if(year == 1918) {
            result = "26.09.1918";
        }
        else {
            if(year%4 == 0 && (year%400 == 0 || year%100 != 0)) {
                result = string.Concat("12.09.", year.ToString());
            }
            else {
                result = string.Concat("13.09.", year.ToString());
            }
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
