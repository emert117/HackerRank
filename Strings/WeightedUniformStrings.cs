
    public static List<string> weightedUniformStrings(string s, List<int> queries)
    {
        List<int> weights = new List<int>();
        
        char previous = ' ';
        int previousCount = 1;
        foreach(char c in s)
        {
            int b = (int)c%96;
            if (c == previous)
            {
                previousCount++;
                b *= previousCount;                
            }
            else
            {
                previousCount = 1;
            }
            
            weights.Add(b);            
            previous = c;
        }
        
        List<string> result = new List<string>();
        
        foreach(int query in queries)
        {
            if (weights.Contains(query))
                result.Add("Yes");
            else
                result.Add("No");
        }
        
        return result;
    }
