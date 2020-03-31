using System;

namespace FillMatrix._1._17
{
    class Program
    {
        private const uint COLS = 5;
        private const uint ROWS = 6;

        private static int[,] matrix = new int[ROWS, COLS];

        static void Main(string[] args)
        {
            FillMatrix();
            PrintMtrix();
        }

        private static void PrintMtrix()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Console.Write($"{matrix[row,col]}  ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix()
        {
            var minDimention = Math.Min(COLS, ROWS);
            var elemntsTofill = ROWS * COLS - minDimention;

            int lastNumber = FillLowerPart();
            FillUpperPart(lastNumber);            
        }

        private static void FillUpperPart(int counter)
        {
            for (int col = (int)COLS - 1; col >=0; col--)
            {
                for (int row = col - 1; row >= 0; row--)
                {
                    matrix[row, col] = counter++;
                }
            }
        }

        private static int FillLowerPart()
        {
            int counter = 1;
            for (int col = 0; col < COLS; col++)
            {
                for (int row = col + 1; row < ROWS; row++)
                {
                    matrix[row, col] = counter++;
                }
            }

            return counter;
        }
    }
}
