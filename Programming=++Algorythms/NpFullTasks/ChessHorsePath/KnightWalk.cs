using System;

namespace ChessKnightPath
{
    public class KnightWalk
    {
        private const int BOARD_DIMETION = 5;
        private const int START_X = 3;
        private const int START_Y = 3;

        private static int[,] board = new int[BOARD_DIMETION, BOARD_DIMETION];

        private static int[] xStep = new int[] { 1, 1, -1, -1, 2, -2, 2, -2 };
        private static int[] yStep = new int[] { 2, -2, 2, -2, 1, 1, -1, -1 };
        private const int possibilityCount = 8;

        private static int nextMoveX = 0;
        private static int nextMoveY = 0;
        private static bool wasSolved = false;
        private static bool shouldPrintAll = false;

        public static void FindSinglePath(bool printAll)
        {
            shouldPrintAll = printAll;

            NextMove(START_X - 1, START_Y - 1, 1);

            if (!wasSolved)
            {
                Console.WriteLine("The problem cannot be solved!");
            }
        }

        private static void NextMove(int x, int y, int count)
        {
            board[x, y] = count;
            if (count == BOARD_DIMETION * BOARD_DIMETION)
            {
                PrintBoard();
                wasSolved = true;

                // backtrack before returning. needed when ALL paths are needed
                board[x, y] = 0;
                return;
            }

            for (int step = 0; step < possibilityCount; step++)
            {
                nextMoveX = x + xStep[step];
                nextMoveY = y + yStep[step];

                if (nextMoveX >= 0 && nextMoveX < BOARD_DIMETION
                    && nextMoveY >= 0 && nextMoveY < BOARD_DIMETION
                    && board[nextMoveX, nextMoveY] == 0)
                {
                    NextMove(nextMoveX, nextMoveY, count + 1);
                }   
            }

            // backtrack from current square and remove it from current path
            board[x, y] = 0;
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0, -3} ", board[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            if (!shouldPrintAll)
            {
                //Exit i fonly one path is needed
                Environment.Exit(0);
            }
        }
    }
}
