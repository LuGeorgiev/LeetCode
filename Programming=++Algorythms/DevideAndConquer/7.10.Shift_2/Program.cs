namespace _7._10.Shift_2
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
            /* Измества масива arr[] на shiftBy позиции наляво.
            * рекурсивен процес, реализиран итеративно } */

            int p = shiftBy;
            int i = shiftBy;
            int j = arr.Length - shiftBy;

            while(i != j) 
            {
                if(i > j)
                {
                    Swap(ref arr, p - i, p, j);
                    i -= j;
                }
                else
                {
                    Swap(ref arr, p - i, p + j - i, i);
                    j -= i;
                }
            }

            Swap(ref arr, p - i, p, i);
        }

        private static void Swap(ref int[] arr, int a, int b, int l)
        {
            /* Разменя местата на подмасивите arr[a..a+l-1] и arr[b..b+l-1] */
            for (int i = 0; i < l; i++)
                (arr[a + i], arr[b + i]) = (arr[b + i], arr[a + i]);
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