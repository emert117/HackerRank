    public static List<string> bigSorting(List<string> unsorted)
    {
       return unsorted.OrderBy(x => x.Length).ThenBy(x => x).ToList();
    }