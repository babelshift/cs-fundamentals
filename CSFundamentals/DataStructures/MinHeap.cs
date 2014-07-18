using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// An array-based minimum binary heap.
    /// 
    /// Run time analysis:
    ///                 Average         Worst
    ///                 ---------------------
    ///     Space       O(n)            O(n)
    ///     Search      N/A        N/A
    ///     Insert      O(log n)        O(log n)
    ///     Delete      O(log n)        O(log n)
    ///     Get Min     O(1)            O(1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> where T : IComparable
    {
        private List<T> heap = new List<T>();

        /// <summary>
        /// Returns a comma delimited string of all elements in the heap.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join(", ", heap);
        }

        /// <summary>
        /// Returns the number of elements in the heap.
        /// </summary>
        public int Count { get { return heap.Count; } }

        /// <summary>
        /// Adds the value to the heap while maintaining the heap properties.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            heap.Add(value);

            int i = Count - 1;

            while(i > 0)
            {
                int j = (i + 1) / 2 - 1;

                T otherValue = heap[j];
                if(Utility.IsLessThan(otherValue, heap[i]) || otherValue.Equals(heap[i]))
                {
                    break;
                }

                SwapElements(i, j);

                i = j;
            }
        }

        /// <summary>
        /// Returns the minimum value in the heap without removing it from the heap. Returns the default value of T if the heap is empty.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (heap.Count == 0)
            {
                return default(T);
            }

            return heap[0];
        }

        /// <summary>
        /// Returns the minimum value in the heap, removes it from the heap, and performs a heapify operation. Returns the default value of T if the heap is empty.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if(heap.Count == 0)
            {
                return default(T);
            }

            T minimum = heap[0];
            heap[0] = heap[Count - 1];
            heap.RemoveAt(Count - 1);
            Heapify(0);

            return minimum;
        }

        /// <summary>
        /// Performs a heap-building operation to maintain heap properties. Call this after removing anything from the heap to ensure that the heap
        /// maintains proper ordering.
        /// </summary>
        /// <param name="i"></param>
        private void Heapify(int i)
        {
            int smallest = 0;
            int left = 2 * (i + 1) - 1;
            int right = 2 * (i + 1); // ?

            if(left < Count && (Utility.IsLessThan(heap[left], heap[i])))
            {
                smallest = left;
            }
            else
            {
                smallest = i;
            }

            if (right < Count && (Utility.IsLessThan(heap[right], heap[smallest])))
            {
                smallest = right;
            }

            if(smallest != i)
            {
                SwapElements(i, smallest);
                Heapify(smallest);
            }
        }

        /// <summary>
        /// Swaps elements in the heap at indices i and j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void SwapElements(int i, int j)
        {
            T temp = heap[j];
            heap[j] = heap[i];
            heap[i] = temp;
        }
    }
}
