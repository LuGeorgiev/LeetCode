using System;
using System.Linq;

namespace NumbeSumFromGivenNumbers
{
    class Program
    {
        private const uint number = 18;

        private static uint[] givenNumbers = new uint[] { 3, 7, 2}.OrderBy(x =>x).ToArray();
        private static uint givenLength = (uint)givenNumbers.Length;
        private static uint[] vector = new uint[number + 1];

        static void Main(string[] args)
        {
            vector[0] = number + 1;
            DevideByGiven(number, 1);
        }

        private static void Print(uint length)
        {
            Console.Write(number + " = ");
            for (int index = 1; index < length; index++)
            {
                Console.Write(vector[index] + " + ");
            }
            Console.WriteLine(vector[length]);
        }

        private static void DevideByGiven(uint num, uint position)
        {
            for (uint givenIndex = givenLength; givenIndex > 0; givenIndex--)
            {
                var current = givenNumbers[givenIndex - 1];

                if (num > current)
                {
                    vector[position] = current;
                    if (vector[position] <= vector[position - 1])
                    {
                        DevideByGiven(num - current, position + 1);
                    }
                }
                else if (num == current)
                {
                    vector[position] = current;
                    if (vector[position] <= vector[position - 1])
                    {
                        Print(position);
                    }
                }
            }
        }
    }
}
