using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class day5
    {
        private const int MAX_SIZE = 1000;
        private int[,] grid = new int[1, 1];

        public day5()
        {
            string[] input = System.IO.File.ReadAllLines(@"input_5.txt");

            grid = new int[MAX_SIZE, MAX_SIZE];
            gold(input);
            grid = new int[MAX_SIZE, MAX_SIZE];
            silver(input);
        }

        public void gold(string[] input)
        {
            foreach (string line in input)
            {
                string[] points = line.Split(" -> ");
                int x1 = int.Parse(points[0].Split(",")[0]);
                int y1 = int.Parse(points[0].Split(",")[1]);
                int x2 = int.Parse(points[1].Split(",")[0]);
                int y2 = int.Parse(points[1].Split(",")[1]);

                if (x1 == x2)
                {
                    int min = Math.Min(y1, y2);
                    int max = Math.Max(y1, y2);
                    for (int j = min; j <= max; j++)
                    {
                        grid[x1, j]++;
                    }
                }
                else if (y1 == y2)
                {
                    int min = Math.Min(x1, x2);
                    int max = Math.Max(x1, x2);
                    for (int j = min; j <= max; j++)
                    {
                        grid[j, y1]++;
                    }
                }
            }

            int count = grid.Cast<int>().Count(x => x > 1);
            Console.WriteLine("gold : " + count);
        }

        public void silver(string[] input)
        {
            foreach (string line in input)
            {
                string[] points = line.Split(" -> ");
                int startX = int.Parse(points[0].Split(",")[0]);
                int startY = int.Parse(points[0].Split(",")[1]);
                int endX = int.Parse(points[1].Split(",")[0]);
                int endY = int.Parse(points[1].Split(",")[1]);

                while (startX != endX || startY != endY)
                {
                    grid[startX, startY]++;
                    if (startX != endX)
                        startX += startX > endX ? -1 : 1;
                    if (startY != endY)
                        startY += startY > endY ? -1 : 1;
                }
                grid[startX, startY]++;// do not forget the last point
            }

            int count = grid.Cast<int>().Count(x => x > 1);
            Console.WriteLine("silver : " + count);
        }
    }
}