using System;

namespace SimpleSortingAlgorithms
{
    public static class InsertionSort
    {
        public static T[] InsertSrt<T>(this T[] array)
            where T : IComparable<T>
        {
            if (array.Length <= 1)
            {
                return array;
            }

            for (int increaseIndex = 1; increaseIndex < array.Length; increaseIndex++)
            {
                var currentValue = array[increaseIndex];
                var swapIndex = increaseIndex;
                for (int decreaseIndex = increaseIndex - 1; decreaseIndex >= 0; decreaseIndex--)
                {
                    if (currentValue.CompareTo(array[decreaseIndex]) < 0)
                    {
                        (array[swapIndex], array[decreaseIndex]) = (array[decreaseIndex], array[swapIndex]);
                        currentValue = array[decreaseIndex];
                        swapIndex = decreaseIndex;
                    }
                    else
                    {
                        //previous elements are already sorted. this elements is currently on its place
                        break;
                    }
                }

            }

            return array;
        }



        //More elegant way. thi sis the way given in the book
        public static T[] StraightInsertion<T>(this T[] array)
            where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                var currentValue = array[i];
                int j = i - 1;

                while (j >= 0 && currentValue.CompareTo(array[j]) < 0)
                {
                    array[j + 1] = array[j--];
                }

                array[j + 1] = currentValue;
            }

            return array;
        }

     
    }
}
