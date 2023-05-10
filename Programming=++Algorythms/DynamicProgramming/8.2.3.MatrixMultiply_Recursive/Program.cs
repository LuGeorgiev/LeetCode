namespace _8._2._3.MatrixMultiply_Recursive
{
    internal class Program
    {
        private const int MatrixCount = 9;
        private static int[] matrixDimentions = { 12, 13, 35, 3, 34, 2, 21, 10, 21, 6 };
        private static long[,] matrix = new long[MatrixCount + 1, MatrixCount + 1];

        static void Main(string[] args)
        {
            Console.WriteLine($"Multiplication number is {SolveRecursive(1, MatrixCount)}");
            PrintMatrix();
        }

        private static long SolveRecursive(int i, int j)
        {
            if (i == j) 
                return 0;

            matrix[i, j] = long.MaxValue;
            for (int k = i; k <= j - 1; k++)
            {
                var q = SolveRecursive(i, k) 
                    + SolveRecursive(k + 1, j) 
                    + matrixDimentions[i - 1] * matrixDimentions[k] * matrixDimentions[j];

                if (q < matrix[i,j])
                    matrix[i,j] = q;
            }

            return matrix[i,j];
        }

        private static void PrintMatrix()
        {
            Console.WriteLine("Matrix of the minimus:");
            for (int i = 1; i <= MatrixCount; i++)
            {
                for (int j = 1; j <= MatrixCount; j++)
                {
                    Console.Write("{0,8}", matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}