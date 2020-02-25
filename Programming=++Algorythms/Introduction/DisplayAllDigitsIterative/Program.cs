using System;

namespace DisplayAllDigitsIterative
{
    class Program
    {
        public static uint numberToDisplay = 67890; 

        static void Main(string[] args)
        {
            var digits = new ushort[20];
            var index = 0;

            while (numberToDisplay > 10)
            {
                digits[index] = (ushort)(numberToDisplay % 10);
                index++;
                numberToDisplay /= 10; 
            }
            digits[index] = (ushort)numberToDisplay;

            for (int i = index; i >= 0; i--)
            {
                Console.WriteLine($"{digits[i]}");
            }
        }
    }
}
