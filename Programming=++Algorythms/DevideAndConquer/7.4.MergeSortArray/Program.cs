namespace _7._4.MergeSortArray
{
    internal class Program
    {
        private static int elementsCount = 101;
        private static int[] arrToSort = new int[elementsCount];
        private static int[] arrHelper = new int[elementsCount];

        static void Main(string[] args)
        {
            var rnd = new Random();
            arrToSort = Enumerable.Repeat(0, elementsCount)
                .Select(x => rnd.Next() % (2 * elementsCount + 1))
                .ToArray();
            Console.WriteLine(string.Join(" ", arrToSort));

            MergeSortArray(0, elementsCount -1);
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", arrToSort));
        }

        private static void MergeSortArray(int left, int right)
        {
            if (right <= left)
                return;

            var mid = (left + right) / 2;
            MergeSortArray(left, mid); // sort left part
            MergeSortArray(mid + 1, right); // sort right part

            // copy input[] into result[]
            int i;
            for ( i = mid + 1; i > left; i--)
                arrHelper[i - 1] = arrToSort[i - 1]; //straight direction

            int j;
            for ( j = mid; j < right; j++)
                arrHelper[right + mid - j] = arrToSort[j + 1]; // oposite direction

            //both arrays merge
            for (int k = left; k <= right; k++)
                arrToSort[k] = arrHelper[i] < arrHelper[j]
                    ? arrHelper[i++]
                    : arrHelper[j--];
        }
    }
}