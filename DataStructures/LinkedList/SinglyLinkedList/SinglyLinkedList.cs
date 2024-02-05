using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedList()
        {

        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                AddFirst(item);

        }


        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head is null;
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }
        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            while (current.Next is not null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        public void AddAfter2(SinglyLinkedListNode<T> node, T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = node;

            if (current.Next is null)
            {
                current.Next = newNode;
                return;
            }

            newNode.Next = current.Next;

            current.Next = newNode;

        }
        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node is null)
                throw new ArgumentNullException();

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);

            var current = Head;
            while (current is not null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list");

        }
        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {

            var newNode = new SinglyLinkedListNode<T>(value);
            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            if (node == Head)
            {
                AddFirst(value);
                return;
            }

            var current = Head;
            //SinglyLinkedListNode<T> beforeNode = null;

            //while (current != node)
            //{
            //    beforeNode = current;
            //    current = current.Next;
            //}
            //newNode.Next = node;
            //beforeNode.Next = newNode;

            while (current.Next is not null)
            {
                if (current.Next == node)
                {
                    newNode.Next = node;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }


        }
        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SignlyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception("Nothing to remove");
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }

        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next is not null)
            {
                prev = current;
                current = current.Next;

            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }
        public void Remove(T value)
        {
            if (isHeadNull)
                throw new Exception("");

            if (value is null)
                throw new ArgumentException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value))
                {
                    //son elemanmı
                    if (current.Next is null)
                    {
                        //head silinmek isteniyor
                        if (prev is null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        if (prev is null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }

                }
                prev = current;
                current = current.Next;

            } while (current is not null);

            throw new ArgumentException();



        }

    }
}
