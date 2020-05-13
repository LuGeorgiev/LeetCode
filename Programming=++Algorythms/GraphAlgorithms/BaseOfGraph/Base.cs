using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseOfGraph
{
    public class Base
    {
        //Фигура 5.7.4. Ориентиран граф. p337
        private const int VERTICES_COUNT = 9;
        private static bool[,] graph = new bool[VERTICES_COUNT, VERTICES_COUNT]
        {
            { false, false, false, false, false, false, false, false, false },
            { true,  false, true,  false, false, false, false, false, false },
            { true,  false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, true,  false },
            { false, false, false, false, false, true,  false, false, false },
            { false, false, false, true,  true,  false, false, false, false },
            { false, false, false, false, false, false, false, false, false },
            { true,  false, false, false, false, true,  false, false, false },
            { false, true,  false, false, false, false, false, false, false }
        };

        private static bool[] visited = new bool[VERTICES_COUNT];
        private static bool[] baseVector = Enumerable.Repeat(true, VERTICES_COUNT).ToArray();

        private static void DFS(int currentVertex)
        {
            visited[currentVertex] = true;
            for (int col = 0; col < VERTICES_COUNT; col++)
            {
                if (graph[currentVertex, col] && !visited[col])
                {
                    baseVector[col] = false;
                    DFS(col);
                }
            }
        }

        public static void FindBase()
        {
            for (int vertex = 0; vertex < VERTICES_COUNT; vertex++)
            {
                if (baseVector[vertex])
                {
                    visited = new bool[VERTICES_COUNT];
                    DFS(vertex);
                }
            }
        }

        public static void Print()
        {
            Console.WriteLine("Vertices that forms the base are:");
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (baseVector[i])
                {
                    Console.Write($"{i + 1} ");
                }
            }
        }
    }
}
