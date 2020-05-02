using System;
using System.Collections.Generic;
using System.Text;

namespace FindAllSimplePaths
{
    public class AllPaths
    {
        private const int VERTECES_COUNT = 14;

        private static readonly bool[,] graph = new bool[VERTECES_COUNT, VERTECES_COUNT]
        {
            {false, true, false, false, false, false, false, false, false, false, false, false, false, false},
            {true, false, true, true, true, false, false, false, false, false, false, false, false, false},
            {false, true, false, false, false, true, false, false, false, false, false, false, false, false},
            {false, true, false, false, false, false, false, false, false, false, false, true, false, false},
            {false, true, false, false, false, false, true, false, false, false, false, false, false, false},
            {false, false, true, false, false, false, true, false, false, false, false, true, false, false},
            {false, false, false, false, true, true, false, false, false, true, false, false, false, false},
            {false, false, false, false, false, false, false, false, true, false, false, false, false, false},
            {false, false, false, false, false, false, false, true, false, false, false, false, true, true},
            {false, false, false, false, false, false, true, false, false, false, true, false, false, false},
            {false, false, false, false, false, false, false, false, false, true, false, false, false, false},
            {false, false, false, true, false, true, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, true, false, false, false, false, true},
            {false, false, false, false, false, false, false, false, true, false, false, false, true, false}
        };

        private static readonly bool[] visited = new bool[VERTECES_COUNT];
        private static readonly int[] path = new int[VERTECES_COUNT];
        private static int count = 0;

        public static void FindAllPathsBetween(int starVertex, int endVertex)
        {
            AllDfs(starVertex, endVertex);
        }

        private static void AllDfs(int currentVertex, int targetVertex)
        {
            if (currentVertex == targetVertex)
            {
                path[count] = targetVertex;
                PrintPath();
                return;
            }

            visited[currentVertex] = true;
            path[count++] = currentVertex;
            for (int col = 0; col < graph.GetLength(1); col++)
            {
                if (graph[currentVertex, col] && ! visited[col])
                {
                    AllDfs(col, targetVertex);
                }
            }
            visited[currentVertex] = false;
            count--;
        }

        private static void PrintPath()
        {
            var currentPath = new List<int>();
            for (int i = 0; i <= count; i++)
            {
                currentPath.Add(path[i] + 1);
            }
            Console.WriteLine(string.Join(" => ", currentPath));
        }
    }
}
