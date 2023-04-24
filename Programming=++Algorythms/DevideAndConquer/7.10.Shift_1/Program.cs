namespace _7._10.Shift_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = 10;
            var shiftBy = 3;
            int[] arr = InitArray(elements);
            Console.WriteLine(string.Join(" ", arr));
            ShiftLeft(ref arr, shiftBy);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ShiftLeft(ref int[] arr, int shiftBy)
        {
            var gcdNK = GreatestCommonDevisor(shiftBy, arr.Length);

            for (int i = 0; i < gcdNK; i++)
            {
                var current = i;
                var temp = arr[current];
                var next = current + shiftBy;

                if (next >= arr.Length)
                    next -=arr.Length;

                while (next != i)
                {
                    arr[current] = arr[next];
                    current = next;
                    next += shiftBy;
                    if(next >=arr.Length)
                        next -=arr.Length;
                }
                arr[current] = temp;                
            }
        }

        private static int GreatestCommonDevisor(int x, int y)
        {
            while (y > 0) 
            {
                int tmp = y;
                y = x % y;
                x = tmp;
            }

            return x;
        }

        private static int[] InitArray(int elements)
        {
            var result = new int[elements];
            for (int i = 0;i < elements; i++)
                result[i] = i;

            return result;
        }
    }
}