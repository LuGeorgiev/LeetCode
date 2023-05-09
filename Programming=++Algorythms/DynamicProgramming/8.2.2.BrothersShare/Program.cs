namespace _8._2._2.BrothersShare
{
    internal class Program
    {
        private const int MaxItemsCount = 100;
        private const int MaxItemValue = 200;

        private static bool[] can = new bool[MaxItemsCount * MaxItemValue];
        private static int[] values = { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

        static void Main(string[] args)
        {
            Solve();
        }

        private static void Solve()
        {
            ulong maxPrice = 0;
            var itemsCount = values.Length;

            //calculate Maxprice
            for (int i = 0; i < itemsCount; maxPrice +=  (ulong)values[i++]);

            can[0] = true;
            // find variety of all the possibl values combinations with provided items
            for (int i = 0; i < itemsCount; i++)
                for (ulong j = maxPrice; j + 1 > 0; j--)
                    if (can[j])
                        can[j + (ulong)values[i]] = true;

            //find clossest to maxPrice/2  value
            for (ulong i = maxPrice / 2; i > 1; i--)
                if (can[i])
                {
                    Console.WriteLine($"The sum for Alan is: {i} Bob will receive: {maxPrice - i}");
                    break;
                }    
        }
    }
}