    public static int camelcase(string s)
    {
        int total = 1;
        foreach(char c in s)
        {
            if(Char.IsUpper(c))
                total++;
        }
        return total;
    }