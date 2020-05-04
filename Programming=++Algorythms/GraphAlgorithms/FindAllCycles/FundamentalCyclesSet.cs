using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAllCycles
{
    public class FundamentalCyclesSet
    {
        private const int VERTEX_COUNT = 6;

        //Фигура 5.4.3. Фундаментално множество от цикли в граф.
        private static char[,] graph = new char[VERTEX_COUNT, VERTEX_COUNT]
        {
            { '0', '1', '1', '0', '0', '0' },
            { '1', '0', '1', '1', '0', '0' },
            { '1', '1', '0', '0', '0', '1' },
            { '0', '1', '0', '0', '1', '1' },
            { '0', '0', '0', '1', '0', '1' },
            { '0', '0', '1', '1', '1', '0' }
        };

        private static bool[] visited = Enumerable.Repeat(false, VERTEX_COUNT).ToArray();
        private static int[] cycle = Enumerable.Repeat(-1, VERTEX_COUNT).ToArray();
        private static int cycleIndex = 0;

        private static void FindSpanningTree(int currentVertex)
        {
            visited[currentVertex] = true;
            for (int otherVertex = 0; otherVertex < VERTEX_COUNT; otherVertex++)
            {
                if (!visited[otherVertex] && graph[currentVertex, otherVertex] == '1')
                {
                    // This vertex is part of the spanning tree
                    graph[currentVertex, otherVertex] = '2';
                    graph[otherVertex, currentVertex] = '2';

                    FindSpanningTree(otherVertex);
                }
            }
        }

        private static void FindCycle(int startVertex, int endVertex)
        {
            if (startVertex == endVertex)
            {
                PrintCycle();
                return;
            }

            visited[startVertex] = true;

            for (int otherVertex = 0; otherVertex < VERTEX_COUNT; otherVertex++)
            {
                if (!visited[otherVertex] && graph[startVertex, otherVertex] == '2')
                {
                    cycle[cycleIndex++] = otherVertex;
                    FindCycle(otherVertex, endVertex);
                    cycleIndex--;
                }
            }
        }

        private static void PrintCycle()
        {
            for (int i = 0; i < cycleIndex; i++)
            {
                Console.Write($"{cycle[i] + 1} ");
            }
            Console.WriteLine(); 
        }

        public static void FindAllCycles()
        {
            FindSpanningTree(0);
            Console.WriteLine("Simple cycles in the graph are:");

            for (int i = 0; i < VERTEX_COUNT - 1; i++)
            {
                for (int j = i + 1; j < VERTEX_COUNT; j++)
                {
                    if (graph[i, j] == '1')
                    {
                        visited = Enumerable.Repeat(false, VERTEX_COUNT).ToArray();
                        cycleIndex = 1;
                        cycle[0] = i;
                        FindCycle(i, j);
                    }
                }
            }
        }
    }
}
