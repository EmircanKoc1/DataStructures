using DataStructures.LinkedList;
using System;
using System.Linq;

namespace Apps
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = new char[] { 'a', 'b', 'c', };
            var linkedList = new SinglyLinkedList<char>(arr);

            var rnd = new Random();
            var list = Enumerable.Range(1, 10).OrderBy(x => rnd.Next());
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
