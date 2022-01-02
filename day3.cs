using System;
using System.Linq;

namespace AdventOfCode
{
    class day3
    {
        public day3()
        {
            gold();
            silver();
        }

        public void gold()
        {
            //fetch string from URL
            string[] input = System.IO.File.ReadAllLines(@"input_3.txt");

            int[] gammaValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char bit = line[i];
                    if (bit == '1')
                    {
                        gammaValues[i]++;
                    }
                    else
                    {
                        gammaValues[i]--;
                    }
                }
            }

            string gammaString = string.Join(separator: null, gammaValues.Select(x => x > 0 ? "1" : "0"));


            int gamma = Convert.ToInt32(gammaString, 2);

            int epsilon = gamma ^ 0b111111111111;

            Console.WriteLine("gold : " + gamma * epsilon);
        }

        private string[] FilterNumbers(string[] numbers, int bitPos, bool max)
        {
            int one = 0;
            int zero = 0;
            foreach (string line in numbers)
            {
                char c = line[bitPos];
                if (c == '1')
                {
                    one++;
                }
                else
                {
                    zero++;
                }
            }

            char toFind = max ? (zero > one ? '0' : '1') : (zero <= one ? '0' : '1');

            return numbers.Where(n => n[bitPos] == toFind).ToArray();
        }

        public void silver()
        {
            //fetch string from URL
            string[] input = System.IO.File.ReadAllLines(@"input_3.txt");

            string[] working = input.ToArray();
            int i = 0;
            while (working.Length > 1)
            {
                working = FilterNumbers(working, i, true);
                i++;
            }
            int oxygen = Convert.ToInt32(working[0], 2);

            working = input.ToArray();
            i = 0;
            while (working.Length > 1)
            {
                working = FilterNumbers(working, i, false);
                i++;
            }
            int co2 = Convert.ToInt32(working[0], 2);

            Console.WriteLine("silver : " + oxygen * co2);
        }
    }
}
