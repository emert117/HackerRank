using System;

namespace Day11_2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // get input
            int[,] numbers = new int[6,6];
            for (int i = 0; i < 6; i++)
            {
                string input = Console.ReadLine();
                string[] numbersInLine = input.Split(' ');
                for (int j = 0; j < 6; j++)
                {
                    numbers[i, j] = Convert.ToInt32(numbersInLine[j]);
                }
            }
            // got input

            // calculate the max total of hourglass
            int max = -9 * 9;
            // traverse hourglasses
            for (int row = 0; row < 4; row++)
            {
                int total = 0;
                int column = 0;
                for (; column < 4; column++)
                {
                    // top row of hourglass
                    total = numbers[row, column] + numbers[row, column+1] + numbers[row, column+2];
                    // bottom row of hourglass
                    total += numbers[row+2, column] + numbers[row + 2, column+1] + numbers[row + 2, column+2];
                    // middle of hourglass
                    total += numbers[row + 1, column + 1];
                    // swap total if bigger than max
                    if (total > max)
                        max = total;
                }
               
            }

            Console.WriteLine(max);
        }
    }
}
