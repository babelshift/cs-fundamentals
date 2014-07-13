using CSFundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Performs "in place" sorting.
    /// Requires being able to index into data.
    /// Run time analysis:
    ///                 Average         Worst
    ///                 ---------------------
    ///     Space       O(log n)        O(log n)
    ///     Time        O(n log n)      O(n^2)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QuickSort<T> where T : IComparable
    {
        public static void Sort(T[] unsorted)
        {
            Sort(unsorted, 0, unsorted.Length - 1);
        }

        private static void Sort(T[] unsorted, int left, int right)
        {
            int boundary = Partition(unsorted, left, right);

            if (left < boundary - 1)
            {
                Sort(unsorted, left, boundary - 1);
            }

            if (boundary < right)
            {
                Sort(unsorted, boundary, right);
            }
        }

        private static int Partition(T[] unsorted, int left, int right)
        {
            int i = left;
            int j = right;
            T pivot = unsorted[(left + right) / 2];

            while (i <= j)
            {
                while (Utility.IsLessThan(unsorted[i], pivot))
                {
                    i++;
                }

                while (Utility.IsGreaterThan(unsorted[j], pivot))
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(unsorted, i, j);
                    i++;
                    j--;
                }
            }

            return i;
        }

        private static void Swap(T[] unsorted, int i, int j)
        {
            T temp = unsorted[i];
            unsorted[i] = unsorted[j];
            unsorted[j] = temp;
        }
    }
}
