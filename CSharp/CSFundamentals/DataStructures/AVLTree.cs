using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// A balanced binary search tree.
    /// Each subtree height of any given node cannot differ by more than 1.
    /// If a difference occurs, rebalancing is required.
    /// Slower insertion/deletion than red-black, but faster retrieval (due to more strict balancing).
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
    /// See: http://www.superstarcoders.com/blogs/posts/efficient-avl-tree-in-c-sharp.aspx
    public class AVLTree<T> where T : IComparable
    {
        private AVLTreeNode<T> Root { get; set; }

        /// <summary>
        /// Adds the value to a node while maintaining AVL balance
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            // if the root is null then we have an empty tree, create a node at the root
            if(Root == null)
            {
                Root = new AVLTreeNode<T>(value);
            }
            else
            {
                AVLTreeNode<T> node = Root;

                while (node != null)
                {
                    int compareValues = value.CompareTo(node.Value);

                    // new value is less than node value
                    if(compareValues < 0)
                    {
                        AVLTreeNode<T> left = node.Left;

                        if(left == null)
                        {
                            node.Left = new AVLTreeNode<T>(value, node);

                            InsertAndBalance(node, 1);

                            return;
                        }
                        else
                        {
                            node = left;
                        }
                    }
                    // new value is greater than node value
                    else if(compareValues > 0)
                    {
                        AVLTreeNode<T> right = node.Right;

                        if (right == null)
                        {
                            node.Right = new AVLTreeNode<T>(value, node);

                            InsertAndBalance(node, -1);

                            return;
                        }
                        else
                        {
                            node = right;
                        }
                    }
                    // new value equals node value
                    else
                    {
                        node.Value = value;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Insert the passed node and maintain the balance of the tree according to AVL
        /// </summary>
        /// <param name="node"></param>
        /// <param name="balance"></param>
        private void InsertAndBalance(AVLTreeNode<T> node, int balance)
        {
            while(node != null)
            {
                node.Balance += balance;
                balance = node.Balance;

                if(balance == 0)
                {
                    return;
                }
                else if(balance == 2)
                {
                    if(node.Left.Balance == 1)
                    {
                        RotateRight(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                }
                else if (balance == -2)
                {
                    if(node.Right.Balance == -1)
                    {
                        RotateLeft(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }

                    return;
                }

                AVLTreeNode<T> parent = node.Parent;

                if(parent != null)
                {
                    if (parent.Left == node)
                    {
                        balance = 1;
                    }
                    else
                    {
                        balance = -1;
                    }
                }

                node = parent;
            }
        }

        public void Remove(T value)
        {

        }

        /// <summary>
        /// Rotate the tree left around the passed node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLTreeNode<T> RotateLeft(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> right = node.Right;
            AVLTreeNode<T> rightLeft = right.Left;
            AVLTreeNode<T> parent = node.Parent;

            right.Parent = parent;
            right.Left = node;
            node.Right = rightLeft;
            node.Parent = right;

            if(rightLeft != null)
            {
                rightLeft.Parent = node;
            }

            if(node == Root)
            {
                Root = right;
            }
            else if(parent.Right == node)
            {
                parent.Right = right;
            }
            else
            {
                parent.Left = right;
            }

            right.Balance++;
            node.Balance = (right.Balance * -1);

            return right;
        }

        /// <summary>
        /// Rotate the tree right around the passed node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> left = node.Left;
            AVLTreeNode<T> leftRight = left.Right;
            AVLTreeNode<T> parent = node.Parent;

            left.Parent = parent;
            left.Right = node;
            node.Left = leftRight;
            node.Parent = left;

            if (leftRight != null)
            {
                leftRight.Parent = node;
            }

            if (node == Root)
            {
                Root = left;
            }
            else if (parent.Left == node)
            {
                parent.Left = left;
            }
            else
            {
                parent.Right = left;
            }

            left.Balance--;
            node.Balance = (left.Balance * -1);
            return left;
        }

        /// <summary>
        /// Rotate the tree left and then right around the passed node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLTreeNode<T> RotateLeftRight(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> left = node.Left;
            AVLTreeNode<T> leftRight = left.Right;
            AVLTreeNode<T> parent = node.Parent;
            AVLTreeNode<T> leftRightRight = leftRight.Right;
            AVLTreeNode<T> leftRightLeft = leftRight.Left;

            leftRight.Parent = parent;
            node.Left = leftRightRight;
            left.Right = leftRightLeft;
            leftRight.Left = left;
            leftRight.Right = node;
            left.Parent = leftRight;
            node.Parent = leftRight;

            if (leftRightRight != null)
            {
                leftRightRight.Parent = node;
            }

            if (leftRightLeft != null)
            {
                leftRightLeft.Parent = left;
            }

            if (node == Root)
            {
                Root = leftRight;
            }
            else if (parent.Left == node)
            {
                parent.Left = leftRight;
            }
            else
            {
                parent.Right = leftRight;
            }

            if (leftRight.Balance == -1)
            {
                node.Balance = 0;
                left.Balance = 1;
            }
            else if (leftRight.Balance == 0)
            {
                node.Balance = 0;
                left.Balance = 0;
            }
            else
            {
                node.Balance = -1;
                left.Balance = 0;
            }

            leftRight.Balance = 0;

            return leftRight;
        }

        /// <summary>
        /// Rotate the tree right and then left around the passed node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLTreeNode<T> RotateRightLeft(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> right = node.Right;
            AVLTreeNode<T> rightLeft = right.Left;
            AVLTreeNode<T> parent = node.Parent;
            AVLTreeNode<T> rightLeftLeft = rightLeft.Left;
            AVLTreeNode<T> rightLeftRight = rightLeft.Right;

            rightLeft.Parent = parent;
            node.Right = rightLeftLeft;
            right.Left = rightLeftRight;
            rightLeft.Right = right;
            rightLeft.Left = node;
            right.Parent = rightLeft;
            node.Parent = rightLeft;

            if (rightLeftLeft != null)
            {
                rightLeftLeft.Parent = node;
            }

            if (rightLeftRight != null)
            {
                rightLeftRight.Parent = right;
            }

            if (node == Root)
            {
                Root = rightLeft;
            }
            else if (parent.Right == node)
            {
                parent.Right = rightLeft;
            }
            else
            {
                parent.Left = rightLeft;
            }

            if (rightLeft.Balance == 1)
            {
                node.Balance = 0;
                right.Balance = -1;
            }
            else if (rightLeft.Balance == 0)
            {
                node.Balance = 0;
                right.Balance = 0;
            }
            else
            {
                node.Balance = 1;
                right.Balance = 0;
            }

            rightLeft.Balance = 0;

            return rightLeft;
        }

        /// <summary>
        /// Performs an iterative search for the node containing the value. Returns the null if the value does not exist in the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public AVLTreeNode<T> Search(T value)
        {
            AVLTreeNode<T> node = Root;

            while(node != null)
            {
                if(Utility.IsLessThan(value, node.Value))
                {
                    node = node.Left;
                }
                else if(Utility.IsGreaterThan(value, node.Value))
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }
    }
}
