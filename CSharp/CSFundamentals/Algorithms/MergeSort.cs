using CSFundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.Algorithms
{
    /// <summary>
    /// Best for sorting sequential access data structures
    /// Uses more space than QuickSort because multiple arrays are required as sorting is not done "in place"
    /// Run time analysis:
    ///                 Average         Worst
    ///                 ---------------------
    ///     Space       O(n)            O(n)        if arrays
    ///     Space       O(log n)        O(log n)    if linked lists
    ///     Time        O(n log n)      O(n log n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class MergeSort<T> where T : IComparable
    {
        public static T[] Sort(T[] unsorted)
        {
            if (unsorted == null || unsorted.Length <= 1)
            {
                return unsorted;
            }

            int middle = unsorted.Length / 2;

            T[] left = new T[middle];                       // left half is from beginning to middle
            T[] right = new T[unsorted.Length - middle];    // right half is from middle to end

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = unsorted[i];
            }

            for (int j = 0; j < right.Length; j++)
            {
                right[j] = unsorted[middle + j];
            }

            left = Sort(left);
            right = Sort(right);
            T[] sorted = Merge(left, right);

            return sorted;
        }

        private static T[] Merge(T[] left, T[] right)
        {
            T[] merged = new T[left.Length + right.Length];

            int i = 0;
            int p1 = 0;
            int p2 = 0;

            while (p1 < left.Length && p2 < right.Length)
            {
                if (Utility.IsLessThan(left[p1], right[p2]))
                {
                    merged[i++] = left[p1++];
                }
                else
                {
                    merged[i++] = right[p2++];
                }
            }

            while(p1 < left.Length)
            {
                merged[i++] = left[p1++];
            }

            while(p2 < right.Length)
            {
                merged[i++] = right[p2++];
            }

            return merged;
        }
    }
}
