using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace _7._3.BinaryMergeSortedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstSize = 3;
            var firstArr = new int[firstSize];
            var secondSize = 4;
            var secondArr =  new int[secondSize];

            InitializeArray(ref firstArr, 5, 11);
            InitializeArray(ref secondArr, 9, 7);
            Console.WriteLine(string.Join(" ",firstArr));
            Console.WriteLine(string.Join(" ",secondArr));


            int[] result = BinaryMergeSortedArrays(firstArr, secondArr);
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] BinaryMergeSortedArrays(int[] firstArr, int[] secondArr)
        {
            var firstLen = firstArr.Length;
            var secondLen = secondArr.Length;
            var totalLength = firstLen + secondLen;
            var power = 0;
            var elementsCount = 0;
            var searchedIndex = -1;
            int[] result = new int[totalLength];

            while (firstLen > 0 && secondLen > 0) 
            {
                power = (int)(Math.Log(firstLen / secondLen) / Math.Log(2));
                elementsCount = 1 << power;
                if (secondLen <= firstLen) 
                {
                    if (secondArr[secondLen - 1] < firstArr[firstLen - elementsCount])
                    {
                        /* Прехвърляне на a[n-t2-1],...,a[n] в изходната последователност */
                        totalLength -= elementsCount;
                        firstLen = elementsCount;
                        for (int i = 0; i < elementsCount; i++)
                            result[totalLength + i] = firstArr[firstLen + i];                        
                    }
                    else
                    {
                        searchedIndex = BinarySearch(firstArr, firstLen - elementsCount, firstLen - 1, secondArr[secondLen - 1]);
                        for (int i = 0; i < firstLen - searchedIndex - 1; i++)
                            result[totalLength - firstLen + i + 1] = firstArr[searchedIndex + i + 1];
                        totalLength -= firstLen - searchedIndex - 1;
                        firstLen = searchedIndex + 1;
                        result[--totalLength] = secondArr[--secondLen];
                    }
                }
                else
                {
                    if (firstArr[firstLen - 1] < secondArr[secondLen - elementsCount])
                    {
                        totalLength -= elementsCount;
                        secondLen -= elementsCount;
                        for (int i = 0; i < elementsCount; i++)
                            result[totalLength + i] = secondArr[secondLen + i];
                    }
                    else
                    {
                        searchedIndex = BinarySearch(secondArr, secondLen - elementsCount, secondLen - 1, firstArr[firstLen - 1]);
                        for (int i = 0; i < secondLen - searchedIndex - 1; i++)
                            result[totalLength - secondLen + searchedIndex + i + 1] = secondArr[searchedIndex + i + 1];
                        totalLength -= secondLen - searchedIndex - 1;
                        secondLen = searchedIndex + 1;
                        result[--totalLength] = firstArr[--firstLen];
                        
                    }
                }

            }
                        
            if (firstLen == 0)
                for (int i = 0; i < secondLen; i++)
                    result[i] = secondArr[i];
            else
                for (int i = 0; i < firstLen; i++)
                    result[i] = firstArr[i];             
                      
            return result;
        }

        private static int BinarySearch(int[] input, int left, int right, int elementToFind)
        {
            do
            {
                int middle = (left + right) / 2;
                if (input[middle] < elementToFind)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle -1;
                }
            } while (left <= right);

            return right;
        }

        private static void InitializeArray(ref int[] input, int modulOne, int modulTwo)
        {
            var rnd = new Random(modulOne + modulTwo);

            input[0] = rnd.Next() % modulOne;
            for (int i = 1; i < input.Length; i++)
                input[i] = input[i - 1] + (rnd.Next() % modulTwo); 
        }
    }
}