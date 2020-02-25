using System;

namespace RecursivePrintLineNoParams
{
    class Program
    {
        private static uint zeroes = 6;
        private static uint counter = 0;
        private static long result = 3;

        static void Main(string[] args)
        {
            PrintLine();
        }

        private static void PrintLine()
        {
            counter++;
            result *= 10;
            Console.WriteLine(result);

            if (counter < zeroes)
            {
                PrintLine();
            }

            Console.WriteLine(result);
            result /= 10;
        }
    }
}
