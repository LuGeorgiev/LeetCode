using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TortoiseRabitsAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sortMe = new List<int>() {3, 6, 0 ,-1, -289, 4, 8889 };
            //var sortMe = new List<string>() {"3", "6", "0" ,"-1", "-289", "4", "8889", "41" };
            //var result = sortMe.SortByCombo();
            //Console.WriteLine(string.Join("<=", result));



            var rand = new Random();
            var numberOfElements = 1_000_000;
            var listToSort = new List<int>(numberOfElements);
            for (int i = 0; i < numberOfElements; i++)
            {
                listToSort.Add(rand.Next(int.MinValue, int.MaxValue));
            }

            var stopWatch = Stopwatch.StartNew();

            var sorted = listToSort.SortByCombo();

            stopWatch.Stop();
            Console.WriteLine($"List was Sorted for: {stopWatch.ElapsedMilliseconds} msec");

            for (int i = 1; i < sorted.Count; i++)
            {
                if (sorted[i - 1] > sorted[i])
                {
                    Console.WriteLine($"Wrong: {sorted[i - 1]} is not lower {sorted[i]} on index: {i} OR not sorted corectly");
                }
            }
        }
    }
}
