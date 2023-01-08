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

class Solution {

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r) {
        //number of times we encounter key*r
        var doubles = new Dictionary<long, long>();
        //number of times we encounter a triplet
        var triplets = new Dictionary<long, long>();
        long count = 0;
        foreach (var key in arr)
        {
            long keyXr = key * r;

            if (triplets.ContainsKey(key))
                count += triplets[key];

            if (doubles.ContainsKey(key))
            {
                if (triplets.ContainsKey(keyXr))
                    triplets[keyXr] += doubles[key];
                else
                    triplets.Add(keyXr, doubles[key]);
            }

            if (doubles.ContainsKey(keyXr))
                doubles[keyXr]++;
            else
                doubles.Add(keyXr, 1);
        }
        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
