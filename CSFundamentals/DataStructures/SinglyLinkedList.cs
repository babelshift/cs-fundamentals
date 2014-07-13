using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Represents a single node in a singly linked list with a value and a pointer to the next node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public Node<T> Next { get; private set; }
        public T Value { get; private set; }

        public Node(Node<T> next, T value)
        {
            Next = next;
            Value = value;
        }

        public void SetNext(Node<T> next)
        {
            Next = next;
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

        public SinglyLinkedList(Node<T> head)
        {
            Head = head;
        }

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
        /// Adds the passed node to the end of the linked list in O(n) time.
        /// </summary>
        /// <param name="node"></param>
        public void AddNodeToEnd(Node<T> node)
        {
            Node<T> currentNode = Head;

            while(currentNode != null)
            {
                // if we've hit the last node, attach the passed node at the end
                if(currentNode.Next == null)
                {
                    currentNode.Next.SetNext(node);
                }

                currentNode = currentNode.Next;
            }
        }


    }
}
