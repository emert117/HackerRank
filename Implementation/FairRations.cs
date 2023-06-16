public static string fairRations(List<int> B)
    {
        int count = 0;

        for (int i = 0; i < B.Count - 1; i++) {
            if (B[i] % 2 != 0) {
                B[i] = B[i] + 1;
                B[i + 1] = B[i + 1] + 1;
                count += 2;
            }
        }

        if (B[B.Count - 1] % 2 != 0) 
            return "NO";

        return count.ToString();
    }