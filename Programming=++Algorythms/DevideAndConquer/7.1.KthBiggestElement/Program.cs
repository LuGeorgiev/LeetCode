using System.Linq;

namespace _7._1.KthBiggestElement
{
    internal class Program
    {
        private const int ARRAY_ELMENTS = 4; //n
        private const int SEARCHED_ELEMENT = 3; //k
        private static int[] arr = new int[ARRAY_ELMENTS]; //m

        static void Main(string[] args)
        {
            var min = -100;
            var max = 100;
            var rnd = new Random();
            arr = Enumerable.Repeat(0, ARRAY_ELMENTS)
                .Select(x => rnd.Next(min, max))
                .ToArray();

            Console.WriteLine($"Array before searching:\n{string.Join(", ", arr)}");
            Console.WriteLine($"Looking for {SEARCHED_ELEMENT}th element.");

            HeapFindKth(SEARCHED_ELEMENT);

            Console.WriteLine($"{SEARCHED_ELEMENT}th element is: {arr[SEARCHED_ELEMENT-1]}");
            Console.WriteLine($"Array after search is; {string.Join(", " , arr)}");

        }

        /* Отсява елем. от върха на пирамидата */
        private static void ShiftMin(int left, int right)
        {
            var i = left;
            var j = i + i +1;
            var x = arr[i];

            while (j <= right)
            {
                if (j < right)
                    if (arr[j] > arr[j + 1])
                        j++;

                if (x <= arr[j])
                    break;

                arr[i] = arr[j];
                i = j;
                j = j * 2 + 1;
            }

            arr[i] = x; 
        }

        /* Отсява елем. от върха на пирамидата */
        private static void ShiftMax(int left, int right)
        {
            var i = left;
            var j = i + i + 1;
            var x = arr[i];

            while (j <= right)
            {
                if (j < right)
                    if (arr[j] < arr[j + 1])
                        j++;

                if (x >= arr[j])
                    break;

                arr[i] = arr[j];
                i = j;
                j = j * 2 + 1;
            }

            arr[i] = x;
        }

        private static void HeapFindKth(int kthElement)
        {
            int left;
            int right;
            var useMax = kthElement > ARRAY_ELMENTS / 2;
            if (useMax)
                kthElement = ARRAY_ELMENTS - kthElement - 1;
            left = ARRAY_ELMENTS / 2;
            right = ARRAY_ELMENTS - 1;

            /* Построяване на пирамидата */
            while (left -- > 0)
                if(useMax)
                    ShiftMax(left, right);
                else
                    ShiftMin(left, right);

            /*(k - 1) - кратно премахване на минималния елемент */
            for (int i = ARRAY_ELMENTS - 1; i >= ARRAY_ELMENTS - kthElement; i--)
            {
                arr[0] = arr[i];
                if (useMax)
                    ShiftMax(0, i);
                else
                    ShiftMin(0, i);
            }
        }
    }
}