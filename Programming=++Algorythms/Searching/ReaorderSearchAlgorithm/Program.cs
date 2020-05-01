using System;

namespace ReaorderSearchAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ReorderSearch<string>();
            list.Insert(1, "11");
            list.Insert(3, "33");
            list.Insert(4, "44");
            list.Insert(5, "55");
            list.Insert(-45, "-4455");
            list.Insert(-5, "-5555");
            list.Insert(6, "66");
            list.Insert(8, "88");
            list.Insert(11, "1111");
            list.Print();
            Console.WriteLine(list.Search(8));
            list.Print();
            list.Search(8);
            list.Search(11);
            Console.WriteLine(list.Search(-45));
            list.Print();
        }
    }
}
