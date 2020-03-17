using System;
using System.Collections.Generic;

namespace PermutationsWithDuplication
{
    class Program
    {
        private static int[] vector;
        

        static void Main(string[] args)
        {
            vector = new int[] { 1, 2, 1, 3};

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(String.Join(", ", vector));
            }
            else
            {
                var swapped = new HashSet<int>();

                for (int i = index; i < vector.Length; i++)
                {
                    if (! swapped.Contains(vector[i]))
                    {        
                        (vector[i], vector[index]) = (vector[index], vector[i]);

                        Permute(index + 1);

                        (vector[i], vector[index]) = (vector[index], vector[i]);

                        swapped.Add(vector[i]);
                    }                   
                }
            }
        }
    }
}
