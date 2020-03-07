using System;

namespace PermutationsWithSwapping
{
    class Program
    {
        private const int elements = 3;
        private static int[] vector = new int[elements];
        static void Main(string[] args)
        {
            for (int i = 0; i < elements; i++)
            {
                vector[i] = i;
            }

            Permute(elements);
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
            if (index == 0)
            {
                Print();
            }
            else
            {
                Permute(index - 1);

                for (int k = 0; k < index -1; k++)
                {
                    //int swap = vector[k];
                    //vector[k] = vector[index - 1];
                    //vector[index - 1] = swap;

                    //tpuple value swap valid with C# 7 or 8
                    ( vector[k], vector[index - 1] ) = ( vector[index - 1], vector[k] );

                    Permute(index - 1);

                    ( vector[k], vector[index - 1] ) = ( vector[index - 1], vector[k] );


                    //swap = vector[k];
                    //vector[k] = vector[index - 1];
                    //vector[index - 1] = swap;
                }
            }           
        }
    }
}
