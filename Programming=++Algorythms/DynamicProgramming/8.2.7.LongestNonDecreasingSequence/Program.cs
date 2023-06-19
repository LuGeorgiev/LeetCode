namespace _8._2._7.LongestNonDecreasingSequence
{
    internal class Program
    {
        private static int[] line = { int.MaxValue, 10, 15, 5, 25, 22, 12, 22 };
        private const int LineLength = 7;
        private static int[,] matrix = new int[LineLength + 1, LineLength + 1];
        static void Main(string[] args)
        {
            var len = FindLongestNonDecreasingLength();
            Console.WriteLine($"Length is {len}");
            Console.WriteLine("Reversed sequence is:");
            PrintReveresed(len);
            Console.WriteLine($"\nNon reversed is:");
            PrintLND(LineLength, len);
            Console.WriteLine();
        }
        private static int FindLongestNonDecreasingLength()
        {
            //initialization
            for (int i = 0; i <= LineLength; i++)
            {
                for (int j = 1; j <= LineLength; j++)
                {
                    matrix[i, j] = int.MaxValue;
                }
                matrix[i, 0] = -1;
            }
            //main cycle
            var lengthLND = 1;
            for (int i = 1; i <= LineLength; i++)
            {
                for (int j = 1; j <= LineLength; j++)
                {
                    if (matrix[i - 1, j - 1] <= line[i]
                        && line[i] <= matrix[i - 1, j]
                        && matrix[i - 1, j - 1] <= matrix[i - 1, j])
                    {
                        matrix[i, j] = line[i];
                        if (lengthLND < j)
                        {
                            lengthLND = j;
                        }
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
            return lengthLND;
        }
        private static void PrintReveresed(int j)
        {
            var i = LineLength;
            do
            {
                if (matrix[i, j] == matrix[i - 1, j])
                {
                    i--;
                }
                else
                {
                    Console.Write($"{line[i]} ");
                    j--;
                }
            } while (i > 0);
        }
        private static void PrintLND(int i, int j)
        {
            if (i == 0)
                return;
            if (matrix[i, j] == matrix[i - 1, j])
            {
                PrintLND(i - 1, j);
            }
            else
            {
                PrintLND(i, j - 1);
                Console.Write($"{line[i]} ");
            }
        }
    }
}