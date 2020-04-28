using System;
using System.Collections.Generic;

namespace TortoiseRabitsAlgorithm
{
    public static class ComboSort
    {
        public static List<T> SortByCombo<T>(this List<T> listToSort)
            where T: IComparable<T>
        {
            var gap = listToSort.Count - 1;
            var step = 0;
            var j = 0;
            do
            {
                step = 0;
                gap = (int)(gap / 1.3);
                if (gap < 1)
                {
                    gap = 1;
                }

                for (int i = 0; i < listToSort.Count - gap; i++)
                {
                    j = i + gap;
                    if (listToSort[i].CompareTo(listToSort[j]) > 0)
                    {
                        (listToSort[i], listToSort[j]) = (listToSort[j], listToSort[i]);
                        step++;
                    }
                }

            } while (step != 0 || gap > 1);

            return listToSort;
        }
    }
}
