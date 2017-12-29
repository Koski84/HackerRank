using System;
using System.Collections.Generic;

namespace HackerRank
{
    // https://www.hackerrank.com/challenges/coin-change/problem
    class TheCoinChangeProblem : IRunnable
    {
        static int llamadas_totales = 0;
        static int almacen_usos = 0;

        // Warehouse to store subproblems
        private static Dictionary<KeyValuePair<long, int>, long> warehouse = new Dictionary<KeyValuePair<long, int>, long>();

        static long GetWays(long n, long[] c)
        {
            return GetWays(n, c, 0);
        }

        private static long GetWays(long n, long[] c, int i /* Last used coin position*/)
        {
            llamadas_totales++;

            if (n == 0)
                return 1;

            var key = new KeyValuePair<long, int>(n, i);
            if (warehouse.ContainsKey(key))
            {
                almacen_usos++;
                return warehouse[key];
            }

            long res = 0;

            // we got coins greater or equal than the previus one
            for (; i < c.Length; i++)
            {
                long coin = c[i];

                // Call recursively
                if (coin <= n)
                    res += GetWays(n - coin, c, i);
            }

            // Store the result in the warehouse
            warehouse.Add(key, res);

            return res;
        }

        public void Run()
        {
            Console.Write("n: ");
            long n = Convert.ToInt64(Console.ReadLine());

            Console.Write("c: ");
            long[] c = Array.ConvertAll<string, long>(Console.ReadLine().Split(' '), Int64.Parse);

            warehouse.Clear();

            Console.WriteLine("result: " + GetWays(n, c));
            Console.WriteLine("{0} llamadas_totales. {1} usos almacen.", llamadas_totales, almacen_usos);
        }
    }
}
