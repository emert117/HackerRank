 public static List<int> absolutePermutation(int n, int k)
{
        if (k == 0) 
            return Enumerable.Range(1, n).ToList();
    
        HashSet<int> result = new();

        for (int i = 1; i <= n; i++)
        {
            var permutationElement = i > k ? i - k : i + k;
            if (permutationElement > n || result.Contains(permutationElement))
            {
                permutationElement = i < k ? i - k : i + k;
                if (permutationElement > n || result.Contains(permutationElement))
                {
                    return new List<int> { -1 };
                }
            }
            result.Add(permutationElement);
        }
        return result.ToList();

    }

}