namespace _7._3.MergeSortedArraysIterrative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var firstLength = 20;
            var secondLength = 10;
            var firstArr = Enumerable.Repeat(0, firstLength)
                .Select(x => rnd.Next(-10, 6))
                .OrderBy(x => x)
                .ToArray();
            var secondArr = Enumerable.Repeat(0, secondLength)
                .Select(x => rnd.Next(-8, 9))
                .OrderBy(x => x)
                .ToArray();

            var result = MergeSortedArrays(firstArr, secondArr);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] MergeSortedArrays(int[] first, int[] second)
        {
            var result = new int[first.Length + second.Length];
            var firstIndex = 0;
            var secondIndex = 0;
            var resultIndex = 0;

            while (firstIndex < first.Length && secondIndex < second.Length)
                result[resultIndex++] = (first[firstIndex] < second[secondIndex])
                    ? first[firstIndex++]
                    : second[secondIndex++];

            if (firstIndex == first.Length)
                while (secondIndex < second.Length)
                    result[resultIndex++] = second[secondIndex++];
            else
                while (firstIndex < first.Length)
                    result[resultIndex++] = first[firstIndex++];

            return result;
        }
    }
}