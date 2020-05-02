using System;
using System.Collections.Generic;
using System.Text;

namespace CheckForCycles
{
    public class CheckCycles
    {
        private const int VERTECES_COUNT = 14;

        private static readonly bool[,] graph = new bool[VERTECES_COUNT, VERTECES_COUNT]
        {
            {false, true, false, false, false, false, false, false, false, false, false, false, false, false},
            {true, false, true, true, true, false, false, false, false, false, false, false, false, false},
            {false, true, false, false, false, true, false, false, false, false, false, false, false, false},
            {false, true, false, false, false, false, false, false, false, false, false, true, false, false},
            {false, true, false, false, false, false, true, false, false, false, false, false, false, false},
            {false, false, true, false, false, false, true, false, false, false, false, true, false, false},
            {false, false, false, false, true, true, false, false, false, true, false, false, false, false},
            {false, false, false, false, false, false, false, false, true, false, false, false, false, false},
            {false, false, false, false, false, false, false, true, false, false, false, false, true, true},
            {false, false, false, false, false, false, true, false, false, false, true, false, false, false},
            {false, false, false, false, false, false, false, false, false, true, false, false, false, false},
            {false, false, false, true, false, true, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, true, false, false, false, false, true},
            {false, false, false, false, false, false, false, false, true, false, false, false, true, false}
        };

        private static readonly bool[] visited = new bool[VERTECES_COUNT];
        private static bool cyclesExist = false;
                        

        public static bool HasCicles()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (! visited[i])
                {
                    DFS(i, -1);

                    if (cyclesExist)
                    {
                        break;
                    }
                }
            }

            return cyclesExist;
        }

        private static void DFS(int currentVertex, int parentVertex)
        {
            visited[currentVertex] = true;

            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[currentVertex, i] )
                {
                    if (visited[i] && i != parentVertex)
                    {
                        cyclesExist = true;
                        return;
                    }
                    else if (i != parentVertex)
                    {
                        DFS(i, currentVertex);
                    }
                }
               
            }
        }
    }
}
