using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSortingAlgorithms
{
    public static class ShakeSortImplementation
    {
        public static T[] ShakeSort<T>(this T[] array)
            where T: IComparable<T>
        {
            int swapIndex = array.Length;
            int right = swapIndex - 1;
            int left;
            int index;
            do
            {
                for (index = right; index >= 1; index--)
                {
                    if (array[index-1].CompareTo(array[index]) > 0)
                    {
                        (array[index - 1], array[index]) = (array[index], array[index - 1]);
                        swapIndex = index;
                    }
                }

                left = swapIndex + 1;

                for ( index = 1; index <= right; index++)
                {
                    if (array[index - 1].CompareTo(array[index]) > 0)
                    {
                        (array[index - 1], array[index]) = (array[index], array[index - 1]);
                        swapIndex = index;
                    }
                }

                right = swapIndex - 1;

            } while (left <= right);

            return array;
        }
    }
}
