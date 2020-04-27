using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSortAlgorithm
{
    public static class QuickSort    
    {
        public static List<T> Sort<T>(List<T> listToSort)            
            where T: IComparable<T>
        {
            if (listToSort.Count <= 1)
            {
                return listToSort;
            }

            var lowerList = new List<T>();
            var higherList = new List<T>();

            var rand = new Random();
            var indexToCompare = rand.Next(listToSort.Count);
            var valueToCompare = listToSort[indexToCompare];

            for (int i = 0; i < indexToCompare; i++)
            {
                if (listToSort[i].CompareTo(valueToCompare) <= 0)
                {
                    lowerList.Add(listToSort[i]);
                }
                else
                {
                    higherList.Add(listToSort[i]);
                }
            }

            for (int i = indexToCompare + 1 ; i < listToSort.Count ; i++)
            {
                if (listToSort[i].CompareTo(valueToCompare) <= 0)
                {
                    lowerList.Add(listToSort[i]);
                }
                else
                {
                    higherList.Add(listToSort[i]);
                }
            }

            return Concat(Sort(lowerList), valueToCompare, Sort(higherList));
        }

        public static List<T> SortSwap<T>(List<T> listToSort)
            where T : IComparable<T>
        {
            SortQuickly(listToSort, 0, listToSort.Count - 1);

            return listToSort;
        }

        private static void SortQuickly<T>(List<T> listToSort, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            var start = startIndex;
            var end = endIndex;
            var currentValue = listToSort[end];

            do
            {
                while (currentValue.CompareTo(listToSort[start]) > 0)
                {
                    start++;
                }
                while (currentValue.CompareTo(listToSort[end]) < 0)
                {
                    end--;
                }

                if (start <= end)
                {
                    (listToSort[start], listToSort[end]) = (listToSort[end], listToSort[start]);
                    start++;
                    end--;
                }
            } while (end >= start);

            if (end > startIndex)
            {
                SortQuickly(listToSort, startIndex, end);
            }

            if (start < endIndex)
            {
                SortQuickly(listToSort, start, endIndex);
            }
        }

        private static List<T> Concat<T>(List<T> low,T middleValue ,List<T> high)
        {
            var resultList = new List<T>(low.Count + high.Count);

            resultList.AddRange(low);
            resultList.Add(middleValue);
            resultList.AddRange(high);

            return resultList;
        }

    }
}
