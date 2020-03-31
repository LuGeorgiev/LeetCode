using System;
using System.Collections.Generic;

namespace StirlingNumberRecursive
{
    class Program
    {
        private static Dictionary<string, ulong> calculatedStirlingNumbers = new Dictionary<string, ulong>()
        {
            {"1,1", 1 },
            {"2,1", 1 },
            {"2,2", 1 }
        };

        static void Main(string[] args)
        {
            Console.WriteLine(CalculateStirling(8, 3) ); 
        }

        private static ulong CalculateStirling(int n, int k)
        {
            if (n==k)
            {
                return 1;
            }
            else if (n ==0 || k ==0)
            {
                return 0;
            }

            var key = $"{n},{k}";
            if (calculatedStirlingNumbers.ContainsKey(key))
            {
                return calculatedStirlingNumbers[key];
            }

            calculatedStirlingNumbers.Add(key, CalculateStirling(n - 1, k - 1) + (ulong)k * CalculateStirling(n - 1, k));

            return calculatedStirlingNumbers[key];
        }
    }
}
