using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy
{
    class Easy
    {
        static void Main(string[] args)
        {
            //9. Palindrome Number
            //Console.WriteLine(IsPalindrome(int.Parse(Console.ReadLine())));

            //14 Longest Common Prefix
            //Console.WriteLine(LongestCommonPrefix(new[] { "dog","racecar","car" }));

            //35. Search Insert Position
            //Console.WriteLine(SearchInsert(new[] { 1, 3, 5, 6 }, 0));

            //27. Remove Element
            //Console.WriteLine(RemoveElement(new[] { 3, 2, 2, 3 },2));

            //198. House Robber
            //Console.WriteLine(Rob(new[] {2, 7, 9, 3, 1}));

            //949. Largest Time for Given Digits
            //var result = LargestTimeFromDigits(new int[] { 5, 5, 5, 4 });
            //Console.WriteLine(result);

            //Console.WriteLine(Rob(new[] {2, 7, 9, 3, 1}));

            //155. Min Stack
            //MinStack minStack = new MinStack();
            //minStack.Push(-2);
            //minStack.Push(0);
            //minStack.Push(-3);
            //Console.WriteLine(minStack.GetMin());
            //minStack.Pop();
            //Console.WriteLine(minStack.Top());
            //Console.WriteLine(minStack.GetMin());

            //605. Can Place Flowers
            Console.WriteLine(CanPlaceFlower(new[] { 1, 0, 0, 0, 1, 0, 0 }, 2));
        }
        //9. Palindrome Number
        public static bool IsPalindrome(int x)
        {
            var str = x.ToString();
            if (x<0)
            {
                return false;
            }
            if(str.Length==1 )
            {
                return true;
            }
            for (int i = 0; i < str.Length/2; i++)
            {
                if (str[i]!=str[str.Length-1-i])
                {
                    return false;
                }
            }

            return true;
        }

        //14 Longest Common Prefix
        public static string LongestCommonPrefix(string[] strs)
        {
            var result = "";
            if (strs.Length==0)
            {
                return result;
            }
            if (strs.Length==1)
            {
                return strs[0];
            }
            try
            {
                for (int i = 0; i < strs[0].Length; i++)
                {
                    for (int k = 1; k < strs.Length; k++)
                    {
                        if (strs[0][i]!=strs[k][i])
                        {
                            return result;
                        }
                    }
                    result += strs[0][i];
                }
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }

        //35. Search Insert Position
        public static int SearchInsert(int[] nums, int target)
        {
            int index = 0;
            if (nums.Length == 0)
            {
                return 0;
            }
            else if (nums.Length == 1)
            {
                if (nums[0] >= target)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            index = BinarySearch(nums, target, 0, nums.Length - 1);

            return index;
        }
        private static int BinarySearch(int[] nums, int target, int inIndex, int outIndex)
        {
            if (outIndex-inIndex<=1 )
            {
                if (nums[inIndex] == target)
                {
                    return inIndex;
                }
                else if (nums[outIndex]==target)
                {
                    return outIndex;
                }
                else if (nums[outIndex] <= target)
                {
                    return outIndex+1;
                }
                else if (nums[inIndex] > target)
                {
                    return inIndex ;
                }
                else
                {
                    return outIndex;
                }

            }

            int centerIndex = (outIndex + inIndex) / 2;
            int index = 0;
            if (nums[centerIndex]==target)
            {
                return (centerIndex);
            }
            if (nums[centerIndex]<target)
            {
               index= BinarySearch(nums, target, centerIndex, outIndex);
            }
            else
            {
                index=BinarySearch(nums, target, inIndex, centerIndex);
            }

            return index;
        }

        //27. Remove Element
        public static int RemoveElement(int[] nums, int val)
        {
            return nums.Where(x => x != val).ToArray().Count();
        }

        //198. House Robber
        public static int Rob(int[] nums)
        {
            if (nums.Length==1)
            {
                return nums[0];
            }
            var length = nums.Length;
            var result = new int[length];
            result[0] = nums[0];
            result[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < length; i++)
            {
                result[i] = Math.Max(result[i - 1], nums[i] + result[i - 2]);
            }

            return result.OrderByDescending(x => x).ToArray()[0];
        }

        //949. Largest Time for Given Digits
        public static string LargestTimeFromDigits(int[] A)
        {
            var options = A.ToList();
            var firstValues = options
                .Where(x => x < 3)
                .OrderByDescending(x => x)
                .ToList();
            if (firstValues.Count == 0)
            {
                return "";
            }
            for (int i = 0; i < firstValues.Count; i++)
            {
                int hourFirst = firstValues[i];
                options.Remove(firstValues[i]);

                var secondValues = new List<int>();
                if (hourFirst == 2)
                {
                    secondValues = options
                        .Where(x => x <= 3)
                        .OrderByDescending(x => x)
                        .ToList();
                }
                else
                {
                    secondValues = options
                      .Where(x => x <= 9)
                      .OrderByDescending(x => x)
                      .ToList();
                }
                if (secondValues.Count == 0)
                {
                    options.Add(firstValues[i]);
                    continue;
                }
                for (int j = 0; j < secondValues.Count; j++)
                {
                    int hourSecond = secondValues[j];
                    options.Remove(secondValues[j]);

                    var thirdValues = options
                        .Where(x => x <= 5)
                        .OrderByDescending(x => x)
                        .ToList();
                    if (thirdValues.Count == 0)
                    {
                        options.Add(secondValues[j]);
                        continue;
                    }
                    for (int k = 0; k < thirdValues.Count; k++)
                    {
                        int minutes = thirdValues[k];
                        options.Remove(thirdValues[k]);

                        if (options.Count > 0)
                        {
                            return $"{hourFirst}{hourSecond}:{minutes}{options[0]}";
                        }

                        options.Add(thirdValues[k]);
                    }


                    options.Add(secondValues[j]);
                }

                options.Add(firstValues[i]);

            }

            return "";
        }

        //605. Can Place Flowers
        private static bool CanPlaceFlower(int[] flowerbed, int n)
        {
            int freePlaces = 0;
            if (flowerbed.Length == 0)
            {
                return false;
            }
            else if (flowerbed.Length <= 2)
            {
                int plants = flowerbed.Sum(x => x);
                freePlaces = 1 - plants;
            }
            else
            {
                // Array length is bigger than 3
                bool previousIsZero = true;
                bool nextIsZero;
                for (int i = 0; i < flowerbed.Length; i++)
                {
                    if (flowerbed[i] == 0)
                    {
                        if (i == flowerbed.Length - 1)
                        {
                            nextIsZero = true;
                        }
                        else
                        {
                            nextIsZero = flowerbed[i + 1] == 0;
                        }

                        if (previousIsZero && nextIsZero)
                        {
                            freePlaces++;
                            previousIsZero = false;
                        }
                        else
                        {
                            previousIsZero = true;
                        }
                    }
                    else
                    {
                        previousIsZero = false;
                    }
                }
            }

            if (freePlaces >= n)
            {
                return true;
            }

            return false;
        }
    }
}
