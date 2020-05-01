using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchAlgorithm
{
    public static class BinarySearch
    {
        public static int SearchIndex<T>(this T[] orderedArray, T value)
            where T : IComparable<T>
        {
            //return RecursiveBinary(orderedArray, value, 0, orderedArray.Length - 1);            
            return IterativeBinary(orderedArray, value, 0, orderedArray.Length - 1);            
        }

        private static int IterativeBinary<T>(T[] orderedArray, T value, int startIndex, int endIndex) 
            where T : IComparable<T>
        {
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) >> 1;
                if (value.CompareTo(orderedArray[midIndex]) < 0)
                {
                    endIndex = midIndex - 1;
                }
                else if (value.CompareTo(orderedArray[midIndex]) > 0)
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    return midIndex;
                }
            }

            return -1;
        }

        private static int RecursiveBinary<T>(T[] orderedArray, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            var indexToCheck = (startIndex + endIndex) >> 1;

            if (value.CompareTo(orderedArray[indexToCheck]) < 0)
            {
                return RecursiveBinary(orderedArray, value, startIndex, indexToCheck - 1);
            }
            else if(value.CompareTo(orderedArray[indexToCheck]) > 0)
            {
                return RecursiveBinary(orderedArray, value, indexToCheck + 1, endIndex);
            }
            else
            {
                return indexToCheck;
            }           
        }
    }
}
