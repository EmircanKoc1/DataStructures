using System;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        public int Count
        {
            get;
            private set;
        }

        private readonly List<T> list = new List<T>();


        public T DeQueue()
        {
            if (Count is 0)
                throw new Exception("Empty Queue!");

            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void EnQueue(T value)
        {
            if (value is null)
                throw new Exception();

            list.Add(value);
            Count++;
        }

        public T Peek()
        {
            if (Count is 0)
                throw new Exception("Empty Queue!");

            return list[0];

        }
    }
}