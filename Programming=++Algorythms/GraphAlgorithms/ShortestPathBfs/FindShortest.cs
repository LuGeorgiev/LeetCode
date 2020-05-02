using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPathBfs
{
    public class FindShortest
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

        private static readonly int[] wayBack = Enumerable.Repeat(-1, VERTECES_COUNT).ToArray();

        private static readonly List<int> path = new List<int>();

        public static void FindShortesPath(int startNode, int targetNode)
        {
            BFS(startNode, targetNode);

            if (wayBack[targetNode] != -1)
            {
                ReconstructWayBack(targetNode);

                path.Reverse();
                Console.WriteLine(string.Join("=>", path));
            }
            else
            {
                Console.WriteLine("ГРЕДА! Няма път, да не говорим за най-кратък.");
            }
        }

        private static void ReconstructWayBack(int nodeToPrint)
        {
            if (wayBack[nodeToPrint] == -2)
            {
                path.Add(nodeToPrint + 1);
                return;
            }

            path.Add(nodeToPrint + 1);
            ReconstructWayBack(wayBack[nodeToPrint]);
        }

        private static void BFS(int startNode, int targetNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            wayBack[startNode] = -2; // start Vertex

            while (queue.Count > 0 && wayBack[targetNode] == -1)
            {
                var currentNode = queue.Dequeue();

                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[currentNode, i] && wayBack[i] == -1 && wayBack[i] != -2) // -1 not visited vertex
                    {
                        wayBack[i] = currentNode;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
