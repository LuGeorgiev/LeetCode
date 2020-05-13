using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimAlgorithm
{
    public class MinimalSpanningTree
    {
        private const int VERTICES_COUNT = 9;
        private const int MAX_VALUE = 100_000;

        private static int[,] graph = new int[VERTICES_COUNT, VERTICES_COUNT]
        {
            { 0, 1,  0, 2,  0,  0,  0,  0, 0 },
            { 1, 0,  3, 0,  13, 0,  0,  0, 0 },
            { 0, 3,  0, 4,  0,  3,  0,  0, 0 },
            { 2, 0,  4, 0,  0,  16, 14, 0, 0 },
            { 0, 13, 0, 0,  0,  12, 0,  1, 13 },
            { 0, 0,  3, 16, 12, 0,  1,  0, 1 },
            { 0, 0,  0, 14, 0,  1,  0,  0, 0 },
            { 0, 0,  0, 0,  1,  0,  0,  0, 0 },
            { 0, 0,  0, 0,  13, 1,  0,  0, 0 }
        };
        
        private static bool[] visited = new bool[VERTICES_COUNT];
        private static int[] previous = Enumerable.Repeat(0, VERTICES_COUNT).ToArray();
        private static int[] distances = Enumerable.Repeat(MAX_VALUE, VERTICES_COUNT).ToArray();

        public static void Prim()
        {
            int mstCost = 0;

            //choose starting Vertex
            visited[0] = true;
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                distances[i] = graph[0, i] > 0 
                                    ? graph[0, i]
                                    : MAX_VALUE;
            }

            for (int k = 0; k < VERTICES_COUNT -1 ; k++)
            {
                // find next minimal edge
                int minDistance = MAX_VALUE;
                int minDistanceIndex = -1;
                for (int i = 0; i < VERTICES_COUNT; i++)
                {
                    if (! visited[i] && distances[i] < minDistance)
                    {
                        minDistance = distances[i];
                        minDistanceIndex = i;
                    }
                }

                visited[minDistanceIndex] = true;
                Console.Write($"({previous[minDistanceIndex] + 1}, {minDistanceIndex + 1}) ");
                mstCost += minDistance;

                for (int i = 0; i < VERTICES_COUNT; i++)
                {
                    if (! visited[i] && graph[minDistanceIndex, i] > 0 && distances[i] > graph[minDistanceIndex, i])
                    {
                        distances[i] = graph[minDistanceIndex, i];
                        previous[i] = minDistanceIndex;
                    }
                }
            }

            Console.WriteLine($"\n The cost of the minimal spanning tree is: {mstCost}");
        }
    }
}
