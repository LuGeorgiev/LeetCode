using System;
using System.Linq;

namespace DjiikstraAlgorithm
{
    public class Djiikstra
    {
        private const int VERTEICES_COUNT = 10;
        private const int NO_PARENT = -1;
        private const int MAX_VALUE = 100_000;

        private static int[,] graph = new int[VERTEICES_COUNT, VERTEICES_COUNT]
        {
            { 0, 23, 0,  0,  0,  0,  0,  8,  0, 0  },
            {23, 0,  0,  3,  0,  0,  34, 0,  0, 0  },
            { 0, 0,  0,  6,  0,  0,  0,  25, 0, 7  },
            { 0, 3,  6,  0,  0,  0,  0,  0,  0, 0  },
            { 0, 0,  0,  0,  0,  10, 0,  0,  0, 0  },
            { 0, 0,  0,  0,  10, 0,  0,  0,  0, 0  },
            { 0, 34, 0,  0,  0,  0,  0,  0,  0, 0  },
            { 8, 0,  25, 0,  0,  0,  0,  0,  0, 30 },
            { 0, 0,  0,  0,  0,  0,  0,  0,  0, 0  },
            { 0, 0,  7,  0,  0,  0,  0,  30, 0, 0  }
        };

        private static int[] distance = Enumerable.Repeat(MAX_VALUE, VERTEICES_COUNT).ToArray();
        private static int[] previous = Enumerable.Repeat(NO_PARENT, VERTEICES_COUNT).ToArray();
        private static int[] vertices = Enumerable.Repeat(1, VERTEICES_COUNT).ToArray();

        public static void FindMinimalPathsFrom(int startNode)
        {
            for (int i = 0; i < graph.GetLength(0); i++) // distance inicialization
            {
                if (graph[startNode,i] == 0)
                {
                    distance[i] = MAX_VALUE;
                    previous[i] = NO_PARENT;
                }
                else
                {
                    distance[i] = graph[startNode, i];
                    previous[i] = startNode;
                }
            }

            vertices[startNode] = 0; //exclude start vertex
            previous[startNode] = NO_PARENT;

            while (true) //while vertecies contains value lower than MAX_VALUE
            {
                // choose vertex j from verteces with distance[ j ] is minimal
                int j = NO_PARENT;
                int di = MAX_VALUE;
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (vertices[i] == 1 && distance[i] < di)
                    {
                        di = distance[i];
                        j = i;
                    }
                }
                if (j == NO_PARENT)
                {
                    break;
                }

                vertices[j] = 0; //exclude j

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (vertices[i] == 1 && graph[j,i] != 0)
                    {
                        if (distance[i] > distance[j] + graph[j, i])
                        {
                            distance[i] = distance[j] + graph[j, i];
                            previous[i] = j;
                        }
                    }

                }

            }
        }

        public static void PrintResults(int startNode)
        {
            for (int i = 0; i < VERTEICES_COUNT; i++)
            {
                if (i != startNode)
                {
                    if (distance[i] == MAX_VALUE)
                    {
                        Console.WriteLine($"No path between {startNode } and {i} ");
                    }
                    else
                    {
                        Console.Write($"Minimal path between {startNode } and {i }: {startNode}, ");
                        PrintPath(startNode, i);
                        Console.WriteLine($"Distance is: {distance[i]}");
                    }
                }
            }
        }

        private static void PrintPath(int start, int end)
        {
            if (previous[end] != start)
            {
                PrintPath(start, previous[end]);
            }
            Console.Write($"{end}, ");
        }
    }
}
