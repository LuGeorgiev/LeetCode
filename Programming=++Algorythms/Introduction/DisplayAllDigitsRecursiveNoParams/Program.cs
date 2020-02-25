using System;

namespace DisplayAllDigitsRecursiveNoParams
{
    class Program
    {
        private static long numberToDispaly = 7876749;
        private static string result = "";

        static void Main(string[] args)
        {
            PrintNumb();
            Console.WriteLine(result);
        }

        private static void PrintNumb()
        {
            if (numberToDispaly < 10)
            {
                result += (numberToDispaly % 10).ToString();
                return ;
            }

            result += numberToDispaly % 10;
            numberToDispaly /= 10;

            PrintNumb();
            return;
        }
    }
}
