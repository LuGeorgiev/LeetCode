using System;
using System.Collections.Generic;
using System.Text;

namespace EulerGraphAlgorithm
{
    public class Euler
    {
        private const byte VERTEX_COUNT = 8;
        private static bool[,] graph = new bool[VERTEX_COUNT, VERTEX_COUNT]
        {
            { false, true,  false, false, false, false, false, false },
            { false, false, true,  false, true,  false, false, false },
            { false, false, false, true,  true,  false, true,  false },
            { false, true,  false, false, false, false, false, false },
            { false, false, true,  false, false, true,  false, false },
            { false, false, true,  false, false, false, false, false },
            { false, false, false, false, false, false, false, true },
            { true,  false, false, false, false, false, false, false }
        };

        public static bool IsEulerGraph()
        {   
            for (int row = 0; row < VERTEX_COUNT; row++)
            {
                int inEdge = 0;
                int outEdge = 0;

                for (int col = 0; col < VERTEX_COUNT; col++)
                {
                    if (graph[row, col])
                    {
                        inEdge++;
                    }

                    if (graph[col, row])
                    {
                        outEdge++;
                    }
                }

                if (inEdge != outEdge)
                {
                    return false;
                }
            }

            return true;
        }

        public static void FindEulerCycle(int startVertex)
        {
            var currentCycle = new Stack<int>();
            var mergeCycle = new Stack<int>();

            currentCycle.Push(startVertex);
            while (currentCycle.Count > 0)
            {
                var currentVertex = currentCycle.Peek();
                int otherVertex;
                for (otherVertex = 0; otherVertex < VERTEX_COUNT; otherVertex++)
                {
                    if (graph[currentVertex, otherVertex])
                    {
                        graph[currentVertex, otherVertex] = false;
                        currentVertex = otherVertex;
                        break;
                    }
                }

                if (otherVertex < VERTEX_COUNT)
                {
                    currentCycle.Push(otherVertex);
                }
                else
                {
                    mergeCycle.Push(currentCycle.Pop());
                }
            }

            Console.WriteLine("Euler cycle is:");
            while (mergeCycle.Count > 0)
            {
                Console.Write($"{mergeCycle.Pop() + 1} ");
            }
            Console.WriteLine();
        }
    }
}
