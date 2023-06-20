 public static string happyLadybugs(string b)
    {
        Dictionary<char, int> ladybugs = new Dictionary<char, int>();
        bool hasSpace = false;
        bool hasUnhapie = false;
        bool onlySpace = true;
        char[] bugsArray = b.ToCharArray();
        
        if(bugsArray.Length == 1 && bugsArray[0] != '_')
        return "NO";
        
        if(bugsArray.Length == 1 && bugsArray[0] == '_')
        return "YES";
        
        if(bugsArray[0] != bugsArray[1] || bugsArray.Last() != bugsArray[bugsArray.Length-2])
        hasUnhapie = true;
        
        for(int i = 1; i < bugsArray.Length - 1; i++)
        if(bugsArray[i] != bugsArray[i-1] && bugsArray[i] != bugsArray[i+1])
            hasUnhapie = true;
        
        foreach(char bug in bugsArray)
        if(bug == '_')
            hasSpace = true;
        else
        {
            onlySpace = false;
            if(ladybugs.ContainsKey(bug))
            ladybugs[bug]++;
            else
            ladybugs.Add(bug,1);
        }
        
        if(onlySpace)
        return "YES";
        
        if(!hasSpace && hasUnhapie)
        return "NO";  
        
        foreach(KeyValuePair<char, int> bug in ladybugs)
        if(bug.Value <= 1)
            return "NO";
            
        return "YES";
    }