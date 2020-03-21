using System;

namespace CombinationsWithRepetition
{
    class Program
    {
        private const int elements = 4;
        private const int order = 2;
        private static int[] vector;

        static void Main(string[] args)
        {
            vector = new int[order];
            CombinationsWithRep(0, 0);
        }

        private static void CombinationsWithRep(int index, int after)
        {
            if (index >= order)
            {
                Print();
            }
            else
            {
                for (int current = after ; current < elements; current++)
                {
                    vector[index] = current + 1;                   
                    CombinationsWithRep(index + 1, current);
                }
            }

        }

        private static void Print()
            => Console.WriteLine(String.Join(" ", vector));
    }
}
