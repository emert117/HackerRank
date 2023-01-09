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

    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries) {
        var resultList = new List<int>();
        var myDict = new Dictionary<int, int>();
        
        foreach (var q in queries)
        {
            switch (q[0])
            {
                case 1: // add
                    if (myDict.ContainsKey(q[1]))
                        myDict[q[1]]++;
                    else
                        myDict[q[1]] = 1;
                    break;
                case 2: // remove
                    if (myDict.ContainsKey(q[1]))
                    {
                        myDict[q[1]]--;
                        if (myDict[q[1]] <=0)
                            myDict.Remove(q[1]);
                    }
                    break;
                case 3: // check
                    if (myDict.Values.Contains(q[1]))
                        resultList.Add(1);
                    else
                        resultList.Add(0);
                                    
                    break;
            }
        }
        
        return resultList;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++) {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
