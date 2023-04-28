namespace _8._2.Knapsack_3b
{
    internal class Program
    {
        private const int ITEMS_COUNT = 9;//N
        private const int BACKPACK_CAP = 14;//M

        private static int[,] sack = new int[ITEMS_COUNT + 1, BACKPACK_CAP + 1];// Fn Целева функция

        private static int[] weights = new int[ITEMS_COUNT + 1] { 0, 6, 3, 10, 2, 4, 8, 1, 13, 3 };//m
        private static int[] costs = new int[ITEMS_COUNT + 1] { 0, 5, 3, 9, 1, 2, 7, 1, 12, 3 };//c

        private static int[] set = new int[ITEMS_COUNT + 1];//Множество от предмети, постигащи max

        static void Main(string[] args)
        {
            KnapsackCalculate();
            PrintKnapsack();
            PrintAll(ITEMS_COUNT, BACKPACK_CAP, 0);
        }

        private static void PrintAll(int i , int j, int k)
        {
            /* Извежда ВСИЧКИ възможни множества от предмети, за които */
            /* се постига максимална стойност на целевата функция */

            if (j == 0) 
            {
                Console.WriteLine("\nWe take the following items:");
                for (i = 0; i < k; i++)
                {
                    Console.Write("{0,-3}", set[i]);
                }
            }
            else
            {
                if (sack[i,j] == sack[i - 1,j])
                    PrintAll(i - 1, j, k);

                if (j >= weights[i] && sack[i, j] == sack[i - 1, j - weights[i] + costs[i]])
                {
                    set[k] = i;
                    PrintAll(i - 1, j - weights[i], k + 1);
                }
            }
        }

        private static void PrintKnapsack()
        {
            for (int i = 0; i <= ITEMS_COUNT; i++)
            {
                for (int j = -1; j <= BACKPACK_CAP; j++)
                {
                    if (i == 0 && j == -1)
                        Console.Write("{0,-3}", "NM");
                    else if (i == 0)
                        Console.Write("{0,-3}", j);
                    else if (j == -1)
                        Console.Write("{0,-3}", i);
                    else
                        Console.Write("{0,-3}", sack[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void KnapsackCalculate()
        {
            for (int item = 1; item <= ITEMS_COUNT; item++)
            {
                for (int cap = 0; cap <= BACKPACK_CAP; cap++)
                {
                    if (cap >= weights[item]
                        && sack[item - 1, cap] < sack[item - 1, cap - weights[item]] + costs[item])
                    {
                        sack[item, cap] = sack[item - 1, cap - weights[item]] + costs[item];
                    }
                    else
                    {
                        sack[item, cap] = sack[item - 1, cap];
                    }
                }
            }
        }
    }
}