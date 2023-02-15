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
     * Complete the 'isBalanced' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isBalanced(string s)
    {
         var stackPlus = new Stack<char>();

            if(!string.IsNullOrEmpty(s)){
                    if(s.Length%2!=0){
            return "NO";
        }
        if(s[0]=='}'||s[0]==']'||s[0]==')'){
            return "NO";
        }
                foreach(char character in s){
                    if(character == '{' || character == '[' || character == '('){
                        stackPlus.Push(character);                
                    }
                if(stackPlus.Count>0){
                    if(character == '}' && stackPlus.Pop() != '{'){
                        return "NO";
                    }
                    else if(character == ']' && stackPlus.Pop() != '['){
                        return "NO";
                    }
                    else if(character == ')' && stackPlus.Pop()!= '('){
                        return "NO";
                    }
                }

                }
            }
            return stackPlus.Count > 0?"NO":"YES";
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
            string s = Console.ReadLine();

            string result = Result.isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
