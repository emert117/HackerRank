    public static List<string> cavityMap(List<string> grid)
    {
        for (int i = 1; i < grid.Count - 1; i++)
        {
            for (int j = 1; j < grid[i].Length - 1; j++)
            {
                if (grid[i][j] > grid[i - 1][j] && 
                    grid[i][j] > grid[i + 1][j] && 
                    grid[i][j] > grid[i][j - 1] &&
                    grid[i][j] > grid[i][j + 1])
                {
                    var sb = new StringBuilder(grid[i]);
                    sb[j] = 'X';
                    grid[i] = sb.ToString();
                }
            }
        }
        return grid;
    }