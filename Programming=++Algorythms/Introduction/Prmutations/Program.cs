using System;

namespace Prmutations
{
    class Program
    {
        private const int elements = 4;
        private static bool[] used = new bool[elements];
        private static int[] vector = new int[elements];

        static void Main(string[] args)
        {   
            Permute(0);
        }

        private static void Print()
        {
            for (int i = 0; i < elements; i++)
            {
                Console.Write($"{vector[i]} ");
            }

            Console.WriteLine();
        }

        private static void Permute(int index)
        {
            if (index >= elements)
            {
                Print();
                return;
            }

            for (int k = 0; k < elements; k++)
            {
                if (! used[k])
                {
                    used[k] = true;
                    vector[index] = k;
                    Permute(index + 1);
                    used[k] = false;
                }
            }
        }
    }
}
