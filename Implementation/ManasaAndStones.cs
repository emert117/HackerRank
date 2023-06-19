    public static List<int> stones(int n, int a, int b)
    {
        var nonZeroStones = n - 1;
        var result = new List<int>();
        var smaller = b - a > 0 ? a : b;
        var bigger = a == smaller ? b : a;
        for(int i = 0; i <= nonZeroStones ; i++)
        {
            result.Add((nonZeroStones - i ) * smaller + i * bigger);
            if(bigger == smaller)
            break;
        }
        return result;
    }