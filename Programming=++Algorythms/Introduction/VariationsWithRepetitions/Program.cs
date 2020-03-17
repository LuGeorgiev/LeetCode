using System;

namespace VariationsWithRepetitions
{
    class Program
    {
        private const ushort elemnets = 3;
        private const ushort order = 2;

        private static int[] vector;

        static void Main(string[] args)
        {
            vector = new int[order];
            Variate(0);
        }

        private static void Print(int index)
        {
            Console.Write("( ");
            for (int i = 0; i <= index -1; i++)
            {
                Console.Write($"{vector[i] + 1} ");
            }
            Console.WriteLine(")");
        }

        private static void Variate(int index)
        {
            if (index >= order)
            {
                Print(index);
                return;
            }

            for (int value = 0; value < elemnets; value++)
            {
                vector[index] = value;
                Variate(index + 1);
            }
        }
    }
}
