using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// A balanced binary search tree.
    /// Every node is either red or black.
    /// The root is black.
    /// All leaves are null pointers and colored black.
    /// Every red node has 2 black child nodes.
    /// Every path has the same black node count from root to leaf.
    /// 
    /// Run time analysis:
    ///                 Average         Worst
    ///                 ---------------------
    ///     Space       O(n)            O(n)
    ///     Search      O(log n)        O(log n)
    ///     Insert      O(log n)        O(log n)
    ///     Delete      O(log n)        O(log n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RedBlackTree<T> : IBinaryTree<T>
        where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }

        private RedBlackTreeNode<T> InternalRoot { get; set; }

        public void Add(T value)
        {
        }

        public void Remove(T value)
        {
        }
    }
}
