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

    // Complete the triplets function below.
    static long triplets(int[] a, int[] b, int[] c) {
        
    List<int> aL = a.Distinct().ToList();
    List<int> bL = b.Distinct().ToList();
    List<int> cL = c.Distinct().ToList();

    aL.Sort();
    cL.Sort();

    int maxA = aL[aL.Count - 1];
    int maxC = cL[cL.Count - 1];
    int minA = aL[0];
    int minC = cL[0];

    long countLeft = 0, countRight = 0;
    long retVal = 0;

    foreach (int o in bL)
    {
        if (minA > o)
            countLeft = 0;
        else if (maxA <= o)
            countLeft = aL.Count;
        else
            countLeft = FindIndexOfListElementClosestTo(aL, o, 0, aL.Count - 1) + 1;

        if (minC > o)
            countRight = 0;
        else if (maxC <= o)
            countRight = cL.Count;
        else
            countRight = FindIndexOfListElementClosestTo(cL, o, 0, cL.Count - 1) + 1;

        retVal += countLeft * countRight;
    }

    return retVal;
}

static long FindIndexOfListElementClosestTo(List<int> elements, int num, int startIndex, int endIndex)
{
    long retVal = 0;
    int midPointIndex;

    if (endIndex - startIndex <= 8)
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (elements[i] == num)
            {
                retVal = i;
                break;
            }
            if (elements[i] > num)
            {
                retVal = i - 1;
                break;
            }
        }
    }
    else
    {
        midPointIndex = (endIndex + startIndex) / 2;

        if (elements[midPointIndex] == num)
            retVal = midPointIndex;
        else
            if (elements[midPointIndex] < num)
                retVal = FindIndexOfListElementClosestTo(elements, num, midPointIndex, endIndex);
            else
                retVal = FindIndexOfListElementClosestTo(elements, num, startIndex, midPointIndex);
    }
    return retVal;
}

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] lenaLenbLenc = Console.ReadLine().Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
