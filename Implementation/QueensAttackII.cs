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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        // not mine
        int attacks = 0;
        Dictionary<string, List<int>> hset = new();
        foreach(var obstacle in obstacles){
            hset[obstacle[0]+"x"+obstacle[1]] = obstacle;
        }        
        void Directions(int x, int y){
            int a = r_q + x;
            int b = c_q + y;
            while(a>0 && b>0 && a<n+1 && b<n+1){
                string key = a+"x"+b;
                if(hset.ContainsKey(key)){
                    hset.Remove(key);
                    break;
                }else{
                    a += x;
                    b += y;
                    attacks++;
                }
            }
        }
        Directions(1,0); //N
        Directions(-1,0); //S
        Directions(0,1); //E
        Directions(0,-1); //W
        Directions(1,1); //NE
        Directions(1,-1); //NW
        Directions(-1,1); //SE
        Directions(-1,-1); //SW
        return attacks;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
