using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximalIndependantSets
{
    public class MaxIndependant
    {
        //Фигура 5.7.2. Неориентиран граф.  p.331

        private const int VERTECIES_COUNT = 8;
        private static bool[,] graph = new bool[VERTECIES_COUNT, VERTECIES_COUNT]
        {
            { false, true,  false, false, false, true,  false, true },
            { true,  false, true,  false, false, true,  false, false },
            { false, true,  false, true,  true,  false, false, false },
            { false, false, true,  false, true,  false, true,  false },
            { false, false, true,  true,  false, true,  false, false },
            { true,  true,  false, false, true,  false, true,  true },
            { false, false, false, true,  false, true,  false, false },
            { true,  false, false, false, false, true,  false, false }
        };

        private static bool[] independantSet = new bool[VERTECIES_COUNT]; //T
        private static int[] adjancedNodes = new int[VERTECIES_COUNT]; //S

        private static int independatCount = 0;
        private static int adjancedCount = 0;

        private static void PrintSet()
        {
            Console.Write("{ ");
            for (int i = 0; i < VERTECIES_COUNT; i++)
            {
                if (independantSet[i])
                {
                    Console.Write($"{i + 1} ");
                }
            }
            Console.WriteLine("}");
        }

        public static void FindMaxSubset(int lastNode)
        {
            if (independatCount + adjancedCount == VERTECIES_COUNT)
            {
                PrintSet();
                return;
            }

            for (int i = lastNode; i < VERTECIES_COUNT; i++)
            {
                if (!independantSet[i] && adjancedNodes[i] == 0)
                {
                    for (int j = 0; j < VERTECIES_COUNT; j++)
                    {
                        if (graph[i, j] && adjancedNodes[j] == 0)
                        {
                            adjancedNodes[j] = lastNode + 1;
                            adjancedCount++;
                        }
                    }

                    independantSet[i] = true;
                    independatCount++;

                    FindMaxSubset(i + 1);

                    independantSet[i] = false;
                    independatCount--;
                    for (int j = 0; j < VERTECIES_COUNT; j++)
                    {
                        if (adjancedNodes[j] == lastNode + 1)
                        {
                            adjancedNodes[j] = 0;
                            adjancedCount--;
                        }
                    }
                }
            }
        }

    }
}
