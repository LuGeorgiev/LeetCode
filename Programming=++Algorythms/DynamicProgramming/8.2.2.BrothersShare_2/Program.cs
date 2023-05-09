namespace _8._2._2.BrothersShare_2
{
    internal class Program
    {
        private const int MaxItemsCount = 100;
        private const int MaxItemValue = 200;
        private const int NotSet = -1;

        private static int[] last = new int[MaxItemsCount * MaxItemValue];
        private static int[] values = { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

        static void Main(string[] args)
        {
            Solve();
        }

        private static void Solve()
        {
            ulong maxPrice = 0;
            ulong curSum = 0;
            var itemsCount = values.Length;

            //calculate Maxprice
            for (int i = 0; i < itemsCount; maxPrice += (ulong)values[i++]) ;

            //initialize
            for (int i = 1; i <= (int)maxPrice; i++)
                last[i] = NotSet;

            last[0] = 0;
            // find variety of all the possibl values combinations with provided items
            for (int i = 0; i < itemsCount; i++)
            {
                for (ulong j = maxPrice; j + 1 > 0; j--)
                {
                    if (last[j] != NotSet && NotSet == last[j + (ulong)values[i]])
                    {
                        last[j + (ulong)values[i]] = i;
                    }
                }
                curSum += (ulong)values[i];
            }

            //find clossest to maxPrice/2  value and log needed items
            for (ulong i = maxPrice / 2; i > 1; i--)
                if (last[i] != NotSet)
                {
                    Console.WriteLine($"The sum for Alan is: {i} Bob will receive: {maxPrice - i}");
                    Console.Write("Alan should take: ");
                    while (i > 0) 
                    {
                        Console.Write($"{values[last[i]]} ");
                        i -= (ulong)values[last[i]];
                    }                        
                    Console.WriteLine("\nBob should take the rest." );
                    break;
                }
        }
    }
}