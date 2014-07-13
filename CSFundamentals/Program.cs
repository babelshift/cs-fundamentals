using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            TestHashTable();

            int[] unsorted = GenerateRandomIntArray();

            TestSorting(unsorted);

            Console.ReadLine();
        }

        private static int[] GenerateRandomIntArray()
        {
            Random random = new Random();
            List<int> unsorted = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                unsorted.Add(random.Next(1, 1000));
            }
            return unsorted.ToArray();
        }

        private static void TestSorting(int[] unsortedArray)
        {
            Console.WriteLine(String.Format("Unsorted: {0}", String.Join(", ", unsortedArray)));

            int[] sorted = MergeSort<int>.Sort(unsortedArray);
            Console.WriteLine(String.Format("Merge Sorted: {0}", String.Join(", ", sorted)));

            QuickSort<int>.Sort(unsortedArray);
            Console.WriteLine(String.Format("Quick Sorted: {0}", String.Join(", ", unsortedArray)));
        }

        private static void TestHashTable()
        {
            DataStructures.Hashtable<string, int> hashTable = new DataStructures.Hashtable<string, int>(50);
            hashTable.Add("Test", 29);
            hashTable.Add("Test2", 25);

            Console.WriteLine(String.Format("Key: {0}, Value: {1}", "Test", hashTable.Get("Test")));
            Console.WriteLine(String.Format("Key: {0}, Value: {1}", "Test2", hashTable.Get("Test2")));
        }
    }
}
