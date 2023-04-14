using System.ComponentModel;

namespace _7._2.Majorant_12
{
    internal class StackMajority
    {
        static void Main(string[] args)
        {
            char[] array = { 'A', 'A', 'A', 'C'};

            Console.WriteLine(CheckMajority(array));
        }

        private static (bool hasMajorant, T value) CheckMajority<T>(T[] input)
           where T : struct
        {
            var stack = new Stack<T>();
            stack.Push(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (stack.Count == 0)
                    stack.Push(input[i]);
                else if (stack.Peek().Equals(input[i]))
                    stack.Push(input[i]);
                else
                    stack.Pop();
            }

            if (stack.Count == 0)
                return (false, default);

            var candidate = stack.Pop();
            var count = 0;
            for (int i = 0; i < input.Length; i++)            
                if (candidate.Equals(input[i]))
                    count++;            

            if (count > input.Length / 2)
                return (true, candidate);

            return (false, default);
        }
    }
}