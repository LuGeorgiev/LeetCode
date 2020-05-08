using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongConnectedComponents
{
    public class GraphStrongComponents
    {
        private const int VERTICES_COUNT = 10;
        private static int[,] graph = new int[VERTICES_COUNT, VERTICES_COUNT]
        {
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }
        };

        private static int[] postnum = Enumerable.Repeat(0, VERTICES_COUNT).ToArray();
        private static bool[] visited = Enumerable.Repeat(false, VERTICES_COUNT).ToArray();
        private static int count = 0;

        //DFS keeping nomeration 
        private static void DFS(int currentVertex)
        {
            visited[currentVertex] = true; // mark as visited
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (!visited[i] && graph[currentVertex, i] == 1)
                {
                    DFS(i);
                    postnum[i] = count++;
                }
            }
        }

        //DFS on graph G'
        private static void BackDFS(int currentVertex)
        {
            Console.Write($"{currentVertex + 1} ");
            count++;
            visited[currentVertex] = true;
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (!visited[i] && graph[i, currentVertex] == 1)
                {
                    BackDFS(i);
                }
            }
        }

        public static void ShowStrongComponents()
        {
            while (count < VERTICES_COUNT - 1)
            {
                for (int i = 0; i < VERTICES_COUNT; i++)
                {
                    if (!visited[i])
                    {
                        DFS(i);
                    }
                }
            }

            visited = Enumerable.Repeat(false, VERTICES_COUNT).ToArray();
            count = 0;

            while (count < VERTICES_COUNT - 1)
            {
                int max = -1;
                int maxVertex = -1;
                for (int i = 0; i < VERTICES_COUNT; i++)
                {
                    if (!visited[i] && postnum[i] > max)
                    {
                        max = postnum[i];
                        maxVertex = i;
                    }
                }

                Console.Write("{ ");
                BackDFS(maxVertex);
                Console.WriteLine("}");
            }
        }

    }
}
