using DataStructures.LinkedList.DoublyLinkedList;
using System;

namespace DataStructures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        public int Count
        {
            get;
            private set;
        }
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public T DeQueue()
        {
            if (Count is 0)
                throw new Exception("Empty Queue!");

            var temp = list.RemoveFirst();
            Count--;
            return temp;

        }

        public void EnQueue(T value)
        {
            if (value is null)
                throw new ArgumentNullException();

            list.AddLast(value);
            Count++;

        }

        public T Peek()
        {
            if (Count is 0)
                throw new Exception();

            return list.Head.Value;
        }
    }
}