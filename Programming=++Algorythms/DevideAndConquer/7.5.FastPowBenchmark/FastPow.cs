using BenchmarkDotNet.Attributes;

namespace _7._5.FastPowBenchmark
{
    [MemoryDiagnoser]
    public class FastPow
    {
        const double numb = Math.PI;
        const int power = 11;

        [Benchmark]
        public double PowFast()
        {
            return FastPowCalc(numb, power);
        }

        [Benchmark]
        public double PowIterative()
        {
            return PowIterrative(numb, power);
        }

        private double FastPowCalc(double number, int power)
        {
            if (power == 0)
                return 1;

            if (power % 2 == 1)
                return number * FastPowCalc(number, power - 1);
            else
                return FastPowCalc(number * number, power / 2);
        }

        private double PowIterrative(double number, int power)
        {
            double result = number;
            for (int i = 0; i < power - 1; i++)
                result *= number;

            return result;
        }
    }
}
