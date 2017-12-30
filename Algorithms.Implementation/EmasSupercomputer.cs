using System;

namespace Algorithms.Implementation
{
    public class EmasSupercomputer
    {
        private static int N;
        private static int M;

        private const int maximumPluses = 2;
        private static int currentPluses = 0;

        public static int[,] Matrix { get; private set; }

        static void Main(String[] args)
        {
            string[] lineNM = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(lineNM[0]);
            int m = Convert.ToInt32(lineNM[1]);

            Init(n, m);

            for(int i=0; i<N; i++)
            {
                string data = Console.ReadLine();
                FillLine(i, data);
            }

            int result = Process();

            Console.WriteLine(result);
        }

        public static void Init(int n, int m)
        {
            N = n;
            M = m;
            Matrix = new int[n,m];
        }

        public static void FillLine(int line, string data)
        {
            for (int i = 0; i < data.Length; i++)
                Matrix[line, i] = data[i] == 'G' ? 0 : -1;
        }

        private static bool BelowIsBad(int i, int j)
        {
            i++;

            return i == N || Matrix[i, j] == -1;
        }

        private static bool AboveIsBad(int i, int j)
        {
            i--;

            return i < 0 || Matrix[i, j] == -1;
        }

        private static bool RightIsBad(int i, int j)
        {
            j++;

            return j == M || Matrix[i, j] == -1;
        }

        private static bool LeftIsBad(int i, int j)
        {
            j--;

            return j < 0 || Matrix[i, j] == -1;
        }

        private static bool IsBorder(int i, int j)
        {
            return i == 0 || j == 0 || i == N - 1 || j == M - 1;
        }

        public static int Process()
        {
            int maximumArea = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        int areaPlus = SetPlusAndGetHisMaximumArea(i, j);

                        if (currentPluses < maximumPluses)
                        {
                            int areaAnotherPlus = Process();

                            int multipliedArea = areaPlus * areaAnotherPlus;

                            if (maximumArea < multipliedArea)
                                maximumArea = multipliedArea;
                        }
                        else
                        {
                            if (maximumArea < areaPlus)
                                maximumArea = areaPlus;
                        }

                        RemovePlus(i, j);
                    }
                }
            }

            return maximumArea;
        }

        public static int SetPlusAndGetHisMaximumArea(int i, int j)
        {
            int area = 1;
            int c = 0;

            do
            {
                if (!LeftIsBad(i, j - (1 * c)) 
                    && !AboveIsBad(i - (1 * c), j) 
                    && !RightIsBad(i, j + (1 * c)) 
                    && !BelowIsBad(i + (1 * c), j))
                {
                    area += 4;
                    SetSideCells(i, j, distance: ++c, value: -1);
                }
                else
                {
                    break;
                }
            }
            while (true);

            Matrix[i, j] = area;
            currentPluses++;

            return area;
        }

        private static void SetSideCells(int i, int j, int distance, int value)
        {
            Matrix[i, j - (1 * distance)] = value;
            Matrix[i - (1 * distance), j] = value;
            Matrix[i, j + (1 * distance)] = value;
            Matrix[i + (1 * distance), j] = value;
        }

        public static void RemovePlus(int i, int j)
        {
            int area = Matrix[i, j];

            Matrix[i, j] = 0;

            int c = 0;
            while(area > 1)
            {
                area -= 4;
                SetSideCells(i, j, distance: ++c, value: 0);
            }

            currentPluses--;
        }
    }
}
