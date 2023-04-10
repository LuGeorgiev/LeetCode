using System;
using System.Linq;

namespace ArticulationPoints
{
    public class Articulation
    {
        //Фигура 5.6.3. Разделящи точки в граф. p.321

        private const int VERTICES_COUNT = 7;

        private static int[,] graph = new int[VERTICES_COUNT, VERTICES_COUNT]
        {
            { 0, 1, 0, 0, 0, 0, 0 },
            { 1, 0, 1, 0, 0, 1, 0 },
            { 0, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1, 1, 0 },
            { 0, 0, 0, 1, 0, 0, 0 },
            { 0, 1, 1, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 1, 0 }
        };

        private static int[] prenum = Enumerable.Repeat(0, VERTICES_COUNT).ToArray();
        private static int[] lowest = Enumerable.Repeat(0, VERTICES_COUNT).ToArray();
        private static int count = 0;

        public static void FindPoints()
        {
            DFS(0);

            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (prenum[i] == 0)
                {
                    Console.WriteLine("The Graph is not connected");
                    return;
                }
            }

            PostOrder(0);

            var articulationPoints = new int[VERTICES_COUNT];
            var articulationCount = 0;
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (graph[0, i] == 2)
                {
                    articulationCount++;
                }
            }

            if (articulationCount > 1)
            {
                articulationPoints[0] = 1;
            }

            for (int i = 1; i < VERTICES_COUNT; i++)
            {
                int j ;
                for (j = 0; j < VERTICES_COUNT; j++)
                {
                    if (graph[i, j] == 2 && lowest[j] >= prenum[i])
                    {
                        break;
                    }
                }

                if (j < VERTICES_COUNT)
                {
                    articulationPoints[i] = 1;
                }
            }

            Console.WriteLine("Articulations points in graph are:");
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (articulationPoints[i] == 1)
                {
                    Console.Write($"{i + 1} ");
                }
            }
            Console.WriteLine();
        }

        //build spanning tree
        private static void DFS(int curentVertex)
        {
            prenum[curentVertex] = ++count;
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (graph[curentVertex, i] == 1 && prenum[i] == 0)
                {
                    graph[curentVertex, i] = 2;
                    DFS(i);
                }
            }
        }

        //Left Right Root traversal
        private static void PostOrder(int currentVertex )
        {
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (graph[currentVertex, i] == 2)
                {
                    PostOrder(i);
                }

            }

            lowest[currentVertex] = prenum[currentVertex];

            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (graph[currentVertex, i] == 1)
                {
                    lowest[currentVertex] = Math.Min(lowest[currentVertex], prenum[i]);
                }
            }
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                if (graph[currentVertex, i] == 2)
                {
                    lowest[currentVertex] = Math.Min(lowest[currentVertex], lowest[i]);
                }
            }
        }
    }
}
