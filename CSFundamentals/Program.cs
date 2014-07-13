using Algorithms;
using DataStructures;
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

            TestBinaryTree();

            Console.ReadLine();
        }

        private static void TestBinaryTree()
        {
            /*
             * 
             *              10
             *             /  \
             *            5    2
             *           / \ 
             *          20 13
             * 
             */

            TreeNode<int> root = new TreeNode<int>(10);
            TreeNode<int> node1 = new TreeNode<int>(5);
            TreeNode<int> node2 = new TreeNode<int>(2);
            TreeNode<int> node3 = new TreeNode<int>(20);
            TreeNode<int> node4 = new TreeNode<int>(13);

            root.Left = node1;
            root.Right = node2;
            node1.Left = node3;
            node1.Right = node4;

            BinaryTree<int> tree = new BinaryTree<int>(root);
            Console.WriteLine(String.Format("Preorder: {0}", DepthFirstTraversal<int>.GetPreorder(tree)));
            Console.WriteLine(String.Format("Inorder: {0}", DepthFirstTraversal<int>.GetInorder(tree)));
            Console.WriteLine(String.Format("Postorder: {0}", DepthFirstTraversal<int>.GetPostorder(tree)));

            TreeNode<int> foundNode = BreadthFirstTraversal<int>.Search(tree, 20);
            Console.WriteLine(String.Format("Breadth First Search for {0}: {1}", 20, foundNode != null ? "Yes" : "No"));
            foundNode = BreadthFirstTraversal<int>.Search(tree, 30);
            Console.WriteLine(String.Format("Breadth First Search for {0}: {1}", 30, foundNode != null ? "Yes" : "No"));
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
