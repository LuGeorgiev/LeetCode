namespace _8._2._6.LongestSubSequencePrint
{
    internal class Program
    {
        private const string FirstLine = "acbcacbcaba";
        private const string SecondLine = "abacacacababa";
        private const char Up = 'U';
        private const char Left = 'L';
        private const char Diagonal = 'D';



        private static readonly int firstLength = FirstLine.Length;
        private static readonly int secondLength = SecondLine.Length;
        private static readonly int[,] matrix = new int[firstLength + 1, secondLength + 1];
        private static readonly char[,] previous = new char[firstLength + 1, secondLength + 1];

        static void Main(string[] args)
        {
            Console.WriteLine($"The length of longest common sub sequens is: {LongestCommonSubsetLength()}");
            Console.Write("Reversed sub sequence is: ");
            PrintRevised();
            Console.Write("\nSubsequence with helper matrix is: "  );
            PrintSequenceWithHelper(firstLength, secondLength);
            Console.Write("\nSubsequence without helper matrix is: ");
            PrintSequence(firstLength, secondLength);
        }

        private static int LongestCommonSubsetLength()
        {
            for (int i = 1; i <= firstLength; i++)
                for (int j = 1; j <= secondLength; j++)
                    if (FirstLine[i - 1] == SecondLine[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                        previous[i, j] = Diagonal;
                    }
                    else if (matrix[i - 1, j] >= matrix[i, j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j];
                        previous[i, j] = Up;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i, j - 1];
                        previous[i, j] = Left;
                    }

            return matrix[firstLength, secondLength];
        }

        private static void PrintRevised()
        {
            var i = firstLength;
            var j = secondLength;

            while (i > 0 && j > 0)
            {
                switch (previous[i,j])
                {
                    case Diagonal:
                        Console.Write(FirstLine[i -1]);
                        i--;
                        j--;
                        break;
                    case Up:
                        i--;
                        break; 
                    case Left:
                        j--;
                        break;
                    default: 
                        throw new Exception("bang");
                }
            }
        }

        private static void PrintSequenceWithHelper(int i, int j)
        {
            if (i == 0 || j == 0)
                return;

            if (previous[i, j] == Diagonal)
            {
                PrintSequenceWithHelper(i - 1, j - 1);
                Console.Write(FirstLine[i - 1]);
            }
            else if (previous[i, j] == Up)
                PrintSequenceWithHelper(i - 1, j);
            else
                PrintSequenceWithHelper(i, j - 1);
        }

        private static void PrintSequence(int i, int j)
        {
            if (i == 0 || j == 0)
                return;

            if (FirstLine[i -1] == SecondLine[j -1])
            {
                PrintSequence(i - 1, j - 1);
                Console.Write(FirstLine[i - 1]);
            }
            else if (matrix[i, j] == matrix[i - 1, j])
                PrintSequence(i - 1, j);
            else
                PrintSequence(i, j - 1);
        }
    }
}