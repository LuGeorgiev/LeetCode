using System;
using System.Linq;

namespace ComanyControl
{
    class Program
    {
        private const int COMPANIES = 6;
        private const int OWNER = 1;

        //Фигура 5.5.4. Ориентиран претеглен граф. p309
        private static int[,] graph = new int[COMPANIES, COMPANIES] 
        {
            { 0, 6, 10, 20, 55, 20 },
            { 0, 0, 0, 0, 0, 25 },
            { 0, 0, 0, 0, 0, 10 },
            { 0, 45, 0, 0, 0, 0 },
            { 0, 0, 0, 31, 0, 0 },
            { 0, 0, 0, 0, 0, 0 }
        };
        private static int[] controls = Enumerable.Repeat(0, COMPANIES).ToArray();
        private static bool[] visited = Enumerable.Repeat(false, COMPANIES).ToArray();

        static void Main(string[] args)
        {
            Solve();
            PrintResult();
        }

        private static void Solve()
        {
            for (int i = 0; i < COMPANIES; i++)
            {
                controls[i] = graph[OWNER - 1, i];
            }

            for (int i = 0; i < COMPANIES; i++)
            {
                AddControlShare();
            }
        }

        private static void AddControlShare()
        {
            for (int i = 0; i < COMPANIES; i++)
            {
                if (controls[i] > 50 && !visited[i])
                {
                    for (int j = 0; j < COMPANIES; j++)
                    {
                        controls[j] += graph[i, j];
                    }
                    visited[i] = true;
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Company {OWNER} controls the following companies:");
            for (int i = 0; i < COMPANIES; i++)
            {
                if (controls[i] > 50)
                {
                    Console.WriteLine($"{i +1 }: {controls[i]}%");
                }
            }
        }
    }
}
