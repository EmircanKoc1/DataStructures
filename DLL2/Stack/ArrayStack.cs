using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count
        {
            get;
            private set;
        }
        private readonly List<T> list = new List<T>();

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("Empty Stack");
            return list[Count - 1];

        }

        public T Pop()
        {
            if (Count is 0)
                throw new Exception("Empty Stack");

            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if (value is null)
                throw new ArgumentException();
            list.Add(value);
            Count++;
        }

    }
}