namespace BackpackOptimalSelection
{

    // Дадена е раница, която може да
    // побере M килограма.Дадени са N предмета, всеки с тегло mi и стойност (цена) ci. Да се намери
    // подмножество от предмети с максимална обща цена, които да се побират в раницата, т.е.сборът
    // от теглата им да бъде по-малък или равен на M.
    internal class Program
    {
        private const ushort ITEMS_COUNT = 10; // n
        private const double MAX_WEIGHT = 10.5; //M
        private static double[] cost = new double[ITEMS_COUNT] { 10.3, 9.0, 12.0, 8.0, 4.0, 8.4, 9.1, 17.0, 6.0, 9.7 };//c
        private static double[] weight = new double[ITEMS_COUNT] { 4.0, 2.6, 3.0, 5.3, 6.4, 2.0, 4.0, 5.1, 3.0, 4.0 };//m
        private static ushort[] takenItems = new ushort[ITEMS_COUNT]; //taken
        private static ushort[] savedTaken = new ushort[ITEMS_COUNT]; //savedTaken
        private static ushort takenIndex = 0; //tn
        private static ushort savedTakenIndex = 0; //sn
        private static double maxPrice = 0;//VmaX максимална цена от решенията, проверени до момента
        private static double tempPrice = 0;// Vtemp обща цена на взетите предмети
        private static double tempWeight = 0; //Ttemp общо тегло на взетите предмети
        private static double totalPrice = 0; //totalV обща цена на оставащите предмети

        static void Main(string[] args)
        {
            for (int i = 0; i < ITEMS_COUNT; i++)
                totalPrice += cost[i];

            Generate(0);

            Console.WriteLine($"Max price is: {maxPrice:0.##} and choosen items are:");
            for (int i = 0; i < savedTakenIndex; i++)
            {
                Console.WriteLine($"{savedTaken[i] + 1} with weight: {weight[i]} and cost: {cost[i]}");
            }
            Console.WriteLine();
        }

        private static void Generate(int index)
        {
            if (tempWeight > MAX_WEIGHT)
                return;

            if (tempPrice + totalPrice < maxPrice)
                return;

            if (index == ITEMS_COUNT)
            {
                if (tempPrice > maxPrice) // запазване на оптималното решение
                {
                    maxPrice = tempPrice;
                    savedTakenIndex = takenIndex;
                    for (int i = 0; i < takenIndex; i++)
                    {
                        savedTaken[i] = takenItems[i];
                    }
                }
                return;
            }

            takenItems[takenIndex++] = (ushort)index;
            tempPrice += cost[index];
            totalPrice -= cost[index];
            tempWeight += weight[index];
            Generate(index + 1);

            takenIndex--;
            tempPrice -= cost[index];
            tempWeight -= weight[index];
            Generate(index + 1);
            totalPrice += cost[index];
        }
    }
}