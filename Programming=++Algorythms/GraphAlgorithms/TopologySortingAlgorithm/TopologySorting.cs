using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopologySortingAlgorithm
{
    class TopologySorting
    {
        private const int VERTECES_COUNT = 5;
        private static bool[,] graph = new bool[VERTECES_COUNT, VERTECES_COUNT]
        {
            { false, true,  false, false, false },
            { false, false, true,  false, true },
            { false, false, false, true,  false },
            { false, false, false, false, false },
            { false, false, true,  false, false }
        };
        private static bool[] visited = Enumerable.Repeat(false, VERTECES_COUNT).ToArray();
        private static List<int> path = new List<int>();

        public static void FingTopologicatSort()
        {
            Console.WriteLine("Toplogy sort:");
            for (int i = 0; i < VERTECES_COUNT; i++)
            {
                if (!visited[i])
                {
                    DFS(i);
                }
            }
            path.Reverse();
            Console.WriteLine(string.Join(" => ", path));
        }

        private static void DFS(int currentVertex)
        {
            visited[currentVertex] = true;
            for (int i = 0; i < VERTECES_COUNT; i++)
            {
                if (!visited[i] && graph[currentVertex, i])
                {
                    DFS(i);
                }
            }
            path.Add(currentVertex);
        }
    }
}
