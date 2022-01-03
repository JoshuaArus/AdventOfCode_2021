using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class day7
    {
        public day7()
        {
            int[] crabsPositions = System.IO.File.ReadAllLines(@"input_7.txt").First().Split(",").Select(n => Convert.ToInt32(n)).OrderBy(n => n).ToArray();
            gold(crabsPositions);
            silver(crabsPositions);
        }

        public void gold(int[] crabsPositions)
        {
            int minPos = crabsPositions.First();
            int maxPos = crabsPositions.Last();

            int minCost = int.MaxValue;

            for (int evaluatedPos = minPos; evaluatedPos <= maxPos; evaluatedPos++)
            {
                int cost = 0;
                foreach (int pos in crabsPositions)
                {
                    cost += Math.Abs(evaluatedPos - pos);
                }

                minCost = Math.Min(minCost, cost);
            }

            Console.WriteLine("gold : " + minCost);
        }

        public void silver(int[] crabsPositions)
        {
            int minPos = crabsPositions.First();
            int maxPos = crabsPositions.Last();

            int minCost = int.MaxValue;

            for (int evaluatedPos = minPos; evaluatedPos <= maxPos; evaluatedPos++)
            {
                int cost = 0;
                foreach (int pos in crabsPositions)
                {
                    int fuelCost = 1;
                    for (int i = Math.Min(evaluatedPos, pos); i < Math.Max(evaluatedPos, pos); i++)
                    {
                        cost += fuelCost;
                        fuelCost++;
                    }
                }

                minCost = Math.Min(minCost, cost);
            }

            Console.WriteLine("silver : " + minCost);
        }
    }
}