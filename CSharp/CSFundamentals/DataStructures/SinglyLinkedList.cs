using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    /// <summary>
    /// Represents a single node in a singly linked list with a value and a pointer to the next node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; private set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Runtime characteristics of a Linked List:
    /// Indexing:                   O(n)
    /// Insert/delete beginning:    O(n)
    /// Insert/delete end:          O(n) if last unknown, O(1) if last known
    /// Insert/delete middle:       Search time + O(1)
    /// Wasted space (average):     O(n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; private set; }

        /// <summary>
        /// Searches for the first node containing the passed value in O(n) time.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> FindNodeWithValue(T value)
        {
            Node<T> currentNode = Head;

            while (currentNode != null)
            {
                if(currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            // nothing found, return null
            return null;
        }

        /// <summary>
        /// Adds the value to the beginning of the linked list in O(1) time.
        /// </summary>
        /// <param name="value"></param>
        public void AddToBeginning(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Next = Head;
            Head = node;
        }

        /// <summary>
        /// Adds the passed value to the end of the list in O(n) time.
        /// </summary>
        /// <param name="node"></param>
        public void AddToEnd(T value)
        {
            Node<T> newNode = new Node<T>(value);

            Node<T> currentNode = Head;

            // we have no head yet, create it
            if(currentNode == null)
            {
                Head = newNode;
                return;
            }

            // traverse the list to the end
            while(currentNode != null)
            {
                // if we've hit the last node, attach the passed node at the end
                if(currentNode.Next == null)
                {
                    currentNode.Next = newNode;
                    break;
                }

                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Removes the head from the linked list in O(1) time.
        /// </summary>
        /// <returns></returns>
        public T GetAndRemoveHead()
        {
            T headValue = Head.Value;
            Head = Head.Next;
            return headValue;
        }
    }
}
