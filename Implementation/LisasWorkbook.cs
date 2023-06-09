public static int workbook(int n, int k, List<int> arr)
    {
        int special = 0;
        int page = 1;

        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 1; j <= arr[i]; j++)
            {
                if (j == page)
                    special++;

                if (j % k == 0 && j != arr[i])
                    page++;
            }            
            page++;
        }

        return special;
    }

}