namespace _7._9.Tournament_3
{
    internal class Program
    {
        private const int MAX_SIZE = 100;
        private const int TEAMS = 5;

        static void Main(string[] args)
        {
            var matrix = new int[MAX_SIZE, MAX_SIZE];
            FindSolution(matrix, TEAMS);
            Print(matrix, TEAMS);
        }

        private static void Print(int[,] matrix, int teamsCount)
        {
            for (int row = 0; row < teamsCount; row++)
            {
                for (int col = 0; col < teamsCount; col++)
                    Console.Write("{0,-4}", matrix[row, col]);

                Console.WriteLine();
            }
        }

        private static void FindSolution(int[,] matrix, int teamsCount)
        {
            if (teamsCount % 2 == 0)
                teamsCount--;

            /* Попълване на таблицата за n - тук е гарантирано нечетно. */
            for (int row = 0; row < teamsCount; row++)            
                for (int col = 0; col < teamsCount; col++)
                    matrix[row, col] = row + col < teamsCount 
                        ? row + col +1 
                        : row + col +1 - teamsCount;

            if(teamsCount % 2 == 1)
                teamsCount++;

            for (int i = 0; i < teamsCount; i++)
            {
                if (teamsCount % 2 == 0)/* Запълване на последния стълб и ред при четно n */
                    matrix[i, teamsCount - 1] = matrix[teamsCount - 1, i] = matrix[i, i];

                matrix[i, i] = 0;
            }

        }
    }
}