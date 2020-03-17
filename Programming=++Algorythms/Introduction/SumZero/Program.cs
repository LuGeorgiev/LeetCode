using System;

namespace SumZero
{
    class Program
    {
        private static int[] line = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 };
        private const int TARGET_SUM = 0;

        static void Main(string[] args)
        {
            Variate(0);
        }

        private static void CheckSum()
        {
            int tempSum = 0;
            for (int i = 0; i < line.Length; i++)
            {
                tempSum += line[i];
            }

            if (tempSum == TARGET_SUM)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] >= 0)
                    {
                        Console.Write($"+{line[i]} ");
                    }
                    else
                    {
                        Console.Write($"{line[i]} ");
                    }
                }
                Console.WriteLine($" = {TARGET_SUM}");
            }
        }

        private static void Variate(int index)
        {
            if (index >= line.Length)
            {
                CheckSum();
                return;
            }

            line[index] = Math.Abs(line[index]);
            Variate(index + 1);

            line[index] = - Math.Abs(line[index]);
            Variate(index + 1);
        }
    }
}
