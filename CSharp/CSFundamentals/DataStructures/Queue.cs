using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    public class Queue<T>
    {
        private SinglyLinkedList<T> queue = new SinglyLinkedList<T>();

        public void Enqueue(T value)
        {
            queue.AddToEnd(value);
        }

        public T Peek()
        {
            if (queue.Head == null)
            {
                return default(T);
            }

            return queue.Head.Value;
        }

        public T Dequeue()
        {
            if(queue.Head == null)
            {
                return default(T);
            }

            return queue.GetAndRemoveHead();
        }
    }
}
