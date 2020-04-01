using System;

namespace QueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();
            queue.EnQueue("a");
            queue.EnQueue("b");
            queue.EnQueue("c");
            Console.WriteLine(queue.DeQueue());
            queue.EnQueue("d");
            Console.WriteLine(queue.DeQueue());
            queue.EnQueue("e");
            queue.EnQueue("f");
            queue.EnQueue("r");
            queue.EnQueue("t");
            queue.EnQueue("y");
            queue.EnQueue("u");
            queue.EnQueue("i");
            Console.WriteLine(queue.DeQueue());
            Console.WriteLine(queue.DeQueue());
            Console.WriteLine(queue.DeQueue());
            Console.WriteLine(queue.DeQueue());

            while (!queue.IsEmpty)
            {
                Console.WriteLine(queue.DeQueue());
            }
        }
    }
}
