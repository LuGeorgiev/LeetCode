using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 11;
            Console.WriteLine(CoinChange(new[] {1,2,5 },amount , new int[amount]));
        }

        //Too slow
        //class Amount
        //{
        //    public int CoinsCount { get; set; } 
        //    public int CurrentSum { get; set; }
        //}
        //public static int CoinChange(int[] coins, int amount)
        //{
        //    if (coins.Contains(amount))
        //    {
        //        return 1;
        //    }
        //    else if (amount == 0)
        //    {
        //        return 0;
        //    }
        //    var orderedCoins = coins.OrderByDescending(x => x).ToArray();
        //    var amounts = new Queue<Amount>();
        //    foreach (var coin in orderedCoins)
        //    {
        //        amounts.Enqueue(new Amount() { CurrentSum = coin, CoinsCount = 1 });
        //    }

        //    while (amounts.Count>0)
        //    {
        //        var current = amounts.Dequeue();

        //        foreach (var coin in orderedCoins)
        //        {
        //            if (current.CurrentSum + coin == amount)
        //            {
        //                return current.CoinsCount + 1;
        //            }
        //            else if (current.CurrentSum+coin<amount)
        //            {
        //                amounts.Enqueue(new Amount()
        //                {
        //                    CurrentSum = current.CurrentSum + coin,
        //                    CoinsCount = current.CoinsCount + 1
        //                });
        //            }
        //        }
        //    }

        //    return -1;

        //}

        private static int CoinChange(int[] coins, int rem, int[] count)
        {
            if (rem < 0) return -1;
            if (rem == 0) return 0;
            if (count[rem - 1] != 0) return count[rem - 1];
            int min = int.MaxValue;
            foreach (var coin in coins)
            {
                int res = CoinChange(coins, rem - coin, count);
                if (res >= 0 && res < min)
                    min = 1 + res;
            }
            count[rem - 1] = (min == int.MaxValue) ? -1 : min;

            return count[rem - 1];
        }

    }
}
