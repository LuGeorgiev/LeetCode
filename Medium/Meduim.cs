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
            Console.WriteLine(FindMin(new[] { 3,2,1 }));
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
    }
}
