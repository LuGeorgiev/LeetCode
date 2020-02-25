using System;

namespace DisplayAllDigitsRecursiveParams
{
    class Program
    {
        public static uint numberToDisplay = 79875309;

        static void Main(string[] args)
        {
            PrintNumber( numberToDisplay);
        }

        private static void PrintNumber(uint number)
        {
            if (number >=10)
            {
                PrintNumber(number / 10);
            }

            Console.WriteLine(number % 10);
        }
    }
}
