using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T>
        where T : IComparable
    {
        public List<Node<T>> list { get; private set; } = new List<Node<T>>();
        public Node<T> Root { get; private set; }

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
            //List<Node<T>> list  = new List<Node<T>>();
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

                if (temp.Left is not null)
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
        public int MaxDepth(Node<T> root)
        {
            if (root is null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;

        }
        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root is null)
                throw new Exception("Empty tree!");

            var q = new Queue<Node<T>>();

            q.Enqueue(root);

            while (q.Count > 0)
            {
                temp = q.Dequeue();

                if (temp.Left is not null)
                    q.Enqueue(temp.Left);

                if (temp.Right is not null)
                    q.Enqueue(temp.Right);
            }
            return temp;
        }
        public Node<T> DeepestNode()
        {
            var list = LevelOrderNonRecursiveTraversal(Root);
            return list[list.Count - 1];
        }
        public int NumberOfLeafs(Node<T> root)
        {
            int count = 0;
            if (root is null)
            {
                return count;
            }

            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();

                if (temp.Left is null && temp.Right is null)
                    count++;

                if (temp.Left is not null)
                {
                    q.Enqueue(temp.Left);
                }
                if (temp.Right is not null)
                {
                    q.Enqueue(temp.Right);
                }



            }
            return count;

        }
        public static int NumberOfFullNodes(Node<T> root) =>
             new BinaryTree<T>()
            .LevelOrderNonRecursiveTraversal(root)
            .Where(node => node.Left is not null && node.Right is not null)
            .ToList()
            .Count;
        public static int NumberOfHalfNodes(Node<T> root) =>
             new BinaryTree<T>()
            .LevelOrderNonRecursiveTraversal(root)
            .Where(node => node.Left is not null ^ node.Right is not null)
            .ToList()
            .Count;


        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root is null)
            {
                return;
            }

            path[pathLen] = root.Value;
            pathLen++;

            if (root.Left is null && root.Right is null)
            {
                PrintArray(path, pathLen);
            }
            else
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }


        }
        private void PrintArray(T[] path, int len)
        {
            for (int i = 0; i < len; i++)
                Console.Write(path[i]);
            Console.WriteLine();
        }
    }
}
