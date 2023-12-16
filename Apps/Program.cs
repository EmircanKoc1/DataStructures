using DataStructures.LinkedList.DoublyLinkedList;
using System;

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
         

            //1 2 3 4
            //1 2 9999 3 4
            list.AddBefore(list.Head,new DoublyLinkedListNode<int>(9999));
            Console.WriteLine();

        }
    }
}
