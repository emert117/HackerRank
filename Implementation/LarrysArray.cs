// not my code
    private static int countInv(int n, IEnumerable<int> lst)
    {
        return lst.Count() < 1 ? 0 : lst.Select(p=>n > p ? 1 : 0).Sum()%2;
    }
    
    public static string larrysArray(List<int> A)
    {
        int idx = 0;
        return A.Aggregate(0, (sum, c) => sum + countInv(c, A.Skip(++idx))) % 2 == 0 ? "YES" : "NO";
    }