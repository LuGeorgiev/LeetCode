using System;
using System.Collections.Generic;

namespace PrimeTwinNumbers._1._158
{
    class Program
    {
        private const int TWIN_COUPLES_TO_FIND = 400 ;

        private static List<ulong> primeNumbers = new List<ulong>() { 2, 3, 5 };
        private static List<string> twinCouples = new List<string>() { "{3,5}" };

        private static double branConstant = 1 / 3D + 1 / 5D;

        static void Main(string[] args)
        {
            FindFirstPrimeTwinNumbers(TWIN_COUPLES_TO_FIND);
        }

        private static void FindFirstPrimeTwinNumbers(int numberOfCouplesToFind)
        {
            if (numberOfCouplesToFind <= twinCouples.Count)
            {
                PrintCouples();
            }

            ulong numberToCheck = 6;

            while (twinCouples.Count <= numberOfCouplesToFind)
            {
                bool isPrime = IsPrime(numberToCheck);
                if (isPrime && HasTwin(numberToCheck))
                {
                    twinCouples.Add($"{{{numberToCheck-2},{numberToCheck}}}");
                    UpdateBranConstant(numberToCheck);
                }

                numberToCheck++;
            }

            PrintCouples();
            Console.WriteLine(branConstant);
        }

        private static void UpdateBranConstant(ulong numberToCheck)
        {
            branConstant += 1 / (double)(numberToCheck - 2);
            branConstant += 1 / (double)(numberToCheck);
        }

        private static bool HasTwin(ulong numberToCheck)
            => primeNumbers.Contains(numberToCheck - 2);
        

        private static bool IsPrime(ulong numberToCheck)
        {
            foreach (var currentPrime in primeNumbers)
            {
                if (numberToCheck % currentPrime == 0)
                {
                    return false;
                }
            }

            for (ulong i = primeNumbers[primeNumbers.Count -1]; i < Math.Ceiling(Math.Sqrt(numberToCheck)); i++)
            {
                if (numberToCheck % i == 0)
                {
                    return false;
                }
            }

            primeNumbers.Add(numberToCheck);

            return true;
        }

        private static void PrintCouples()
        {
            Console.WriteLine(string.Join(", ",twinCouples));
        }
    }
}
