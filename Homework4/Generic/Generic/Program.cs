using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }

        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;
            public GenericList()
            {
                tail = head = null;
            }
            public Node<T> Head
            {
                get => head;
            }
            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
            public void ForEach(Action<T> action)
            {

                for(Node<T> node = this.Head; node != null; node = node.Next)
                {
                    action(node.Data);
                }
            }

        }
        static void Main(string[] args)
        {
            int max = 0, min = 0, sum = 0;
            GenericList<int> intlist = new GenericList<int>();
            for(int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            intlist.ForEach(x => Console.WriteLine(x));
            intlist.ForEach(x => { if (x > max) { max = x; } });
            intlist.ForEach(x => { if (x < min) { min = x; } });
            intlist.ForEach(x => sum += x);
            Console.WriteLine($"链表的最大值为{max}，最小值为{min},总和为{sum}");

        }
    }
}
