using System;

namespace SimpleSortingAlgorithms
{
    public static class BubbleSortImplementation
    {
        public static T[] BubbleSort<T>(this T[] array)
            where T: IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = array.Length-1; j >= i; j--)
                {
                    if (array[j].CompareTo(array[j-1]) < 0)
                    {
                        ( array[j], array[j - 1] ) = ( array[j - 1], array[j] );
                    }
                }
            }

            return array;
        }

        public static T[] BubbleSortEnhanced<T>(this T[] array)
           where T : IComparable<T>
        {
            int lastSwappedIndex = 0;
            for (int i = array.Length - 1; i > -1; i = lastSwappedIndex)
            { 
                for (int j = lastSwappedIndex = 0; j < i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        lastSwappedIndex = j;
                    }
                }
            }

            return array;
        }

    }
}
