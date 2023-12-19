using System;
using DataStructures.Stack;
using DataStructures.Tree.BinaryTree;
using DataStructures.Tree.BST;

namespace Apps
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bst = new BST<int>(new int[] {23,16,45,3,22,37,99});

            Console.WriteLine(bst.FindMax(bst.Root).Value);
            Console.WriteLine(bst.RMAX(bst.Root).Value);
        }
    }
}
