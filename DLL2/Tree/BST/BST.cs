using DataStructures.Tree.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Tree.BST
{
    public class BST<T> : IEnumerable<T>
        where T : IComparable
    {
        public Node<T> Root { get; set; }
        public BST()
        {

        }
        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }


        public void Add(T value)
        {
            if (value is null)
                throw new ArgumentNullException();

            var newNode = new Node<T>(value);

            if (Root is null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;

                while (true)
                {
                    parent = current;

                    //solt-alt ağaç
                    if (value.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;

                        if (current is null)
                        {
                            parent.Left = newNode;
                            break;
                        }

                    }
                    //Sağ-alt ağaç
                    else
                    {
                        current = current.Right;

                        if (current is null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }


                }



            }

        }

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;

            while (current.Left is not null)
            {
                current = current.Left;
            }

            return current;
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while (current.Right is not null)
            {
                current = current.Right;
            }
            return current;
        }

        public Node<T> Find(Node<T> root, T key)
        {
            var current = root;

            while (key.CompareTo(current.Value) is not 0)
            {
                if (key.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                if (current is null)
                {
                    throw new Exception("Could not found");
                }
            }

            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root is null)
                return null;

            if (key.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, key);
            }
            else if (key.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, key);
            }
            else
            {
                //tek cocuk yada cocuksuz
                if (root.Left is null)
                {
                    return root.Right;
                }
                else if (root.Right is null)
                {
                    return root.Left;
                }

                //iki cocuk
                root.Value = FindMax(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);
            }
            return root;

        }

      


        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




    }
}
