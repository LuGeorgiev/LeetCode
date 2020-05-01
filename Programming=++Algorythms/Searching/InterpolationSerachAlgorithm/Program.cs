using System;
using System.Diagnostics;
using System.Linq;

namespace InterpolationSerachAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 1_000_000_000).ToArray();

            var stopWatch = Stopwatch.StartNew();
            Console.WriteLine(list.Search(9));
            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }
    }
}
