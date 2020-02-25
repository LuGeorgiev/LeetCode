using System;

namespace RecursivePrintLineGlobalCounter
{

    class Program
    {
        private static uint zeroes = 6;
        private static uint counter = 0;

        static void Main(string[] args)
        {
            PrintLine(9);
        }

        private static void PrintLine( ulong result)
        {
            counter++;
            Console.WriteLine(result);

            if (counter < zeroes)
            {
                PrintLine( result * 10);
            }

            Console.WriteLine(result);
        }
    }
}
