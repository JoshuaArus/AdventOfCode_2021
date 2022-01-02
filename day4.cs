using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class day4
    {
        public day4()
        {
            gold();
            silver();
        }

        public void gold()
        {
            string[] input = System.IO.File.ReadAllLines(@"input_4.txt");
            int line = 0;

            int[] chosenNumbers = input[line].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            // Console.WriteLine("gold : " + string.Join(",", chosenNumbers));

            line++;//1
            List<day4_grid> grids = new List<day4_grid>();

            while (line < input.Length)
            {
                line++;
                day4_grid g = new day4_grid();
                for (int i = 0; i < 5; i++)
                {
                    string row = input[line];
                    for (int j = 0; j < 5; j++)
                    {
                        int n = Int32.Parse(row.Substring(j * 3, 2).Trim());
                        g._grid[i, j] = n;
                    }
                    line++;
                }
                grids.Add(g);
            }

            int numberToChek = 1;
            int score = 0;
            while (score == 0)
            {
                int[] n = chosenNumbers.Take(numberToChek).ToArray();
                day4_grid winner = grids.FirstOrDefault(g => g.isWinning(n));
                if (winner != null)
                {
                    score = winner.GetScore(n) * n.Last();
                }

                numberToChek++;
            }

            Console.WriteLine("gold : " + score);
        }

        private class day4_grid
        {
            public int[,] _grid = new int[5, 5];

            public bool isWinning(int[] numbers)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool won = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (!numbers.Contains(_grid[i, j]))
                        {
                            won = false;
                        }
                    }
                    if (won) return true;
                }

                for (int i = 0; i < 5; i++)
                {
                    bool won = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (!numbers.Contains(_grid[j, i]))
                        {
                            won = false;
                        }
                    }
                    if (won) return true;
                }

                return false;
            }

            public int GetScore(int[] numbers)
            {
                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!numbers.Contains(_grid[i, j]))
                        {
                            sum += _grid[i, j];
                        }
                    }
                }
                return sum;
            }
        }

        public void silver()
        {
            string[] input = System.IO.File.ReadAllLines(@"input_4.txt");
            int line = 0;

            int[] chosenNumbers = input[line].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            // Console.WriteLine("silver : " + string.Join(",", chosenNumbers));

            line++;//1
            List<day4_grid> grids = new List<day4_grid>();

            while (line < input.Length)
            {
                line++;
                day4_grid g = new day4_grid();
                for (int i = 0; i < 5; i++)
                {
                    string row = input[line];
                    for (int j = 0; j < 5; j++)
                    {
                        int n = Int32.Parse(row.Substring(j * 3, 2).Trim());
                        g._grid[i, j] = n;
                    }
                    line++;
                }
                grids.Add(g);
            }

            int numberToChek = 1;
            List<int> winnerScores = new List<int>();

            while (numberToChek < chosenNumbers.Length && grids.Count > 0)
            {
                int[] n = chosenNumbers.Take(numberToChek).ToArray();
                List<day4_grid> winner = grids.Where(g => g.isWinning(n)).ToList();
                if (winner.Count > 0)
                {
                    foreach (day4_grid g in winner)
                    {
                        winnerScores.Add(g.GetScore(n) * n.Last());
                        grids.Remove(g);
                    }
                }

                numberToChek++;
            }


            Console.WriteLine("silver : " + winnerScores.Last(s => s != 0));
        }
    }
}