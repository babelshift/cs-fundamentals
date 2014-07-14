using CSFundamentals.DataStructures;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class DepthFirstTraversal<T>
    {
        public static BinaryTreeNode<T> Search(BinaryTree<T> tree)
        {
            return null;
        }

        /// <summary>
        /// Traverses the passed tree in preorder and returns a comma delimited string of the values
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static string GetPreorder(IBinaryTree<T> tree)
        {
            string preorder = Preorder(tree.Root, String.Empty);
            return TrimTrailingComma(preorder);
        }

        /// <summary>
        /// Traverses the passed tree in inorder and returns a comma delimited string of the values
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static string GetInorder(IBinaryTree<T> tree)
        {
            string inorder = Inorder(tree.Root, String.Empty);
            return TrimTrailingComma(inorder);
        }

        /// <summary>
        /// Traverses the passed tree in postorder and returns a comma delimited string of the values
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static string GetPostorder(IBinaryTree<T> tree)
        {
            string inorder = Postorder(tree.Root, String.Empty);
            return TrimTrailingComma(inorder);
        }

        private static string TrimTrailingComma(string output)
        {
            return output.Remove(output.Length - 2);
        }

        private static string Preorder(BinaryTreeNode<T> node, string output)
        {
            if (node != null)
            {
                output += String.Format("{0}, ", node.Value);
            }

            if (node.Left != null)
            {
                output = Preorder(node.Left, output);
            }

            if (node.Right != null)
            {
                output = Preorder(node.Right, output);
            }

            return output;
        }

        private static string Inorder(BinaryTreeNode<T> node, string output)
        {
            if (node.Left != null)
            {
                output = Inorder(node.Left, output);
            }

            if (node != null)
            {
                output += String.Format("{0}, ", node.Value);
            }

            if (node.Right != null)
            {
                output = Inorder(node.Right, output);
            }

            return output;
        }

        private static string Postorder(BinaryTreeNode<T> node, string output)
        {
            if (node.Left != null)
            {
                output = Postorder(node.Left, output);
            }
            if (node.Right != null)
            {
                output = Postorder(node.Right, output);
            }

            if (node != null)
            {
                output += String.Format("{0}, ", node.Value);
            }

            return output;
        }
    }
}
