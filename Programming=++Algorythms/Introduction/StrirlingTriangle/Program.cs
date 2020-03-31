using System;
using System.Collections.Generic;

namespace StrirlingTriangle
{
    class Program
    {
        private const int ROWS = 10;
        private const int COLLS = 10;

        private static List<List<ulong>> stirlingTriangle= new List<List<ulong>>()
            {
                new List<ulong>{1},
                new List<ulong>{0,1}

            };

        static void Main(string[] args)
        {
            BuildStirlingTriangle();
        }

        private static void BuildStirlingTriangle()
        {
            for (int row = 2; row <= ROWS; row++)
            {
                stirlingTriangle.Add(new List<ulong>() {0});
                for (int col = 1; col <= row; col++)
                {
                    if (row ==col)
                    {
                        stirlingTriangle[row].Add(1);
                    }
                    else
                    {
                        stirlingTriangle[row].Add(stirlingTriangle[row - 1][col] * (ulong)col + stirlingTriangle[row - 1][col - 1]);
                    }
                }
            }
        }
    }
}
