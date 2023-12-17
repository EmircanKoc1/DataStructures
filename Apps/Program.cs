using System;
using DataStructures.Stack;

namespace Apps
{
    public class Program
    {
        static void Main(string[] args)
        {
            var charset = new char[]
            {
                'a','b','c'
            };
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>(StackType.LinkedList);
            foreach (var c in charset)
            {
                stack1.Push(c);
                stack2.Push(c);
            }
            Console.WriteLine(stack1.Peek());
            Console.WriteLine(stack1.Pop());

            Console.WriteLine(stack2.Peek());
            Console.WriteLine(stack2.Pop());
        }
    }
}
