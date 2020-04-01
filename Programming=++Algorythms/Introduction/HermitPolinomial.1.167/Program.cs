using System;
using System.Collections.Generic;
using System.Numerics;

namespace HermitPolinomial._1._167
{
    class Program
    {
        private const int ORDER = 10;
        private const int X_VALUE = 2;
        private static Dictionary<int, BigInteger> hermitValues = new Dictionary<int, BigInteger>()
        {
            {0, 1},
            {1, 2 * X_VALUE }
        };

        static void Main(string[] args)
        {
            var hermitValu = CalculateHermitValue(ORDER);
            Console.WriteLine($"The value of Hermits polinomial for value: {X_VALUE} of order: {ORDER} is: {hermitValu}");
        }

        private static BigInteger CalculateHermitValue(int order)
        {
            if (order < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (hermitValues.ContainsKey(order))
            {
                return hermitValues[order];
            }

            hermitValues[order] = 2 * X_VALUE * CalculateHermitValue(order - 1) - 2 * (order - 1) * CalculateHermitValue(order - 2);

            return hermitValues[order];
        }
    }
}
