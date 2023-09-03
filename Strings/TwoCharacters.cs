    public static int alternate(string s)
    {
        
        var cl = s.Distinct();
        List<char> wl = cl.ToList();
        List<char> bl = new List<char>();
        int rl = 0;
        
        
        
        while(Regex.Match(s, @"(.)\1", RegexOptions.IgnoreCase).ToString() != "")
        {
            foreach(var c in wl)
                if(s.Contains(c.ToString() + c.ToString()))
                    bl.Add(c);
                
                foreach(var c in bl)
                {
                    s = s.Replace(c.ToString(),"");
                    wl.Remove(c);
                }
        }
        
        //Console.WriteLine(s);
        if(cl.Count() - bl.Count() == 2)
        {
            rl = s.Length;
        }
        else
        {
        string ss = "";
            
            for(int i = 0; i < wl.Count(); i ++)
            {
                for(int j = i+1; j < wl.Count(); j ++)
                {
                    ss = s;
                    foreach(char c in wl)
                    {
                        if(c != wl[i] && c != wl[j])
                          ss = ss.Replace(c.ToString(), "");
                    }
                    if(Regex.Match(ss, @"(.)\1", RegexOptions.IgnoreCase).ToString() == "")
                        if(rl < ss.Length)
                        {
                            rl = ss.Length;
                        }
                    }
                }
            }
            
            return rl;

    }

}