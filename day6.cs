using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class day6
    {
        public day6()
        {
            List<int> input = System.IO.File.ReadAllLines(@"input_6.txt").First().Split(",").Select(n => Convert.ToInt32(n)).ToList();
            gold(input.ToList());
            silver(input.ToList());
        }

        private double calculate(List<int> fishTimers, int nbDays)
        {
            double[] countByTimer = new double[9];

            for (int i = 0; i < fishTimers.Count; i++)
            {
                countByTimer[fishTimers[i]]++; //init countByTimer
            }

            for (int day = 0; day < nbDays; day++)
            {
                double newFish = countByTimer[0]; // keep fish at 0

                for (int i = 0; i < 8; i++)
                {
                    countByTimer[i] = countByTimer[i + 1]; // decreasing each timer
                }

                countByTimer[6] += newFish; // reset old 0 fish to 6
                countByTimer[8] = newFish; // add new fishes
            }

            return countByTimer.Sum();
        }

        public void gold(List<int> fishTimers)
        {
            Console.WriteLine("gold : " + calculate(fishTimers, 80));
        }

        public void silver(List<int> fishTimers)
        {
            Console.WriteLine("silver : " + calculate(fishTimers, 256));
        }
    }
}