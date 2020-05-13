using System;
using System.Linq;

namespace DominatingSets
{
    public class MinimalDominatingSets
    {
        //Фигура 5.7.3. Доминиращи множества в граф. p.334

        private const int VERTECIES_COUNT = 6;
        private static int[,] graph = new int[VERTECIES_COUNT, VERTECIES_COUNT]
        {
            { 0, 1, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0 }
        };

        private static int[] cover = Enumerable.Repeat(0, VERTECIES_COUNT).ToArray();
        private static bool[] visited = Enumerable.Repeat(false, VERTECIES_COUNT).ToArray();

        private static void PrintSet()
        {
            Console.Write("{ ");
            for (int i = 0; i < VERTECIES_COUNT; i++)
            {
                if (visited[i])
                {
                    Console.Write($"{i + 1} ");
                }
            }
            Console.WriteLine("}");
        }

        private static bool IsOk()
        {
            for (int row = 0; row < VERTECIES_COUNT; row++)
            {
                if (visited[row])
                {
                    // Check if coverage will be saved when node i is not included in graph
                    if (cover[row] == 0)
                    {
                        continue;
                    }

                    int col = 0;
                    for (; col < VERTECIES_COUNT; col++)
                    {
                        if (cover[col] - graph[row, col] == 0 && !visited[col])
                        {
                            break; // there is NOT coverd node
                        }
                    }

                    if (col == VERTECIES_COUNT)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void FindMinimalDom(int lastNode)
        {
            //Check if decision was found
            int row = 0;
            for (; row < VERTECIES_COUNT; row++)
            {
                if (cover[row] == 0 && ! visited[row])
                {
                    break;
                }
            }
            if (row == VERTECIES_COUNT)
            {
                PrintSet();
                return;
            }

            //keep building dominant set
            for ( row = lastNode ; row < VERTECIES_COUNT; row++)
            {
                visited[row] = true;
                for (int col = 0; col < VERTECIES_COUNT; col++)
                {
                    if (graph[row, col] == 1)
                    {
                        cover[col]++;
                    }
                }

                if (IsOk())
                {
                    FindMinimalDom(row + 1);
                }

                for (int col = 0; col < VERTECIES_COUNT; col++)
                {
                    if (graph[row, col] == 1)
                    {
                        cover[col]--;
                    }
                }
                visited[row] = false;
            }
        }
    }
}
