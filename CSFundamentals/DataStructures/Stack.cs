using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    public class Stack<T>
    {
        private SinglyLinkedList<T> stack = new SinglyLinkedList<T>();

        /// <summary>
        /// Pushes the value to the top of the stack.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            stack.AddToBeginning(value);
        }

        /// <summary>
        /// Returns the top value of the stack without removing the item.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if(stack.Head == null)
            {
                return default(T);
            }

            return stack.Head.Value;
        }

        /// <summary>
        /// Returns and removes the top value of the stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T value = stack.GetAndRemoveHead();
            return value;
        }
    }
}
