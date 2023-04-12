namespace _7._2.Majorant_3
{
    internal class HeapSortMajority
    {   
        static void Main(string[] args)
        {
            //var array = new int[] { 1, 2, 3, 3, 3};
            var rnd = new Random();
            var array = Enumerable.Repeat(1, 100).Select(x => rnd.Next(1,4)).ToArray();

            var result = TryFindMajority(array);
            if (result.hasMajority)            
                Console.WriteLine( $"Majority value is: {result.value}");
            else
                Console.WriteLine("Do not have Majority");

            Console.WriteLine(string.Join(" ", array));
        }

        private static (bool hasMajority, int value) TryFindMajority(int[] input)
        {
            var halfLength = input.Length / 2;

            HeapSort(ref input);

            if (CountElement(ref input, input[halfLength]) > halfLength)
                return (true, input[halfLength]);

            return (false, 0);
        }

        private static int CountElement(ref int[] input, int elementValue)
        {
            var counter = 0;
            for (int i = 0; i < input.Length; i++)
                if (input[i] == elementValue)
                    counter++;

            return counter;
        }

        private static void HeapSort(ref int[] input)
        {
            var heapSize = input.Length;
            for (int i = (heapSize - 1) / 2; i >= 0; i--)
                MaxHeapify(ref input, heapSize, i);

            for (int i = heapSize - 1; i >= 0; i--)
            {
                //swap
                (input[i], input[0]) = (input[0], input[i]);
                heapSize--;
                MaxHeapify(ref input, heapSize, 0);
            }
        }

        private static void MaxHeapify(ref int[] input, int heapSize, int index)
        {
            var left = (index + 1) * 2 - 1;
            var right = (index + 1) * 2;
            var largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;
            
            if(right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                (input[index], input[largest]) = (input[largest], input[index]);

                MaxHeapify(ref input, heapSize,largest);
            }            
        }
    }
}