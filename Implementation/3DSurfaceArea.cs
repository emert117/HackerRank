public static int surfaceArea(List<List<int>> A)
    {
        int area = 0;
        for (int i = 0; i < A.Count; i++)
        {
            // iterate through each row
            for (int j = 0; j < A[i].Count; j++)
            {
                // bottom and top area += 1 for every non zero entry
                if (!A[i][j].Equals(0)) area += 2; // add 2 to account for top and bottom
                
                // outer left/right walls
                if (i.Equals(0)) area += A[i][j]; // outer left wall
                if (i.Equals(A.Count - 1)) area += A[i][j]; // outer right wall
                // inner left/right walls
                if (A.Count > 1 && i < (A.Count - 1)) // inter-column
                {
                    // for each height, compare to height of block in next row of same column. difference is an inner wall
                    area += Math.Abs(A[i][j] - A[i + 1][j]);
                }
                
                // outer front/back walls
                if (j.Equals(0)) area += A[i][j]; // outer front wall
                if (j.Equals(A[i].Count - 1)) area += A[i][j]; // outer back wall
                // inner front/back walls
                if (A[i].Count > 1 && j < (A[i].Count - 1)) // inter-row
                {
                    // compare to next block height
                    area += Math.Abs(A[i][j] - A[i][j + 1]);
                }
            }
        }
        return area;

    }