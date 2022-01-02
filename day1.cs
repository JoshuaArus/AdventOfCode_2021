using System;

namespace AdventOfCode
{
    class day1
    {
        public day1()
        {
            gold();
            silver();
        }

        public void gold()
        {
            //read string from file
            string input = System.IO.File.ReadAllText(@"input_1.txt");

            int a = 99999;
            int count = 0;
            //foreach line in input
            foreach (string line in input.Split('\n'))
            {
                if (line == "")
                    continue;
                int b = int.Parse(line);
                if (b > a)
                {
                    count++;
                }
                a = b;
            }
            Console.WriteLine("gold : " + count);
        }

        public void silver()
        {
            //read string from file
            string[] input = System.IO.File.ReadAllText(@"input_1.txt").Split('\n');

            int a = 99999;
            int count = 0;

            for (int i = 0; i < input.Length - 3; i++)
            {
                string line1 = input[i];
                string line2 = input[i + 1];
                string line3 = input[i + 2];
                if (line3 == "")
                    continue;

                int b = int.Parse(line1) + int.Parse(line2) + int.Parse(line3);

                if (b > a)
                {
                    count++;
                }
                a = b;
            }
            Console.WriteLine("silver : " + count);
        }
    }
}

