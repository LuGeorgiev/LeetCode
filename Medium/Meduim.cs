using System;
using System.Collections.Generic;
using System.Linq;

namespace Medium
{
    class Meduim
    {
        static void Main(string[] args)
        {
            //165.Compare Version Numbers
            //Console.WriteLine(CompareVersion("1.0", "1.01"));

            //153.Find Minimum in Rotated Sorted Array
            //Console.WriteLine(FindMin(new[] { 3,2,1 }));

            //187.Repeated DNA Sequences
            //Console.Write(string.Join(", ", FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT")));

            //365. Water and Jug Problem
            //Console.WriteLine(CanMeasureWater(3, 5, 4));

            //322. Coin Change
            int amount = 11;
            Console.WriteLine(CoinChange(new[] { 1, 2, 5 }, amount, new int[amount]));
        }

        //165.Compare Version Numbers
        public static int CompareVersion(string version1, string version2)
        {

            List<int> firstStr = ConvToIntArray(version1);
            List<int> secondStr = ConvToIntArray(version2);
            int longerLen = firstStr.Count >= secondStr.Count
                    ? firstStr.Count
                    : secondStr.Count;

            firstStr = FillWithZeroes(firstStr, longerLen);
            secondStr = FillWithZeroes(secondStr, longerLen);

            for (int i = 0; i < longerLen; i++)
            {
                if (firstStr[i] < secondStr[i])
                {
                    return -1;
                }
                else if (firstStr[i] > secondStr[i])
                {
                    return 1;
                }
            }        

            return 0;
        }
        private static List<int> FillWithZeroes(List<int> nums, int length)
        {
            for (int i = nums.Count-1; i < length; i++)
            {
                nums.Add(0);
            }
            return nums;
        }
        private static List<int> ConvToIntArray(string version1)
        {
            var result = version1
                    .Split('.', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            return result;
        }

        //153.Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            else if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums.Length == 2)
            {
                if (nums[0] < nums[1])
                {
                    return nums[0];
                }
                else
                {
                    return nums[1];
                }
            }
            else if (nums[0] < nums[1] && nums[0]<nums[nums.Length-1])
            {
                return nums[0];
            }
            else if (nums[nums.Length-2]>nums[nums.Length-1])
            {
                return nums[nums.Length - 1];
            }

            int minIndex = BinaryRotetedSearch(nums, 0, nums.Length-1);
            return nums[minIndex];
        }
        private static int BinaryRotetedSearch(int[] nums, int lowIndex, int highIndex)
        {
            int centralIndex = (highIndex + lowIndex) / 2;

            var lowValue = nums[centralIndex - 1];
            var central = nums[centralIndex];
            var hiValue = nums[centralIndex + 1];

            if (nums[centralIndex-1]>nums[centralIndex] && nums[centralIndex] < nums[centralIndex+1])
            {
                return centralIndex;
            }

            if (nums[centralIndex]> nums[lowIndex] )
            {
                centralIndex = BinaryRotetedSearch(nums, centralIndex, highIndex);
            }
            else
            {
                centralIndex = BinaryRotetedSearch(nums, lowIndex, centralIndex);

            }

            return centralIndex;
        }

        //187.Repeated DNA Sequences
        public static  IList<string> FindRepeatedDnaSequences(string s)
        {
            var res = new HashSet<string>();
            const int Length = 10;
            var hashtable = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'C', 2 },
                { 'G', 3 },
                { 'T', 4 }
            };
            var hashtableFor10LengthString = new Dictionary<long, int>();

            for (var i = 0; i < s.Length - 9; i++)
            {
                long rollingHash = 0;
                for (var j = 0; j < Length; j++)
                {
                    // get rolling hash, base 10
                    rollingHash = hashtable[s[i + j]] + rollingHash * 10;
                }

                if (hashtableFor10LengthString.ContainsKey(rollingHash))
                {
                    res.Add(s.Substring(i, 10));
                }
                else
                {
                    hashtableFor10LengthString.Add(rollingHash, i);
                }
            }

            return res.ToList();
        }

        //365. Water and Jug Problem
        public static bool CanMeasureWater(int x, int y, int z)
        {
            // corner cases
            if (x < 0 && y < 0)
            {
                return false;
            }

            if (z > (x + y))
            {
                return false;
            }

            if (x == z || y == z || x + y == z || z == 0)
            {
                return true;
            }

            // initialize conditions. We fill the bigger bucket full first and leave smaller one empty
            int bigger = Math.Max(x, y);
            int smaller = Math.Min(x, y);

            int biggerBucket = bigger;
            int smallerBucket = 0;

            // when smaller bucket is full we have tried every sum combinations
            while (smallerBucket != smaller)
            {
                int gap = smaller - smallerBucket;
                int leftOver = biggerBucket - gap;

                if (leftOver == z || leftOver + smaller == z)
                {
                    return true;
                }

                if (leftOver <= smaller)
                {
                    if (leftOver + bigger == z)
                    {
                        return true;
                    }

                    smallerBucket = leftOver;
                    biggerBucket = bigger;
                }
                else
                {
                    smallerBucket = 0;
                    biggerBucket = leftOver;
                }
            }

            return false;
        }

        //322. Coin Change

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
            if (rem < 0)
                return -1;
            if (rem == 0)
                return 0;
            if (count[rem - 1] != 0)
                return count[rem - 1];
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
