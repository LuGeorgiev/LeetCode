using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleSortingAlgorithms
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //var myArr = new int[] { 2, -1, 98, 4, -5 ,234, -1212, 97,  4 , 6, 2, 0, 98, 21 };
            var myArr = new string[] { "asaa", "SDD","AS","as","asdrqe","asf","frr","de32"};


            //Console.WriteLine(string.Join(" <= ", myArr.InsertSrt()));

            //Console.WriteLine(string.Join(" <= ", myArr.StraightInsertion()));

            //Console.WriteLine(string.Join(" <= ", myArr.ShellSort( myArr.Length - 1)));

            //Console.WriteLine(string.Join(" <= ", myArr.BubbleSort()));

            //Console.WriteLine(string.Join(" <= ", myArr.BubbleSortFlagged()));

            //Console.WriteLine(string.Join(" <= ", myArr.ShakeSort()));

            var rand = new Random();
            var elementsCount = 10_000;
            var listToSort = new List<int>(elementsCount);
            for (int i = 0; i < elementsCount; i++)
            {
                listToSort.Add(rand.Next(int.MinValue, int.MaxValue));
            }

            var stopWatch = Stopwatch.StartNew();

            var sorted = listToSort.ToArray().InsertSrt();
            //var sorted = listToSort.ToArray().ShellSort(listToSort.Count -1);
            
            stopWatch.Stop();
            Console.WriteLine($"List was Sorted for: {stopWatch.ElapsedMilliseconds} msec");            

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i - 1] > sorted[i])
                {
                    Console.WriteLine($"Wrong: {sorted[i - 1]} is not lower {sorted[i]} on index: {i} OR not sorted corectly");
                }
            }

        }
    }
}
