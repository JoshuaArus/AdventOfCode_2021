using System;

namespace AdventOfCode
{
    class day2
    {
        public day2()
        {
            gold();
            silver();
        }

        public void gold()
        {
            string[] directions = new string[] { "forward", "down", "up" };
            int x = 0;
            int y = 0;
            //fetch string from URL
            string[] input = System.IO.File.ReadAllLines(@"input_2.txt");
            foreach (string line in input)
            {
                string[] words = line.Split(' ');
                string direction = words[0];
                int val = int.Parse(words[1]);
                if (direction == "forward")
                    x += val;
                else if (direction == "down")
                    y += val;
                else if (direction == "up")
                    y -= val;
            }
            Console.WriteLine("gold : " + x * y);
        }

        public void silver()
        {
            string[] directions = new string[] { "forward", "down", "up" };
            int horizontalPosition = 0;
            int aim = 0;
            int depth = 0;
            //fetch string from URL
            string[] input = System.IO.File.ReadAllLines(@"input_2.txt");
            foreach (string line in input)
            {
                string[] words = line.Split(' ');
                string direction = words[0];
                int val = int.Parse(words[1]);
                if (direction == "forward")
                {
                    horizontalPosition += val;
                    depth += aim * val;
                }
                else if (direction == "down")
                    aim += val;
                else if (direction == "up")
                    aim -= val;
            }
            Console.WriteLine("silver : " + horizontalPosition * depth);
        }
    }
}
