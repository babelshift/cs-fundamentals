using CSFundamentals;
using CSFundamentals.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<T> : IBinaryTree<T>
        where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public void Remove(T value)
        {
            BinaryTreeNode<T> node = FindRecursive(value);
            if(node != null)
            {
                Remove(node);
            }
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            // node has two children
            if(node.Left != null && node.Right != null)
            {
                BinaryTreeNode<T> newNode = node.Right;
                while (newNode.Left != null)
                {
                    newNode = newNode.Left;
                }
                node.Value = newNode.Value;
                node = newNode;
            }

            BinaryTreeNode<T> child = node.Left != null ? node.Left : node.Right;
            
            // node has one child
            if (child != null)
            {
                child.Parent = node.Parent;

                // this is the root
                if (node.Parent == null)
                {
                    Root = child;
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = child;
                    }
                    else
                    {
                        node.Parent.Right = child;
                    }
                }
            }
            // node has no children
            else
            {
                // this is the root
                if (node.Parent == null)
                {
                    Root = null;
                }
                // these are leaf nodes to be removed
                else
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = null;
                    }
                    else
                    {
                        node.Parent.Right = null;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the passed value to the binary search tree while perserving its properties.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Root = Add(null, Root, value);
        }

        private BinaryTreeNode<T> Add(BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node, T value)
        {
            if(node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.Parent = parentNode;
            }
            else if (Utility.IsLessThan(value, node.Value))
            {
                node.Left = Add(node, node.Left, value);
            }
            else if (Utility.IsGreaterThan(value, node.Value))
            {
                node.Right = Add(node, node.Right, value);
            }

            return node;
        }

        /// <summary>
        /// Uses a recursive search method to find the passed value. Returns null if the value does not exist in the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> FindRecursive(T value)
        {
            return FindRecursive(Root, value);
        }

        private BinaryTreeNode<T> FindRecursive(BinaryTreeNode<T> node, T value)
        {
            if(node == null || node.Value.Equals(value))
            {
                return node;
            }
            else if(Utility.IsLessThan(value, node.Value))
            {
                return FindRecursive(node.Left, value);
            }
            else 
            {
                return FindRecursive(node.Right, value);
            }
        }

        /// <summary>
        /// Uses an iterative search method to find the passed value. Returns null if the value does not exist in the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> FindIterative(T value)
        {
            return FindIterative(Root, value);
        }

        private BinaryTreeNode<T> FindIterative(BinaryTreeNode<T> node, T value)
        {
            BinaryTreeNode<T> currentNode = node;
            while(currentNode != null)
            {
                if(currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                else if(Utility.IsLessThan(value, currentNode.Value))
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
            return null;
        }
    }
}
