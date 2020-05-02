using System;

namespace CheckForCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (CheckCycles.HasCicles())
            {
                Console.WriteLine("Has cycles");
            }
            else
            {
                Console.WriteLine("This i sa tree");
            }
        }
    }
}
