using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectedComponents
{
    public class ConnectedGraphs
    {
        private const int VERTECIES_COUNT = 6;
        private static bool[,] graph = new bool[VERTECIES_COUNT, VERTECIES_COUNT]
        {
            { false, true, true, false, false, false },
            { true, false, true, false, false, false },
            { true, true, false, false, false, false },
            { false, false, false, false, true, true },
            { false, false, false, true, false, true },
            { false, false, false, true, true, false }
        };

        private static bool[] visited = Enumerable.Repeat(false, VERTECIES_COUNT).ToArray();

        private static void DFS(int currentVertex)
        {
            visited[currentVertex] = true;
            Console.Write($"{currentVertex + 1} ");
            for (int i = 0; i < VERTECIES_COUNT; i++)
            {
                if (!visited[i] && graph[currentVertex, i])
                {
                    DFS(i);
                }
            }
        }

        public static void FindConnectedComponents()
        {
            Console.WriteLine("Bellow are all connected composnents");
            int components = 0;
            for (int i = 0; i < VERTECIES_COUNT; i++)
            {
                if (!visited[i])
                {
                    components++;
                    Console.Write("{ ");
                    DFS(i);
                    Console.WriteLine("}");
                }
            }

            if (components > 1)
            {
                Console.WriteLine($"There are {components} connected components!");
            }
            else
            {
                Console.WriteLine("The graph i sfully connected");
            }
        }
    }
}
