using BenchmarkDotNet.Running;

namespace _7._5.FastPowBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FastPow>();

            //var runner = new FastPow();
            //Console.WriteLine( runner.PowFast());
            //Console.WriteLine( runner.PowIterative());
        }
    }
}