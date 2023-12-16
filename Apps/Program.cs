using DataStructures.LinkedList.DoublyLinkedList;
using System;
using System.Collections.Generic;

namespace Apps
{
    public class Program
    {
        static void Main(string[] args)
        {
        
            var list = new DoublyLinkedList<int>();
            
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            
            list.AddBefore(list.Head.Next.Next,new DoublyLinkedListNode<int>(9999));

            list.Delete(list.Head.Next.Next.Next);
         
            //list.Delete(9999);
            Console.WriteLine();

        }
    }
}
