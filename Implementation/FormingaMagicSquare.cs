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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */

    public static int formingMagicSquare(List<List<int>> s)
    {
                // possible cubes
       int[,] variants = new int[8,9]{
            {6,1,8,7,5,3,2,9,4},
            {8,1,6,3,5,7,4,9,2},
            {8,3,4,1,5,9,6,7,2},
            {4,3,8,9,5,1,2,7,6},
            {6,7,2,1,5,9,8,3,4},
            {2,7,6,9,5,1,4,3,8},
            {2,9,4,7,5,3,6,1,8},
            {4,9,2,3,5,7,8,1,6}
        };  
        // generate givent data to one dimensional array
        int[] given = new int[9];
        Array.Copy(s[0].ToArray(), 0, given, 0, 3);
        Array.Copy(s[1].ToArray(), 0, given, 3, 3);
        Array.Copy(s[2].ToArray(), 0, given, 6, 3);
        // find minimum
        int min=int.MaxValue;
        // iterating throught all possibilities
        for(int i=0; i<8;i++){
            int tempSum = 0;
            // iterating through array elements
            for(int j=0; j<given.Count(); j++){
                tempSum+=Math.Abs(given[j]-variants[i,j]);
                // break loop, because sum is larger than minimum
                if(tempSum>min)
                    continue;
            }
            min = (tempSum<min)? tempSum:min;
        }
        return min;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
