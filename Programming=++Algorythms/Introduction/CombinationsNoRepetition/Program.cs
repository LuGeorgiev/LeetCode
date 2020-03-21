using System;

namespace CombinationsNoRepetition
{
    class Program
    {
        private const int elements = 5;
        private const int order = 3;
        private static int[] vector;

        static void Main(string[] args)
        {
            vector = new int[order];
            Comb(1, 0);
        }

        private static void Comb(int index, int after)
        {
            if (index > order)
            {
                return;
            }

            for (int current = after + 1; current <= elements; current++)
            {
                vector[index - 1] = current;
                if (index == order)
                {
                    Print();
                }
                Comb(index + 1, current);
            }
        }

        private static void Print()
        => Console.WriteLine(String.Join(" ", vector));
        
    }
}
