using System;

namespace LinkedListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var three = linkedList.Find(3);
            linkedList.InsertBefore(three, -3);
            linkedList.InsertBefore(three, -33);
            linkedList.Add(4);
            linkedList.Add(5);
            var five = linkedList.Find(5);
            linkedList.InsertAfter(five, -5);
            linkedList.InsertAfter(five, -55);
            linkedList.Add(6);
            linkedList.Add(7);

            linkedList.DeleteNode(1);
            linkedList.DeleteNode(7);

            Console.WriteLine(linkedList.Count);
            linkedList.Print();
        }
    }
}
