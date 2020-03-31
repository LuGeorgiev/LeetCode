using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {          

            var parameters = new object[] {"Ivan", 89.569, 2 };

            var indexed = parameters.Select((x, i) => new Element() { Index = i + 1, Value = x }).ToArray();

        }
    }

    class Element
    {
        public int Index { get; set; }

        public object Value { get; set; }
    }
}
