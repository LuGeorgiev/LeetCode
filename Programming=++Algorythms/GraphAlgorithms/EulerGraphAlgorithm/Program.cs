using System;

namespace EulerGraphAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Euler.IsEulerGraph())
            {
                Euler.FindEulerCycle(3);
            }
            else
            {
                Console.WriteLine("Graph is not Euler");
            }
        }
    }
}
