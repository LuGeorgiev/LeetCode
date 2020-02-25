using System;

namespace RecursivePrintLineWithParameters
{
    class Program
    {
        private static uint zeroes = 6;

        static void Main(string[] args)
        {
            PrintLine(1, 10);
        }

        private static void PrintLine(uint current, ulong result)
        {
            Console.WriteLine(result);

            if (current < zeroes)
            {
                PrintLine(current + 1, result * 10);
            }

            Console.WriteLine(result);
        }
    }
}
