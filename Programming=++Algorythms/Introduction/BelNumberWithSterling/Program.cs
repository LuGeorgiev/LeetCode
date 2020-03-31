using System;

namespace BelNumberWithSterling
{
    class Program
    {
        private const ulong BELL_NUMBER = 7;

        private static ulong[] strelingNumbers = new ulong[BELL_NUMBER + 1];

        static void Main(string[] args)
        {
            CalculateSterlingNumbers(BELL_NUMBER);
            Console.WriteLine(BellNumber(BELL_NUMBER));
        }

        private static void CalculateSterlingNumbers(ulong sterligNumber)
        {
            if (sterligNumber == 0)
            {
                strelingNumbers[0] = 1;
                return;
            }
            else
            {
                strelingNumbers[0] = 0;
            }

            for (ulong i = 1; i <= sterligNumber; i++)
            {
                strelingNumbers[i] = 1;
                for (ulong j = i - 1; j >= 1; j--)
                {
                    strelingNumbers[j] =  j * strelingNumbers[j] + strelingNumbers[j - 1];
                }
            }
        }

        private static ulong BellNumber(ulong bellNumber)
        {
            ulong sum = 0;
            for (int i = 0; i <= (int)bellNumber; i++)
            {
                sum += strelingNumbers[i];
            }

            return sum;
        }
    }
}
