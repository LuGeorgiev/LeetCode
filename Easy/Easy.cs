using System;
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

            //155. Min Stack
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine(minStack.GetMin());
            minStack.Pop();
            Console.WriteLine(minStack.Top());
            Console.WriteLine(minStack.GetMin());

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
    }
}
