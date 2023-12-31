﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        private bool isHeadNull => Head is null;
        private bool isTailNull => Tail is null;

        public DoublyLinkedList()
        {

        }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (Head is not null)
            {
                Head.Prev = newNode;
            }

            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (Tail is null)
            {
                Tail = Head;
            }

        }
        public void AddLast(T value)
        {
            if (Tail is null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;

            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode is null)
                throw new ArgumentException();


            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Prev = refNode;
                refNode.Prev = null;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if (refNode != Tail)
            {
                newNode.Prev = refNode;
                newNode.Next = refNode.Next;

                refNode.Next.Prev = newNode;
                refNode.Next = newNode;

            }
            else
            {
                newNode.Prev = refNode;
                newNode.Next = null;

                refNode.Next = newNode;
                Tail = newNode;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode is null)
                throw new ArgumentNullException();
            if (newNode is null)
                throw new ArgumentNullException();


            //if (refNode == Tail && refNode == Head)
            //{
            //    AddFirst(newNode.Value);
            //    return;
            //}

            if (refNode == Head)
            {
                AddFirst(newNode.Value);
                return;
            }


            newNode.Prev = refNode.Prev;
            newNode.Next = refNode;

            refNode.Prev.Next = newNode;
            refNode.Prev = newNode;

        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current is not null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }

        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception();

            var temp = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;

        }

        public T RemoveLast()
        {
            if (isTailNull)
                throw new Exception();

            var temp = Tail.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }

            return temp;

        }
        public void Delete(T value)
        {
            if (isHeadNull)
                throw new Exception();

            if (Head == Tail)
            {
                if (Head.Value.Equals(value))
                    RemoveFirst();

                return;
            }

            var current = Head;
            while (current is not null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev is null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    else if (current.Next is null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    else
                    {
                        current.Prev.Next = null;
                        current.Next.Prev = null;
                    }
                    break;
                }
                current = current.Next;

            }

        }

        //my delete 
        public void Delete(DoublyLinkedListNode<T> node)
        {
            if (node is null)
                throw new Exception();

            if (isHeadNull)
                throw new Exception();

            if (node == Head && node == Tail)
            {
                RemoveFirst();
                return;
            }

            if (node == Head)
            {
                RemoveFirst();
                return;
            }

            if (node == Tail)
            {
                RemoveLast();
                return;
            }

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

        }
    }
}
