using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    public enum RedBlackTreeNodeColor
    {
        Red,
        Black
    }

    public class RedBlackTreeNode<T>
    {
        public T Value { get; set; }
        public RedBlackTreeNode<T> Parent { get; set; }
        public RedBlackTreeNode<T> Left { get; set; }
        public RedBlackTreeNode<T> Right { get; set; }
        public RedBlackTreeNodeColor Color { get; set; }

        public RedBlackTreeNode(T value, RedBlackTreeNodeColor color)
        {
            Value = value;
            Color = color;
        }
    }
}
