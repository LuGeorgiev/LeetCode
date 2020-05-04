using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimalHamiltonCycle
{
    public class HamiltonCycles
    {
        //Фигура 5.4.4. Минимален Хамилтонов цикъл. page 293

        private const byte VERTEX_COUNT = 6;
        private static int[,] graph = new int[VERTEX_COUNT, VERTEX_COUNT]
        {
            { 0, 5, 0, 0, 7, 7 },
            { 5, 0, 5, 0, 0, 0 },
            { 0, 5, 0, 6, 5, 0 },
            { 0, 0, 6, 0, 3, 3 },
            { 7, 0, 5, 3, 0, 5 },
            { 7, 0, 0, 3, 5, 0 }
        };

        private static bool[] visited = Enumerable.Repeat(false, VERTEX_COUNT).ToArray();
        private static int[] minCycle = Enumerable.Repeat(-1, VERTEX_COUNT).ToArray();
        private static int[] currentCycle = Enumerable.Repeat(-1, VERTEX_COUNT).ToArray();
        private static int minSum = 0;
        private static int currentSum = 0;
        private static int staringVertex = -1;

        private static void PrintCycle()
        {
            Console.WriteLine("Minimalian Hamiltonian cycle:");
            for (int i = 0; i < VERTEX_COUNT -1; i++)
            {
                Console.Write($"{minCycle[i] + 1} => ");
            }
            Console.WriteLine($"{staringVertex + 1}, with length: {minSum}");
        }

        private static void Hamilton(int currentVertex, int level)
        {
            if (currentVertex == staringVertex && level > 0)
            {
                if (level == VERTEX_COUNT)
                {
                    minCycle = currentCycle;
                }

                return;
            }

            if (visited[currentVertex])
            {
                return;
            }

            visited[currentVertex] = true;
            for (int nextVertex = 0; nextVertex < VERTEX_COUNT; nextVertex++)
            {
                if (graph[currentVertex, nextVertex] > 0 && nextVertex != currentVertex)
                {
                    currentCycle[level] = nextVertex;
                    currentSum += graph[currentVertex, nextVertex];
                    if (currentSum < minSum)
                    {
                        Hamilton(nextVertex, level + 1);
                    }
                    currentSum -= graph[currentVertex, nextVertex];
                }
            }
            visited[currentVertex] = false;
        }

        public static void FindHamiltonCycle(int startVertex)
        {
            minSum = int.MaxValue;
            staringVertex = startVertex - 1;
            currentCycle[0] = startVertex;
            Hamilton(staringVertex, 0);
            PrintCycle();
        }
    }
}
