using System;
using System.Collections.Generic;
using System.Diagnostics;
using static QuickSortAlgorithm.QuickSort;

namespace QuickSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int>() { 89, 3, 4, 57, 2, 31, -62, 23, 2, 34, 45, 89, 986, -67, -23 };
            //var result = Sort<int>(list);
            //var result = QuickerSort<int>(list);
            //Console.WriteLine(string.Join(" <= ", result));

            var rand = new Random();
            var listToSort = new List<int>(1_000_000);
            for (int i = 0; i < 100_000; i++)
            {
                listToSort.Add(rand.Next(int.MinValue, int.MaxValue));
            }

            var stopWatch = Stopwatch.StartNew();
            var sorted = Sort<int>(listToSort);
            stopWatch.Stop();
            Console.WriteLine($"List was Sorted for: {stopWatch.ElapsedMilliseconds} msec");

            stopWatch.Reset();
            stopWatch.Start();
            var sortedWithSwap = QuickerSort<int>(listToSort);
            stopWatch.Stop();
            Console.WriteLine($"List was Sorted wit swapping for: {stopWatch.ElapsedMilliseconds} msec");

            for (int i = 1; i < sorted.Count; i++)
            {
                if (  sorted[i - 1] > sorted[ i ] && sortedWithSwap[ i ] != sorted[ i ])
                {
                    Console.WriteLine($"Wrong: {sortedWithSwap[i]} != {sorted[i]} on index: {i} OR not sorted corectly");
                }
            }
        }
    }
}
