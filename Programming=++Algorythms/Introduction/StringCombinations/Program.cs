using System;
using System.Linq;

namespace StringCombinations
{
    class Program
    {
        private static string[] elements;
        private static string[] combination;

        static void Main(string[] args)
        {
            Console.WriteLine("Plaese insert space separated string that for generating combinations");
            elements = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToArray();

            InputCombinationsClass();

            Console.WriteLine($"\nFollowing are all combinations with repetitions");
            CombinationsWithRep(0, 0);

            Console.WriteLine($"\nFollowing are all combinations without repetitions");
            Comb(1, 0);
        }

        private static void CombinationsWithRep(int index, int after)
        {
            if (index >= combination.Length)
            {
                Print();
            }
            else
            {
                for (int current = after; current < elements.Length; current++)
                {
                    combination[index] = elements[current];
                    CombinationsWithRep(index + 1, current);
                }
            }

        }

        private static void Comb(int index, int after)
        {
            if (index > combination.Length)
            {
                return;
            }

            for (int current = after + 1; current <= elements.Length; current++)
            {
                combination[index - 1] = elements[current-1];
                if (index == combination.Length)
                {
                    Print();
                }
                Comb(index + 1, current);
            }
        }

        private static void InputCombinationsClass()
        {
            while (true)
            {
                Console.WriteLine("Please enter valid number of combinatios class");
                if (int.TryParse(Console.ReadLine(), out int combinationLength) && combinationLength <= elements.Length)
                {
                    combination = new string[combinationLength];
                    return;
                }
            }
        }

        private static void Print()
            => Console.WriteLine(String.Join(", ", combination));
    }
}
