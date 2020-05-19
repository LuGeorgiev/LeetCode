using System;
using System.Linq;
using System.Text;
namespace EightQueens
{
    public class QueensBoard
    {
        private const int BOARD_DIMENTIONS = 4;

        //Four arrays to represent the board
        private static int[] queens = Enumerable.Repeat(-1, BOARD_DIMENTIONS).ToArray();
        private static bool[] hasQeenColumn = new bool[BOARD_DIMENTIONS];
        private static bool[] hasQeenLeftDiagonal = new bool[2 * BOARD_DIMENTIONS];
        private static bool[] hasQeenRightDiagonal = new bool[2 * BOARD_DIMENTIONS - 1];

        private static bool wasSolutionFound = false;
        private static bool shoudFindAll = false;

        public static void FindQueensDistribution(bool findAll)
        {
            shoudFindAll = findAll;

            PlaceQueen(0);
            if (!wasSolutionFound)
            {
                Console.WriteLine("Solution was not found");
            }
        }

        private static void PlaceQueen(int currentQueen)
        {
            if (currentQueen == BOARD_DIMENTIONS)
            {
                PrintBoard();
            }

            for (int col = 0; col < BOARD_DIMENTIONS; col++)
            {
                if (!hasQeenColumn[col]
                    && !hasQeenRightDiagonal[currentQueen + col]
                    && !hasQeenLeftDiagonal[BOARD_DIMENTIONS + currentQueen - col])
                {
                    hasQeenColumn[col] = true;
                    hasQeenRightDiagonal[currentQueen + col] = true;
                    hasQeenLeftDiagonal[BOARD_DIMENTIONS + currentQueen - col] = true;
                    queens[currentQueen] = col;

                    PlaceQueen(currentQueen + 1);

                    hasQeenColumn[col] = false;
                    hasQeenRightDiagonal[currentQueen + col] = false;
                    hasQeenLeftDiagonal[BOARD_DIMENTIONS + currentQueen - col] = false;
                }
            }
        }

        private static void PrintBoard()
        {
            wasSolutionFound = true;

            for (int i = 0; i < BOARD_DIMENTIONS; i++)
            {
                for (int j = 0; j < BOARD_DIMENTIONS; j++)
                {
                    if (queens[i] == j)
                    {
                        Console.Write($"{"X",3}");
                    }
                    else
                    {
                        Console.Write($"{"_",3}");
                    }
                }
                Console.WriteLine();
            }
            if (!shoudFindAll)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Next solution if exists");
            }
        }
    }
}
