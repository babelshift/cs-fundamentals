using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.Algorithms
{
    public static class BinarySearch<T>
        where T : IComparable
    {
        public static int Search(T[] elements, T value)
        {
            QuickSort<T>.Sort(elements);

            return Search(elements, value, 0, elements.Length - 1);
        }

        private static int Search(T[] elements, T value, int beginIndex, int endIndex)
        {
            int middle = (int)((beginIndex + endIndex) / 2);

            T middleValue = elements[middle];

            // if the value we need is less than the middle value, go to the left half
            if (Utility.IsLessThan(value, middleValue))
            {
                return Search(elements, value, 0, middle - 1);
            }
            // otherwise, go to the right half
            else if (Utility.IsGreaterThan(value, middleValue))
            {
                return Search(elements, value, middle + 1, elements.Length - 1);
            }
            else
            {
                return middle;
            }

            return -1;
        }
    }
}
