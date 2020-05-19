using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestSimplePathInOrientedGraph
{
    public class LongestPath
    {
        private const int VERTECIES_COUNT = 6;
        private static int[,] graph = new int[VERTECIES_COUNT, VERTECIES_COUNT]
        {
            { 0, 10, 0, 5, 0, 0 },
            { 0, 0, 5, 0, 0, 15 },
            { 0, 0, 0, 10, 5, 0 },
            { 0, 10, 0, 0, 10, 0 },
            { 0, 5, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 }
        };

        private static int[] vertexVector = Enumerable.Repeat(0, VERTECIES_COUNT).ToArray();
        private static int[] savedPath = Enumerable.Repeat(0, VERTECIES_COUNT).ToArray();
        private static bool[] visited = Enumerable.Repeat(false, VERTECIES_COUNT).ToArray();
        private static int maxLen = 0;
        private static int tempLen = 0;
        private static int si = 0;
        private static int ti = 0;

        public static void Find()
        {
            si = 0;
            ti = 1;
            for (int vertex = 0; vertex < VERTECIES_COUNT; vertex++)
            {
                visited[vertex] = true;
                vertexVector[0] = vertex;
                AddVertex(vertex);
                visited[vertex] = false;
            }

            Console.WriteLine("Longest path is:");
            for (int i = 0; i < si; i++)
            {
                Console.Write($"{savedPath[i] + 1} ");
            }
            Console.WriteLine($"\nWith toral length: {maxLen}");
        }

        private static void AddVertex(int vertex)
        {
            //longer path was found
            if (tempLen > maxLen)
            {
                maxLen = tempLen;
                for (int i = 0; i <= ti; i++)
                {
                    savedPath[i] = vertexVector[i];
                }
                si = ti;
            }

            for (int col = 0; col < VERTECIES_COUNT; col++)
            {
                if (!visited[col] && graph[vertex, col] > 0)
                {
                    tempLen += graph[vertex, col];
                    visited[col] = true;
                    vertexVector[ti++] = col;
                    AddVertex(col);

                    visited[col] = false;
                    tempLen -= graph[vertex, col];
                    ti--;
                }
            }
        }
    }
}
