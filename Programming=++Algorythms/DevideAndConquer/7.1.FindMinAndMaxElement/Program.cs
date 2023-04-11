namespace _7._1.FindMinAndMaxElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3 ,-5, 10, -89, 8, 112};

            //Console.WriteLine($"Max element is: {FindMax(arr)}");

            //var minMax = FindMinMax(arr);
            //Console.WriteLine($"Max element is: {minMax.max} and min is: {minMax.min}");

            Console.WriteLine($"Second biggest is: {SeconBiggest(arr)}");
        }

        private static int FindMax(int[] input)
        {
            var max = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                    max = input[i];
            }
            return max;
        }

        private static (int min, int max) FindMinMax(int[] input)
        {
            var len = input.Length;
            var middle = len / 2;
            var minVal = input[middle];
            var maxVal = input[middle];

            for (int i = 0; i < middle; i++)
            {
                if (input[i] > input[len - i - 1])
                {
                    if (input[i] > maxVal)
                        maxVal = input[i];
                    if (input[len - i - 1] < minVal)
                        minVal = input[len - i - 1];
                }
                else
                {
                    if (input[i] < minVal)
                        minVal = input[i];
                    if (input[len - i - 1] > maxVal)
                        maxVal = input[len - i - 1];
                }
            }

            return (minVal, maxVal);
        }

        private static int SeconBiggest(int[] input)
        {
            int biggest = input[0];
            int seconBiggest = input[1];
            if (biggest < seconBiggest)
                (seconBiggest, biggest) = (biggest, seconBiggest);

            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] > seconBiggest)
                {
                    seconBiggest = input[i];
                    if (seconBiggest > biggest)
                    {
                        (biggest, seconBiggest) = (seconBiggest, biggest);
                    }
                }
            }

            return seconBiggest;
        }
    }
}