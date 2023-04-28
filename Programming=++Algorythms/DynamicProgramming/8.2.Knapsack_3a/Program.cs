namespace _8._2.Knapsack_3a
{
    internal class Program
    {
        private const int ITEMS_COUNT = 6;//N
        private const int BACKPACK_CAP = 15;//M

        private static int[,] sack = new int[ITEMS_COUNT + 1, BACKPACK_CAP + 1];// Fn Целева функция

        private static int[] weights = new int[ITEMS_COUNT + 1] { 0, 1, 2, 3, 5, 6, 7 };//m
        private static int[] costs = new int[ITEMS_COUNT + 1] { 0, 1, 10, 19, 22, 25, 30 };//c

        static void Main(string[] args)
        {
            KnapsackCalculate();
            PrintKnapsack();
            PrintSet();
        }

        private static void PrintSet()
        {
            /* Извежда възможно множество от предмети, */
            /* за което се постига максимална стойност */
            /* на целевата функция */

            var i = ITEMS_COUNT;
            var j = BACKPACK_CAP;
            Console.WriteLine("Items to pick up:");
            while (j != 0)
            {
                if (sack[i, j] == sack[i - 1, j])
                {
                    i--;
                }
                else
                {
                    Console.Write("{0,-3}", i);
                    j -= weights[i];
                    i--;
                }
            }
            Console.WriteLine();
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