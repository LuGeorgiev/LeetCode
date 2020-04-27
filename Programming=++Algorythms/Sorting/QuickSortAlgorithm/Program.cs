using System;
using System.Collections.Generic;

using static QuickSortAlgorithm.QuickSort;

namespace QuickSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 89, 3, 4, 57, 2, 31, -62, 23, 2, 34, 45, 89, 986, -67, -23 };
            //var result = Sort<int>(list);
            var result = SortSwap<int>(list);
            Console.WriteLine(string.Join(" <= ", result));
        }
    }
}
