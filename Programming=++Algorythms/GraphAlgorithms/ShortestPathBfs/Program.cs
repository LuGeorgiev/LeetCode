using System;

namespace ShortestPathBfs
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 3;
            int target = 13;

            FindShortest.FindShortesPath(start - 1, target - 1);
        }
    }
}
