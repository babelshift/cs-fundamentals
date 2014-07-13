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
        public static TreeNode<T> Search(BinaryTree<T> tree, T value)
        {
            Queue<TreeNode<T>> search = new Queue<TreeNode<T>>();
            search.Enqueue(tree.Root);
            while (search.Count > 0)
            {
                TreeNode<T> currentNode = search.Dequeue();
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
