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

    // Complete the substrCount function below.
    static long substrCount(int n, string s) {
        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c1 = s[i];
            int itr = i;
            while (itr < s.Length) {
                char c2 = s[itr];
                if (c1 == c2)
                    count++;
                else
                {
                    var left = i;
                    var right = itr + 1;

                    if (i + 1 == itr)
                    {
                        while (left > -1 && right < s.Length)
                        {
                            if (c1 == s[left] && c1 == s[right])
                            {
                                left--;
                                right++;
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                    break;
                }

                itr++;
            }                    
        }
        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
