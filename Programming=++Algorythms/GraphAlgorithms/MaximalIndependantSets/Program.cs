using System;

namespace MaximalIndependantSets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All maximal independant sets in teh graph are:");
            MaxIndependant.FindMaxSubset(0);
        }
    }
}
