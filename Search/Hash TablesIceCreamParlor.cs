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
     * Complete the 'whatFlavors' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY cost
     *  2. INTEGER money
     */

    public static void whatFlavors(List<int> cost, int money)
    {
        /*
        for(int i=0; i<cost.Count; i++)
        {
            if (cost[i] >= money)
                continue;
                
            for(int j=i+1; j<cost.Count; j++)
            {
                if (cost[j] >= money)
                    continue;
                
                if (cost[i]+cost[j]==money)
                {
                    Console.WriteLine($"{i+1} {j+1}");
                    return;
                }               
            }
        }
        */
        int i=0;
        while(true) {
            int v=cost[0];
            cost.RemoveAt(0);
            int x=cost.IndexOf(money-v);
            if(x<0) {
                i++;
            } else {
                Console.WriteLine("{0} {1}",i+1,x+i+2);
                return;             
            }
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int money = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> cost = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(costTemp => Convert.ToInt32(costTemp)).ToList();

            Result.whatFlavors(cost, money);
        }
    }
}
