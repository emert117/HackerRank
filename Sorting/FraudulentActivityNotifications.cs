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
     * Complete the 'activityNotifications' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY expenditure
     *  2. INTEGER d
     */

    public static int activityNotifications(List<int> expenditure, int d)
    {
        // TODO:  Time limit exceeded
        if (d + 1 > expenditure.Count) 
            return 0;
            
        int numberOfNotifications = 0;
        for(int i=0; i<expenditure.Count-d-1; i++)
        {
            double median = calculateMedian(expenditure.Skip(i).Take(d).ToArray());
            if (expenditure[i+d] >= median*2)
                numberOfNotifications++;
        }
        
        return numberOfNotifications;
    }
    
    public static double calculateMedian(int[] numbers)
    {
        // sort the array
        Array.Sort(numbers);
        // find the median
        if (numbers.Length % 2 != 0)
            return numbers[numbers.Count()/2];
        else
            return (numbers[numbers.Count()/2] + numbers[(numbers.Count()/2)-1]) / 2.0;        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
