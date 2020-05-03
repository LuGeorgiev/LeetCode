using System;
using System.Collections.Generic;
using System.Text;

namespace FloydAlgorithm
{
    public class FloydSystemRelayability
    {      

        private static float[,] graph = new float[6, 6]
       {
           { 0,     0.5f,   0,      0.2f,   0,      0},     // 0
           { 0.5f,  0,      0.8f,   0.9f,   0,      0},     // 1
           { 0,     0.8f,   0,      0.9f,   0,      0.9f},  // 2
           { 0.2f,   0,      0.9f,   0,     0.6f,   0},     // 3
           {0,      0,      0,      0.6f,   0,      0},     // 4
           {0.01f,  0,      0.9f,   0,      0,      0}      // 5
       };

        public static void CalculatePathRelayability()
        {
            //SetMaxValues();

            CalculateAllPossiblePaths();

            UnMarkSelfReferentials();
        }

        public static void PrintVertexRelayability()
        {
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0:F4}, ", graph[row, col]));
                }
                Console.WriteLine();
            }
        }

        private static void UnMarkSelfReferentials()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                graph[i, i] = 0;
            }
        }

        private static void CalculateAllPossiblePaths()
        {
            for (int currentVertex = 0; currentVertex < graph.GetLength(0); currentVertex++)
            {
                for (int row = 0; row < graph.GetLength(0); row++)
                {
                    for (int col = 0; col < graph.GetLength(1); col++)
                    {
                        if (graph[row, col] < graph[row, currentVertex] * graph[currentVertex, col])
                        {
                            graph[row, col] = graph[row, currentVertex] * graph[currentVertex, col];
                        }
                    }
                }
            }
        }
        
    }
}
