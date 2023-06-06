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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] teens = new string[]{"ten","eleven","twenty","thirteen",                              "fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};
        string twenty ="twenty";
        
        string res = "";
        string hour = "";
        if(m < 30)
        {
            
            if(h > 9)
            {
                hour = teens[12 -h-2];
            }else
                hour = ones[h];
            if(m == 0)
            {   
                res = hour +" o' clock";
            }else if(m < 10)
            {
                int index = m % 10;
                if(index == 1)
                    res = ones[index]+ " minute past " + hour;
                else
                    res = ones[index]+ " minutes past " + hour;
            }
            else if(10 <= m && m < 20)
            {
                int index = m % 10;
                res = teens[index]+ " minutes past " + hour;
                if(m == 15)
                    res = "quarter past " + hour;
            }else
            {
                int index = m % 20;
                res = twenty + " " + ones[index] + " minutes past " + hour;
            }   
        }else if(m == 30)
        {
            res = "half past " + ones[h];
        }else
        {
            
            int toMinute = 60 - m;
            if(h+1 > 12)
                h = 1;
           
            if(h > 9)
            {
                hour = teens[12 -h-1];
            }else
                hour = ones[h+1];
            if(toMinute < 10)
            {
                int index = toMinute % 10;
                if(index == 1)
                    res = ones[index]+ " minute to " + hour;
                else
                    res = ones[index]+ " minutes to " + hour;
            }else if(10 <= toMinute && toMinute < 20)
            {
                int index = toMinute % 10;
                res = teens[index]+ " minutes to " + hour;
                if(toMinute == 15)
                    res = "quarter to " + hour;
            }else
            {
                int index = toMinute % 20;
                res = twenty + " " + ones[index] + " minutes to " + hour;
            } 
            
        }
        
        return res;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
