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
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(List<int> q)
    {
        int bribes = 0;
        for (int i = 0; i < q.Count; i++) 
        {
            if (q[i] - (i+1) > 2) 
            {
                Console.WriteLine("Too chaotic");
                return;
            }
            
            for (int j = i - 1; j >= q[i] - 2 && j >= 0; j--) 
            {
                if (q[j] > q[i]) bribes++;
            }
        }
        
        Console.WriteLine(bribes);        
    }
}
    

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.minimumBribes(q);
        }
    }
}
