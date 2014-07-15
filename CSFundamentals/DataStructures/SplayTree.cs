using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// Frequently accessed nodes are “splayed” closer to the root (tree is then rebalanced around that movement).
    /// Useful for implementing caches and garbage collectors where locality is important.
    /// BAD: Height can become linear (access elements in non-decreasing order).
    /// 
    /// Run time analysis:
    ///                 Average         Worst
    ///                 ---------------------
    ///     Space       O(n)            O(n)
    ///     Search      O(log n)        O(n)
    ///     Insert      O(log n)        O(n)
    ///     Delete      O(log n)        O(n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SplayTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public void Add(T value)
        {

        }

        public void Remove(T value)
        {

        }
    }
}
