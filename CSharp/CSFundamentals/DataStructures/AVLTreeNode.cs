using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// Represents a single node in an AVL tree with values, parent, left child, right child, and a balance indicator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTreeNode<T>
    {
        public T Value { get; set; }
        public AVLTreeNode<T> Parent { get; set; }
        public AVLTreeNode<T> Left { get; set; }
        public AVLTreeNode<T> Right { get; set; }
        public int Balance { get; set; }

        public AVLTreeNode(T value)
        {
            Value = value;
        }

        public AVLTreeNode(T value, AVLTreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
        }
    }
}
