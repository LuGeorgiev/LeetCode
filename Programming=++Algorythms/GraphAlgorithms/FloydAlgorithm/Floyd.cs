using System;
using System.Collections.Generic;
using System.Text;

namespace FloydAlgorithm
{
    public class Floyd
    {
        private const int MAX_VALUE = 100_000;

        //private static int[,] graph = new int[10, 10] 
        //{
        //    { 0, 23, 0,  0, 0,  0,  0,  8,  0, 0 },
        //    {23, 0,  0,  3, 0,  0,  34, 0,  0, 0 },
        //    { 0, 0,  0,  6, 0,  0,  0,  25, 0, 7 },
        //    { 0, 3,  6,  0, 0,  0,  0,  0,  0, 0 },
        //    { 0, 0,  0,  0, 0,  10, 0,  0,  0, 0 },
        //    { 0, 0,  0,  0, 10, 0,  0,  0,  0, 0 },
        //    { 0, 34, 0,  0, 0,  0,  0,  0,  0, 0 },
        //    { 8, 0,  25, 0, 0,  0,  0,  0,  0, 30 },
        //    { 0, 0,  0,  0, 0,  0,  0,  0,  0, 0 },
        //    { 0, 0,  7,  0, 0,  0,  0,  30, 0, 0 }
        //};

        private static int[,] graph = new int[4, 4]
       {
           { 0, 0, 6, 2}, // A
           { 0, 0, 0, 0}, // B
           { 0, 1, 0, 0}, // C
           { 0, 0, 2, 0} // D
       };

        public static void CalculateMinimumPathLengths()
        {
            SetMaxValues();

            CalculateAllPossiblePaths();

            UnMarkSelfReferentials();
        }

        public static void PrintMinimumLengths()
        {
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0}, ", graph[row, col] == MAX_VALUE ? 0 : graph[row, col]));
                }
                Console.WriteLine();
            }
        }

        private static void UnMarkSelfReferentials()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                graph[i, i] = 0;
            }
        }

        private static void CalculateAllPossiblePaths()
        {
            for (int currentVertex = 0; currentVertex < graph.GetLength(0); currentVertex++)
            {
                for (int row = 0; row < graph.GetLength(0); row++)
                {
                    for (int col = 0; col < graph.GetLength(1); col++)
                    {
                        if (graph[row, col] > graph[row, currentVertex] + graph[currentVertex, col])
                        {
                            graph[row, col] = graph[row, currentVertex] + graph[currentVertex, col];
                        }
                    }
                }
            }
        }

        private static void SetMaxValues()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] == 0)
                    {
                        graph[i, j] = MAX_VALUE;
                    }
                }
            }
        }

      
    }
}
