using System.Linq;

namespace _7._10.ShiftLeft_3_CSharp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = 12;
            var shiftBy = 8;
            var arr = InitArray(elements);
            Console.WriteLine(string.Join(" ", arr));
            var result = ShiftLeft(arr, shiftBy);
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> ShiftLeft(List<int> input, int shiftBy)
        {
            var first = input.GetRange(0, shiftBy);
            var second = input.GetRange(shiftBy , input.Count - shiftBy );

            first.Reverse();
            second.Reverse();

            var result = first.Concat(second).ToList();
            result.Reverse();

            return result;
        }

        private static List<int> InitArray(int elements)
        {
            var result = new List<int>(elements);

            for (int i = 0; i < elements; i++)
                result.Add(i);

            return result;
        }
    }
}