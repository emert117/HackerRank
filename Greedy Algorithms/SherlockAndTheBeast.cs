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
     * Complete the 'decentNumber' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void decentNumber(int n)
    {
        var threes = 0;
        
        if((n % 3)%2==1){
            threes = ((n % 3)+3)/2;
        }else{
            threes = (n % 3)/2;
        }           
        
        var fives  = (n - 5*threes)/3;
        
        if(fives < 0){
            Console.WriteLine("-1");
        }else{
            Console.WriteLine( new String('5',3*fives) + new String('3',5*threes));
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Result.decentNumber(n);
        }
    }
}
