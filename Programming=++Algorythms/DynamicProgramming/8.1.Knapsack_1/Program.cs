namespace _8._1.Knapsack_1
{
    internal class Program
    {
        private const int MAX_CAPACITY = 1000;
        private const int MAX_N = 30;

        private const int NOT_CALCULATED = -1;
        private const int ITEMS_COUNT = 8;//N
        private const int BACKPACK_CAP = 70;//M

        private static bool[,] taken = new bool[MAX_CAPACITY, MAX_N]; // set
        private static int[] maxReached = new int[MAX_CAPACITY];// Fn Целева функция

        private static int[] itemsWeight = new int[ITEMS_COUNT + 1] { 0, 30, 15, 50, 10, 20, 40, 5, 65 };//m
        private static int[] itemsCost = new int[ITEMS_COUNT + 1] { 0, 5, 3, 9, 1, 2, 7, 1, 12 };//c

        static void Main(string[] args)
        {
            Console.WriteLine($"Items count: {ITEMS_COUNT}");
            Console.WriteLine($"Backpack capacity: {BACKPACK_CAP}");
            Calculate();
        }

        private static void Calculate()
        {
            for (int i = 0; i < maxReached.Length; i++)
                maxReached[i] = NOT_CALCULATED; /* Иниц. на целевата функция */

            var sumCapacity = itemsWeight[1];
            for (int i = 2; i < itemsWeight.Length; i++)
                sumCapacity += itemsWeight[i];

            if (sumCapacity <= BACKPACK_CAP) 
            {
                Console.WriteLine("All items can be taken.");
                return;
            }
            else
            {
                CalculateBest(BACKPACK_CAP);
                Console.WriteLine($"We should take items with numbers:");
                for (int i = 1;i <=ITEMS_COUNT;i++)
                    if (taken[BACKPACK_CAP,i])
                        Console.Write("{0,-3}",i);
                Console.WriteLine($"\nMaximal taken valueis: {maxReached[BACKPACK_CAP]}");
            }
        }

        private static void CalculateBest(int capacity)
        {
            var bestIndex = 0;
            var maxReachedBest = 0;
            var maxReachedCurrent = 0;
            /* Пресмятане на най-голямата стойност на  CalculateBest*/
            for (int i = 1; i <= ITEMS_COUNT; i++)
            {
                if (capacity >= itemsWeight[i])
                {
                    if (maxReached[capacity - itemsWeight[i]] == NOT_CALCULATED)
                        CalculateBest(capacity - itemsWeight[i]);

                    if (!taken[capacity - itemsWeight[i], i])
                        maxReachedCurrent = itemsCost[i] + maxReached[capacity - itemsWeight[i]];
                    else
                        maxReachedCurrent = 0;

                    if(maxReachedCurrent > maxReachedBest) 
                    {
                        bestIndex = i;
                        maxReachedBest = maxReachedCurrent;
                    }
                }
            }

            /* Регистриране на най-голямата стойност на функцията */
            maxReached[capacity] = maxReachedBest;
            if (bestIndex > 0)
            {
                for (int i = 0; i < ITEMS_COUNT; i++)                
                    taken[capacity, i] = taken[capacity - itemsWeight[bestIndex], i];
                
                taken[capacity,bestIndex] = true; 
            }
        }
    }
}