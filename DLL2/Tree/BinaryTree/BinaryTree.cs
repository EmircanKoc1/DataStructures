using System;
using System.Collections.Generic;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T>
        where T : IComparable
    {
        public List<Node<T>> list { get; private set; } = new List<Node<T>>();
        //recursive
        public void ClearList() => list.Clear();
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (root is not null)
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (root is not null)
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);

            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (root is not null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);

            }
            return list;
        }

        //iteratif
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;

            while (!done)
            {
                if (currentNode is not null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (S.Count is 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }

            }
            return list;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();

            if (root is null)
                throw new Exception("This Tree is empty");

            S.Push(root);

            while (S.Count is not 0)
            {
                var temp = S.Pop();
                list.Add(temp);
                if (temp.Right is not null)
                {
                    S.Push(temp.Right);
                }
                if (temp.Left is not null)
                {
                    S.Push(temp.Left);
                }
            }
            return list;
        }
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            Q.EnQueue(root);

            while (Q.Count > 0)
            {
                var temp = Q.DeQueue();
                list.Add(temp);

                if(temp.Left is not null)
                {
                    Q.EnQueue(temp.Left);
                }
                if (temp.Right is not null)
                {
                    Q.EnQueue(temp.Left);
                }

            }

            return list;
        }

    }
}
