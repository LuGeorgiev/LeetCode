namespace _8._2.Knapsack_5
{
    internal class Program
    {
        const int MaxN = 30;    /* Максимален брой предмети */
        const int MaxCapacity = 1000;  /* Максимална вместимост на раницата */
        const int TotalCapacity = 70;   /* Обща вместимост на раницата */
        const int N = 8;    /* Брой предмети */

        static int[] f = new int[MaxCapacity];     /* Целева функция */
        static int[] best = new int[MaxCapacity];  /* Последен добавен предмет при достигане на максимума */

        static readonly int[] weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегло на предметите */
        static readonly int[] values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 };       /* Стойност на предметите */

        static void Main(string[] args)
        {
            Calculate();
            Console.WriteLine($"Max reached value is: {f[TotalCapacity]}");
            Console.WriteLine("Took following items:");
            PrintBestSet();
        }

        private static void PrintBestSet()
        {
            var value = TotalCapacity;
            while (value != 0) 
            {
                Console.Write("{0,-3}", best[value]);
                value -= weights[best[value]];
            }
            Console.WriteLine();
        }

        private static void Calculate()
        {
            for (int i = 1; i <= TotalCapacity; i++)
            {
                for (int j = 1; j <= N ; j++)
                {
                    if (i >= weights[j]
                        && f[i] < f[i - weights[j]] + values[j]
                        && !IsUsed(i - weights[j], j))
                    {
                        f[i] = f[i - weights[j]] + values[j];
                        best[i] = j;
                    }
                }
            }
        }

        private static bool IsUsed(int i, int j)
        {
            while (i != 0 && best[i] != 0)
            {
                if (best[i] == j)
                    return true;
                else
                    i -= weights[best[i]];
            }

            return false;
        }
    }
}