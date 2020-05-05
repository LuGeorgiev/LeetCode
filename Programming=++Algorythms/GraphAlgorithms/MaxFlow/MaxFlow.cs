using System;
using System.Linq;

namespace MaxFlowAlgorithm
{
    public class MaxFlow
    {
        //Фигура 5.4.6б. Максимален поток в граф. p.300
        //Ford-Fulkerson Algorithm

        private const byte VERTEX_COUNT = 6;
        private const byte SOURCE = 1;
        private const byte TARGET = 6;
        private const int MAX_FLOW_VALUE = 100_000;

        private static int[,] graph = new int[VERTEX_COUNT, VERTEX_COUNT ]
        {
            { 0, 5, 5, 10, 0, 0 },
            { 0, 0, 4, 0, 0, 5 },
            { 0, 0, 0, 0, 7, 0 },
            { 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 8 },
            { 0, 0, 0, 0, 0, 0 }
        };

        private static int[,] flowGraph = new int[VERTEX_COUNT, VERTEX_COUNT];
        private static int[] path = Enumerable.Repeat(-1, VERTEX_COUNT).ToArray();
        private static bool[] visited = Enumerable.Repeat(false, VERTEX_COUNT).ToArray();
        private static bool found;

        private static void UpdateFlow(int level)
        {
            int incrementFlow = MAX_FLOW_VALUE;
            Console.WriteLine("Increasing path was found");

            for (int i = 0; i < level; i++)
            {
                int first = path[i];
                int second = path[i + 1];
                Console.Write($"{first +1}, ");
                if (incrementFlow > graph[first, second])
                {
                    incrementFlow = graph[first, second];
                }
            }
            Console.WriteLine($"{path[level] +1}");

            for (int i = 0; i < level; i++)
            {
                int first = path[i];
                int second = path[i + 1];
                flowGraph[first, second] += incrementFlow;
                flowGraph[second, first] -= incrementFlow;
                graph[first, second] -= incrementFlow;
                graph[second, first] += incrementFlow;
            }
        }

        public static void CalculateMaxFlow()
        {  
            //Initialize flow graph
            for (int i = 0; i < VERTEX_COUNT; i++)
            {
                for (int j = 0; j < VERTEX_COUNT; j++)
                {
                    flowGraph[i, j] = 0;
                }
            }

            //find next increasing path if possible
            do
            {
                //Mark all verteces as not visited
                for (int i = 0; i < VERTEX_COUNT; i++)
                {
                    visited[i] = false;
                }

                found = false;
                visited[SOURCE - 1] = true;
                path[0] = SOURCE - 1;
                DFS(SOURCE - 1, 1);

            } while (found);

            Console.WriteLine("Max flow is:");
            for (int i = 0; i < VERTEX_COUNT; i++)
            {
                for (int j = 0; j < VERTEX_COUNT; j++)
                {
                    Console.Write($"{flowGraph[i,j]}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int maxFlow = 0;
            for (int i = 0; i < VERTEX_COUNT; i++)
            {
                maxFlow += flowGraph[i, TARGET - 1];
            }
            Console.WriteLine($"With capacity: {maxFlow}");

        }

        private static void DFS(int vertex, int level)
        {
            if (found)
            {
                return;
            }

            if (vertex == TARGET - 1)
            {
                found = true;
                UpdateFlow(level - 1);
            }
            else
            {
                for (int i = 0; i < VERTEX_COUNT; i++)
                {
                    if (!visited[i] && graph[vertex, i] > 0)
                    {
                        visited[i] = true;
                        path[level] = i;
                        DFS(i, level + 1);
                        if (found)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
