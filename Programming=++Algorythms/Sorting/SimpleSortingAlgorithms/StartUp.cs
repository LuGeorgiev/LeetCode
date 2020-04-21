using System;
using System.Diagnostics;

namespace SimpleSortingAlgorithms
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var myArr = new int[] { 2, -1, 98, 4, -5 ,234, -1212, 97,  4 , 6, 2, 0, 98, 21 };
            //var myArr = new string[] { "asaa", "SDD","AS","as","asdrqe","asf","frr","de32"};


            //Console.WriteLine(string.Join(" <= ", myArr.InsertSrt()));

            //Console.WriteLine(string.Join(" <= ", myArr.StraightInsertion()));

            //Console.WriteLine(string.Join(" <= ", myArr.ShellSort( myArr.Length - 1)));

            //Console.WriteLine(string.Join(" <= ", myArr.BubbleSort()));

            Console.WriteLine(string.Join(" <= ", myArr.BubbleSortEnhanced()));


        }
    }
}
