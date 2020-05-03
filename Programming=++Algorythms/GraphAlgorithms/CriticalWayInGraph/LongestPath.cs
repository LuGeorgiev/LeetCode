using System;
using System.Linq;

namespace CriticalWayInGraph
{
    public class LongestPath
    {
        private const int VERTECIES_COUNT = 6;

        private static int[,] graph = new int[VERTECIES_COUNT, VERTECIES_COUNT]
        {
            { 0, 12, 0, 0, 0,  0 },
            { 0, 0, 40, 0, 17, 0 },
            { 0, 0, 0,  0, 0,  0 },
            { 0, 0, 0,  0, 30, 0 },
            { 0, 0, 0,  0, 0,  20 },
            { 0, 0, 20, 0, 0,  0 }
        };

        private static int[] savedPath = Enumerable.Repeat(-1, VERTECIES_COUNT).ToArray();
        private static int[] maxDistance = Enumerable.Repeat(0, VERTECIES_COUNT).ToArray();

        public static void Solve()
        {
            for (int i = 0; i < VERTECIES_COUNT; i++)
            {
                if (maxDistance[i] == 0)
                {
                    DFS(i);
                }
            }

            int maxVertex = 0;
            for (int i = 0; i < VERTECIES_COUNT; i++)
            {
                if (maxDistance[i] > maxDistance[maxVertex])
                {
                    maxVertex = i;
                }
            }

            Console.WriteLine($"Longest path value is: {maxDistance[maxVertex]}");
            Console.Write($"Max Path is: ");
            while (savedPath[maxVertex] >= 0)
            {
                Console.Write($"{maxVertex + 1} ");
                maxVertex = savedPath[maxVertex];
            }
            Console.Write($"{maxVertex + 1}");
        }

        private static void DFS(int vertex)
        {
            if (maxDistance[vertex] > 0)
            {
                return;
            }

            var max = maxDistance[vertex];
            for (int j = 0; j < VERTECIES_COUNT; j++)
            {
                if (graph[vertex, j] > 0)
                {
                    DFS(j);
                    var distance = maxDistance[j] + graph[vertex, j];
                    if (distance > max)
                    {
                        max = distance;
                        savedPath[vertex] = j;
                    }
                }
            }

            maxDistance[vertex] = max;
        }
    }
}
