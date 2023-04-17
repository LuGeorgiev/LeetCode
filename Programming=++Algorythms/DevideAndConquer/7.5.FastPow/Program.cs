namespace _7._5.FastPow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numb = Math.PI;
            int power = 11;

            double result = FastPow(numb, power);

            Console.WriteLine( result);
        }

        // 1) x1
        // 2) x2 = x1.x1
        // 3) x3 = x2.x1
        // 4) x6 = x3.x3
        // 5) x7 = x6.x1
        // 6) x14 = x7.x7
        // 7) x15 = x14.x1

        private static double FastPow(double number, int power)
        {
            if (power == 0)
                return 1;

            if (power % 2 == 1)
                return number * FastPow(number, power - 1);
            else
                return FastPow(number * number, power / 2);
        }
    }
}