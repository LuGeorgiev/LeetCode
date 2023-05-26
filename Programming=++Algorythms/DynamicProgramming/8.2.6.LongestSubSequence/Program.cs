namespace _8._2._6.LongestSubSequence
{
    internal class Program
    {
        private const string FirstLine =  "acbcacbcaba";
        private const string SecondLine = "abacacacababa";

        private static readonly int firstLength = FirstLine.Length; 
        private static readonly int secondLength = SecondLine.Length; 
        private static readonly int[,] matrix = new int[firstLength + 1, secondLength + 1];

        static void Main(string[] args)
        {
            Console.WriteLine($"The length of longest common sub sequens is: {LongestCommonSubsetLength()}");
        }

        private static int LongestCommonSubsetLength()
        {
            for (int i = 1; i <= firstLength; i++)
                for (int j = 1; j <= secondLength; j++)
                    if (FirstLine[i - 1] == SecondLine[j - 1])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);

            return matrix[firstLength, secondLength];
        }        
    }
}