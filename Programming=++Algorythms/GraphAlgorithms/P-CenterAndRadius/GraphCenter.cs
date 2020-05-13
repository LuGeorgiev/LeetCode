using System;
using System.Collections.Generic;
using System.Text;

namespace P_CenterAndRadius
{
    public class GraphCenter
    {
        private const int VERICES_COUNT = 6;
        private const int MAX_WEIGHT = 100_000;
        private static int[,] graph = new int[VERICES_COUNT, VERICES_COUNT]
        {
            { 0, 1, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0 }
        };

        public static void Floyd()
        {
            //Set max wight 
            for (int row = 0; row < VERICES_COUNT; row++)
            {
                for (int col = 0; col < VERICES_COUNT; col++)
                {
                    if (graph[row, col] == 0)
                    {
                        graph[row, col] = MAX_WEIGHT;
                    }
                }
            }

            //Floyd algorithm
            for (int vertex = 0; vertex < VERICES_COUNT; vertex++)
            {
                for (int row = 0; row < VERICES_COUNT; row++)
                {
                    for (int col = 0; col < VERICES_COUNT; col++)
                    {
                        if (graph[row, col] > graph[row, vertex] + graph[vertex, col])
                        {
                            graph[row, col] = graph[row, vertex] + graph[vertex, col];
                        }
                    }
                }
            }

            for (int diagonal = 0; diagonal < VERICES_COUNT; diagonal++)
            {
                graph[diagonal, diagonal] = 0;
            }
        }

        public static void FindCenter()
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int center = -1;
            for (int row = 0; row < VERICES_COUNT; row++)
            {
                max = graph[row, 0] + graph[0, row];

                for (int col = 0; col < VERICES_COUNT; col++)
                {
                    if (row != col && (graph[row, col] + graph[col, row] > max))
                    {
                        max = graph[row, col] + graph[col, row];
                    }
                }

                if (max < min)
                {
                    min = max;
                    center = row;
                }
            }

            Console.WriteLine($"Graph center is vertex: {center + 1}");
            Console.WriteLine($"Graph radius is: {min}");
        }
    }
}
