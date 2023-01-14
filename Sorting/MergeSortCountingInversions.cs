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
     * Complete the 'countInversions' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    public static long countInversions(List<int> arr)
    {
        int[] arr1 = arr.ToArray();
        long swaps = 0;
        MergeSort(arr1, 0, arr1.Length -1, ref swaps);
        return swaps;
    }
    
    static int[] MergeSort(int[] arr, int left, int right, ref long swaps)
    {
        if (left == right)
            return new int[] {arr[left]};
        
        int mid = left + (right - left)/2;
        int[] leftSorted = MergeSort(arr, left, mid, ref swaps);
        int[] rightSorted = MergeSort(arr, mid+1, right, ref swaps);
        return Merge(leftSorted, rightSorted, ref swaps);       
    }
    
    static int[] Merge(int[] left, int[] right,  ref long swaps)
    {
        int[] arr = new int[left.Length + right.Length];
        
        int i = 0, j = 0;
        for(int index = 0; index < left.Length + right.Length; index++)
        {
            if (i < left.Length && (j == right.Length || right[j] >= left[i]))
            {// left is smaller
                arr[index] = left[i++];
            }
            else
            {
                arr[index] = right[j++];
                
                swaps += left.Length - i;
            }
        }
        
        return arr;
    }


}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            long result = Result.countInversions(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
