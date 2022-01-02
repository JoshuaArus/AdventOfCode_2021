using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string classRegex = @"^AdventOfCode\.day[0-9]{1}$";

            foreach (
                string classe in
                    Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Select(t => t.FullName)
                    .Where(s => Regex.IsMatch(s, classRegex)))
            {
                Console.WriteLine(classe);
                try
                {
                    Activator.CreateInstance(null, classe);
                }
                catch (Exception)
                {
                    //osef
                }
                Console.WriteLine();
            }
        }
    }
}
