using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal static class stringExtensions
    {
        public static string SortCharacters(this string s)
        {
            return string.Join("", s.ToCharArray().OrderBy(c => c));
        }

        public static string ByVal(this Dictionary<string, string> dict, string value)
        {
            return dict.FirstOrDefault(x => x.Value.Equals(value)).Key;
        }

        public static string And(this string s1, string s2)
        {
            char[] key1 = s1.ToCharArray();
            char[] key2 = s2.ToCharArray();

            return string.Join("", key1.Intersect(key2));
        }

        public static string Except(this string s1, string s2)
        {
            char[] key1 = s1.ToCharArray();
            char[] key2 = s2.ToCharArray();

            return string.Join("", key1.Except(key2).Union(key2.Except(key1))).SortCharacters();
        }

        public static string CombineWith(this string s1, string s2)
        {
            char[] key1 = s1.ToCharArray();
            char[] key2 = s2.ToCharArray();

            return string.Join("", key1.Union(key2)).SortCharacters();
        }
    }

    public class day8
    {
        public day8()
        {
            string[] input = System.IO.File.ReadAllLines(@"input_8.txt");
            gold(input);
            silver(input);
        }

        public void gold(string[] entries)
        {
            int count = 0;
            List<int> uniqueDigitsLength = new List<int> { 2, 3, 4, 7 };

            foreach (string entry in entries)
            {
                string[] outputValues = entry.Split(" | ")[1].Split(" ");

                count += outputValues.Count(s => uniqueDigitsLength.Contains(s.Length));
            }

            Console.WriteLine("gold : " + count);
        }



        public void silver(string[] entries)
        {
            int total = 0;

            foreach (string entry in entries)
            {
                string[] uniqueSignals = entry.Split(" | ")[0].Split(" ").Select(v => v.SortCharacters()).ToArray();
                string[] outputValues = entry.Split(" | ")[1].Split(" ").Select(v => v.SortCharacters()).ToArray();

                //  0:      1:      2:      3:      4:
                //  aaaa            aaaa    aaaa        
                // b    c       c       c       c  b    c
                // b    c       c       c       c  b    c
                //                  dddd    dddd    dddd
                // e    f       f  e            f       f
                // e    f       f  e            f       f
                //  gggg            gggg    gggg        

                //   5:      6:      7:      8:      9:
                //  aaaa    aaaa    aaaa    aaaa    aaaa
                // b       b            c  b    c  b    c
                // b       b            c  b    c  b    c
                //  dddd    dddd            dddd    dddd
                //      f  e    f       f  e    f       f
                //      f  e    f       f  e    f       f
                //  gggg    gggg            gggg    gggg

                // build dictionnary
                Dictionary<string, string> numbers = new Dictionary<string, string>();
                numbers.Add(uniqueSignals.First(s => s.Length == 2), "1");
                numbers.Add(uniqueSignals.First(s => s.Length == 4), "4");
                numbers.Add(uniqueSignals.First(s => s.Length == 3), "7");
                numbers.Add(uniqueSignals.First(s => s.Length == 7), "8");


                numbers.Add(uniqueSignals.First(s => s.Length == 5 && s.And(numbers.ByVal("1")).Length == 2), "3");

                numbers.Add(numbers.ByVal("3").CombineWith(numbers.ByVal("4")), "9");

                string lowerLeft = numbers.ByVal("8").Except(numbers.ByVal("9"));
                numbers.Add(uniqueSignals.First(s => s.Length == 5 && s.And(lowerLeft).Length == 1), "2");

                numbers.Add(uniqueSignals.First(s => s.Length == 5 && s != numbers.ByVal("2") && s != numbers.ByVal("3")), "5");

                numbers.Add(numbers.ByVal("5").CombineWith(lowerLeft), "6");

                numbers.Add(uniqueSignals.First(s => !numbers.ContainsKey(s)), "0");

                int output = Int32.Parse(string.Join("", outputValues.Select(v => numbers[v])));
                total += output;
            }

            Console.WriteLine("silver : " + total);
        }
    }
}