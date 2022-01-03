using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class day9
    {
        public day9()
        {
            string[] input = System.IO.File.ReadAllLines(@"input_9.txt");
            gold(input);
        }

        private void gold(string[] input)
        {
            int[,] grid = new int[input.Length, input[0].Length];
            int lines = input.Length, columns = input[0].Length;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    grid[i, j] = Int32.Parse(input[i][j].ToString());
                }
            }

            int globalRisk = 0;

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int height = grid[i, j];
                    bool isLowPoint = true;

                    if ((i > 0 && grid[i - 1, j] <= height) || //top
                        (j > 0 && grid[i, j - 1] <= height) || //left
                        (j < columns - 1 && grid[i, j + 1] <= height) || //right
                        (i < lines - 1 && grid[i + 1, j] <= height))//bottom
                    {
                        isLowPoint = false;
                    }

                    if (isLowPoint)
                        globalRisk += 1 + height;
                }
            }

            Console.WriteLine("gold : " + globalRisk);
        }
    }
}