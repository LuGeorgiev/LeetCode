using System;

namespace FindAllSimplePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var startVertex = 13;
            var endVertex = 8;

            AllPaths.FindAllPathsBetween(startVertex - 1, endVertex - 1);
        }
    }
}
