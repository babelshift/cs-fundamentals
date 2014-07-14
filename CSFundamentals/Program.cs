using Algorithms;
using CSFundamentals.DataStructures;
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

            TestBinarySearchTree();

            Console.ReadLine();
        }

        private static void TestBinarySearchTree()
        {
            /*
             * 
             *              10
             *             /  \
             *            5   20
             *           /    /
             *          2    13
             * 
             */

            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(5);
            tree.Add(2);
            tree.Add(20);
            tree.Add(13);

            Console.WriteLine(String.Format("Binary Search Tree - Preorder: {0}", DepthFirstTraversal<int>.GetPreorder(tree)));
            Console.WriteLine(String.Format("Binary Search Tree - Inorder: {0}", DepthFirstTraversal<int>.GetInorder(tree)));
            Console.WriteLine(String.Format("Binary Search Tree - Postorder: {0}", DepthFirstTraversal<int>.GetPostorder(tree)));

            tree.Remove(10);

            Console.WriteLine(String.Format("Binary Search Tree - Preorder (after removing 10): {0}", DepthFirstTraversal<int>.GetPreorder(tree)));
            Console.WriteLine(String.Format("Binary Search Tree - Inorder (after removing 10): {0}", DepthFirstTraversal<int>.GetInorder(tree)));
            Console.WriteLine(String.Format("Binary Search Tree - Postorder (after removing 10): {0}", DepthFirstTraversal<int>.GetPostorder(tree)));
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

            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);
            BinaryTreeNode<int> node1 = new BinaryTreeNode<int>(5);
            BinaryTreeNode<int> node2 = new BinaryTreeNode<int>(2);
            BinaryTreeNode<int> node3 = new BinaryTreeNode<int>(20);
            BinaryTreeNode<int> node4 = new BinaryTreeNode<int>(13);

            root.Left = node1;
            root.Right = node2;
            node1.Left = node3;
            node1.Right = node4;

            BinaryTree<int> tree = new BinaryTree<int>(root);
            Console.WriteLine(String.Format("Binary Tree - Preorder: {0}", DepthFirstTraversal<int>.GetPreorder(tree)));
            Console.WriteLine(String.Format("Binary Tree - Inorder: {0}", DepthFirstTraversal<int>.GetInorder(tree)));
            Console.WriteLine(String.Format("Binary Tree - Postorder: {0}", DepthFirstTraversal<int>.GetPostorder(tree)));

            BinaryTreeNode<int> foundNode = BreadthFirstTraversal<int>.Search(tree, 20);
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
            Hashtable<string, int> hashTable = new Hashtable<string, int>(50);
            hashTable.Add("Test", 29);
            hashTable.Add("Test2", 25);

            Console.WriteLine(String.Format("Key: {0}, Value: {1}", "Test", hashTable.Get("Test")));
            Console.WriteLine(String.Format("Key: {0}, Value: {1}", "Test2", hashTable.Get("Test2")));
        }
    }
}
