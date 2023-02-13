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
     * Complete the 'candies' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static long candies(int n, List<int> arr)
    {
        List<int> nums = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            nums.Add(1);
        }
        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                nums[i] = nums[i - 1] + 1;
            }
        }
        for (int i = arr.Count - 1; i > 0; i--)
        {
            if (arr[i - 1] > arr[i] && nums[i - 1] <= nums[i])
            {
                nums[i - 1] = nums[i] + 1;
            }
        }
        long sum = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            sum += nums[i];
        }
        return sum;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        long result = Result.candies(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
