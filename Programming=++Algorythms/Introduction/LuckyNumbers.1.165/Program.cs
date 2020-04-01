using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyNumbers._1._165
{
    class Program
    {
        private const int STEPS = 4;
        private const int NUMBERS_TO_INCLUDE = 30;

        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, NUMBERS_TO_INCLUDE).ToList();

            var luckyNumbers =  RemoveUnlucky(numbers, STEPS);

            Console.WriteLine(string.Join(", ", luckyNumbers));
        }

      

        private static List<int> RemoveUnlucky(List<int> numbers, int maxSteps)
        {
            var result = new List<int>();

            for (int currentStep = 1; currentStep <= maxSteps; currentStep++)
            {
                result = RemoveFromCurrentStep(numbers, currentStep);
                numbers = result;
            }

            return result;
        }

        private static List<int> RemoveFromCurrentStep(List<int> inputNumbers, int currentStep)
        {
            var result = new List<int>(inputNumbers.Count - (inputNumbers.Count / currentStep));
            var gap = currentStep + 1;

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if (i == currentStep)
                {
                    currentStep += gap;
                    continue;
                }

                result.Add(inputNumbers[i]);
            }

            return result;
        }
    }
}
