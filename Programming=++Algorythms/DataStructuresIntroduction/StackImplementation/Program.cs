using System;

namespace StackImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStack = new Stack<int>(2);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(5);
            myStack.Push(5);
            myStack.Push(6);
            myStack.Push(7);
            myStack.Push(7);
            myStack.Push(7);
            myStack.Push(8);
            myStack.Push(9);
            myStack.Push(10);
            myStack.Push(11);
            myStack.Push(12);

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            //while (!myStack.IsEmpty)
            //{
            //    Console.WriteLine(myStack.Pop());
            //}
        }
    }
}
