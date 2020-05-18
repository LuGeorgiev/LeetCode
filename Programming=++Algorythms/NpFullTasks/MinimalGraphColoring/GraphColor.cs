using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimalGraphColoring
{
    public class GraphColor
    {
        //игура 6.3.2. Минимално r-оцветяване на граф. p.368
        private const int VERTICES_COUNT = 5;
        private static int[,] graph = new int[VERTICES_COUNT, VERTICES_COUNT]
        {
            { 0, 1, 0, 0, 1 },
            { 1, 0, 1, 1, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 1, 0, 1 },
            { 1, 1, 0, 1, 0 }
        };

        private static int[] colorVector = Enumerable.Repeat(0, VERTICES_COUNT).ToArray();
        private static int maxColor = 0;
        private static int solutionsCount = 0;

        public static void FindMinimalColoring()
        {
            for (maxColor = 1; maxColor <= VERTICES_COUNT; maxColor++)
            {
                for (int vertex = 0; vertex < VERTICES_COUNT; vertex++)
                {
                    colorVector[vertex] = 0;
                }

                NextColor(0);

                if (solutionsCount > 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Total numbers color paterns with {maxColor} colors is: {solutionsCount}");
        }

        private static void ShowSolution()
        {
            solutionsCount++;
            Console.WriteLine("Minimal graph coloring:");
            for (int i = 0; i < VERTICES_COUNT; i++)
            {
                Console.WriteLine($"Vertex {i + 1}, with color {colorVector[i]}");
            }
        }

        private static void NextColor(int currentVertex)
        {
            if (currentVertex == VERTICES_COUNT)
            {
                ShowSolution();
                return;
            }

            bool isSuccessfull = false;

            for (int color = 1; color <= maxColor; color++)
            {
                colorVector[currentVertex] = color;
                isSuccessfull = true;

                for (int col = 0; col < VERTICES_COUNT; col++)
                {
                    if (graph[currentVertex, col] == 1 && colorVector[currentVertex] == colorVector[col])
                    {
                        isSuccessfull = false;
                        break;

                    }
                }
                if (isSuccessfull)
                {
                    NextColor(currentVertex + 1);
                }
                colorVector[currentVertex] = 0;
            }
        }
    }
}
