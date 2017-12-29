using System;
using System.Collections.Generic;

namespace HackerRank
{
    class Program
    {
        static List<IRunnable> programs = new List<IRunnable>()
        {
            new TheCoinChangeProblem()
        };

        static void Main(string[] args)
        {
            for (int i = 0; i < programs.Count; i++)
            {
                IRunnable p = programs[i];

                Console.WriteLine(String.Format("{0} {1}", i, p));
            }

            Console.WriteLine();
            Console.WriteLine("Select: ");

            int selection = Convert.ToInt32(Console.ReadLine());
            IRunnable program = programs[selection];

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Running: " + program.ToString());
                Console.ResetColor();

                program.Run();
            }
        }
    }
}
