using System.Runtime.InteropServices;

namespace _7._10.ShiftLeft_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = 12;
            var shiftBy = 8;
            int[] arr = InitArray(elements);
            Console.WriteLine(string.Join(" ", arr));
            ShiftLeft(ref arr, shiftBy);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ShiftLeft(ref int[] arr, int shiftBy)
        {
            // Кърниган и Плоджер

            Reverse(ref arr, 0, shiftBy - 1);
            Reverse(ref arr, shiftBy, arr.Length - 1);
            Reverse(ref arr, 0, arr.Length - 1);
        }

        private static void Reverse(ref int[] arr, int start, int end)
        {
            var count = (end - start) / 2;
            for (int i = 0; i <= count; i++, start++, end--)            
                (arr[start], arr[end]) = (arr[end], arr[start]);
            
        }

        private static int[] InitArray(int elements)
        {
            var result = new int[elements];
            for (int i = 0; i < elements; i++)
                result[i] = i;

            return result;
        }
    }
}