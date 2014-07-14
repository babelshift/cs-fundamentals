using CSFundamentals.DataStructures;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BreadthFirstTraversal<T>
    {
        /// <summary>
        /// Performs a breadth first search for a value in the passed tree.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BinaryTreeNode<T> Search(IBinaryTree<T> tree, T value)
        {
            Queue<BinaryTreeNode<T>> search = new Queue<BinaryTreeNode<T>>();
            search.Enqueue(tree.Root);
            while (search.Count > 0)
            {
                BinaryTreeNode<T> currentNode = search.Dequeue();
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                if (currentNode.Left != null)
                {
                    search.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    search.Enqueue(currentNode.Right);
                }
            }
            return null;
        }
    }
}
