using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedList() 
        {
                
        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.AddFirst(item);

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

            while (current is not null)
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
    }
}
