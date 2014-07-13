using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreeNode<T>
    {
        public T Value { get; private set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
        }
    }

    public class BinaryTree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public BinaryTree(TreeNode<T> root)
        {
            Root = root;
        }
    }
}
