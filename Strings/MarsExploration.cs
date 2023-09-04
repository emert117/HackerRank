    public static int marsExploration(string s)
    {
        int difference = 0;
        string original = "SOS";
        int originalIndex = 0;
        foreach(char c in s)
        {
            if (c != original[originalIndex])
                difference++;
            
            originalIndex = (originalIndex+1) % original.Length;
        }
        
        return difference;
    }

}