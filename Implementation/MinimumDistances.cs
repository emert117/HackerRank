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
     * Complete the 'minimumDistances' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int minimumDistances(List<int> a)
    {
        int distance = int.MaxValue;
        Dictionary<int, List<int>> indicies = new Dictionary<int, List<int>>();
        for(int i=0; i<a.Count; i++)
        {
            if (indicies.ContainsKey(a[i]))
                indicies[a[i]].Add(i);
            else
                indicies.Add(a[i], new List<int>() {i} );
        }
        
        foreach(var index in indicies)
        {
            if (index.Value.Count == 1)
                continue;
                
            int smallestDiff = int.MaxValue;
            for(int k = 0;k < index.Value.Count - 1; k++)
                smallestDiff = Math.Min(smallestDiff, index.Value[k + 1] - index.Value[k]);
            
            if (smallestDiff < distance )
                distance = smallestDiff;
        }
        
        if (distance == int.MaxValue)
            return -1;
            
        return distance ;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.minimumDistances(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
