    public static string superReducedString(string s)
    {
        if(string.IsNullOrWhiteSpace(s))
        {
            return string.Empty;
        }

        var stack = new Stack<char>();

        for(var i = 0 ; i <= s.Length - 1; i++)
        {
            var thisChar = s[i];

            if(stack.Count > 0 && stack.Peek() == thisChar)
            {
                stack.Pop();                
            } 
            else
            {
                stack.Push(thisChar);                
            }
        }

        if(stack.Count == 0)
        {
            return "Empty String";
        }

        return string.Join("", stack.ToArray().Reverse());        
    }