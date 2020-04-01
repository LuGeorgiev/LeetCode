using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 1000).ToList();
            List<bool> isIncluded = Enumerable.Repeat(true, 100).ToList();


        }
    }

    class Element
    {
        public int Index { get; set; }

        public object Value { get; set; }
    }
}
