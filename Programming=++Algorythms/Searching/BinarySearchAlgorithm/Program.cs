using System;
using System.Diagnostics;
using System.Linq;

namespace BinarySearchAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 1_000_000_000).ToArray();

            var stopWatch = Stopwatch.StartNew();
            Console.WriteLine( list.SearchIndex<int>(7));
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }
    }
}
