using System;

namespace SimpleSortingAlgorithms
{
    public static class ShellSortImplementation
    {
        public static T[] ShellSort<T>(this T[] array, int endSortIndex)
         where T : IComparable<T>
        {
            var steps = new int[] { 1391376, 463792, 198768, 86961, 33936, 13776, 4592, 1968, 861, 336, 112, 48, 21, 7, 3, 1 };

            for (int k = 0; k < steps.Length; k++)
            {
                int h = steps[k];
                for (int i = h; i <= endSortIndex; i++)
                {
                    var current = array[i];
                    int j = i;
                    while (j >= h && current.CompareTo(array[j - h]) < 0)
                    {
                        array[j] = array[j - h];
                        j -= h;
                    }

                    array[j] = current;
                }
            }

            return array;
        }
    }
}
