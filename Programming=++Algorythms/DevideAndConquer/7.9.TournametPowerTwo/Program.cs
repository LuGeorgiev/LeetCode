namespace _7._9.TournametPowerTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teamsCount = 16;
            var maxMatrixSize = 100;
            var matrix = new int[maxMatrixSize, maxMatrixSize];
            FindSolution(matrix, teamsCount);
            Print(matrix, teamsCount);
        }

        private static void Print(int[,] matrix, int teamsCount)
        {
            for (int row = 1; row <= teamsCount; row++)
            {
                for (int col = 1; col <= teamsCount; col++)
                    Console.Write("{0,-4} ", matrix[row, col]);

                Console.WriteLine();
            }
        }

        private static void FindSolution(int[,] matrix, int teamsCount)
        {
            matrix[1, 1] = 0;
            for (int i = 1; i <= teamsCount; i <<= 1)
            {
                CopyMatrix(matrix, i + 1, 1, i, i);
                CopyMatrix(matrix, i + 1, i + 1, i, 0);
                CopyMatrix(matrix, 1, i + 1, i, i);
            }
        }

        private static void CopyMatrix(int[,] matrix, int stX, int stY, int cnt, int add)
        {
            for(int row = 0; row < cnt; row++)
                for(int col = 0; col < cnt; col++)
                    matrix[row + stX, col + stY] = matrix[row + 1, col + 1] + add;

        }
    }
}