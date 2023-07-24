// not my code
public static List<string> bomberMan(int n, List<string> grid)
        {
            //1,2,3,4,5,6,7,8,9,10
            //1 -> 3
            //2 -> 5
            //4 -> 7
            //6 -> 9 bomb
            if (n == 1)
                return grid;

            int rec = (n - 3) / 2 + 1;

            if ((n - 3) % 2 != 0)
                return backUp(grid);

            grid = bomb(grid);
            if (rec % 2 == 0)
                grid = bomb(grid);

            return grid;
        }

        private static List<string> backUp(List<string> grid)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < grid.Count; i++)
            {
                string b = "";
                for (int j = 0; j < grid[i].Length; j++)
                {
                    b += 'O';
                }
                result.Add(b);
            }
            return result;
        }

        //
        private static List<string> bomb(List<string> grd)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < grd.Count; i++)
            {
                string b = "";
                for (int j = 0; j < grd[i].Length; j++)
                {
                    if (grd[i][j].Equals('O'))
                        b += '.';
                    //right
                    else if (j + 1 < grd[0].Length && grd[i][j + 1].Equals('O'))
                        b += '.';
                    //left
                    else if (j - 1 >= 0 && grd[i][j - 1].Equals('O'))
                        b += '.';
                    //up
                    else if (i - 1 >= 0 && grd[i - 1][j].Equals('O'))
                        b += '.';
                    //down                    
                    else if (i + 1 < grd.Count && grd[i + 1][j].Equals('O'))
                        b += '.';
                    else
                        b += 'O';

                }
                result.Add(b);
            }
            return result;
        }