using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KruskalAlgorithm
{
    public class MinimalSpanningTree
    {
        private const int NO_PARENT = -1;
        private const int VERTEX_COUNT = 11;
        private static SortedSet<Edge> edges = new SortedSet<Edge>()
        {
           new Edge( 1, 4, 2),
           new Edge( 2, 5, 13),
           new Edge( 2, 3, 3),
           new Edge( 3, 6, 3),
           new Edge( 5, 6, 12),
           new Edge( 3, 4, 4),
           new Edge( 4, 6, 16),
           new Edge( 1, 2, 1),
           new Edge( 4, 7, 14),
           new Edge( 6, 7, 1),
           new Edge( 5, 8, 1),
           new Edge( 5, 9, 13),
           new Edge( 6, 9, 1),
           new Edge(10, 11, 18)
        };

        private static int[] previous = Enumerable.Repeat(NO_PARENT, VERTEX_COUNT+1).ToArray();

        private static int GetRoot(int currentVertex)
        {
            int root  = currentVertex;
            int savedCurrent;

            //find the root of the tree
            while (previous[root] != NO_PARENT)
            {
                root = previous[root];
            }

            //Set the root value to all the nodes from this set
            while (currentVertex != root)
            {
                savedCurrent = currentVertex;
                currentVertex = previous[currentVertex];
                previous[savedCurrent] = root;
            }

            return root;
        }

        public static void Kruskal()
        {
            int mstCost = 0;

            Console.WriteLine("Edges involved in Minimal Spanning Tree are:");
            foreach (var edge in edges)
            {
                int rootOne = GetRoot(edge.VertA);
                int rootTwo = GetRoot(edge.VertB);

                if (rootOne != rootTwo)
                {
                    Console.Write(edge);

                    mstCost += edge.Weight;
                    previous[rootTwo] = rootOne;
                }
            }
            Console.WriteLine($"\n The cost of this Minimal spanning tree is: {mstCost}");
        }
    }
}
