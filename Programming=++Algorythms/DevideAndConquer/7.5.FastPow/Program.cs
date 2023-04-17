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