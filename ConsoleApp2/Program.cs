using My;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new AnotheSimpleLinkedList<int>();
            list.NodeAdded += (node)=> { Console.WriteLine("Added new node with value: {0}", node.Value); };

            list.AddFirst(5);
            list.AddFirst(4);
            var three = list.AddFirst(3);
            list.AddFirst(2);
            list.AddLast(6);
            list.AddFirst(1);
            var last = list.AddLast(7);
            list.AddAfter(three, 33);
            list.AddAfter(last, 77);
            list.AddBefore(three, 222);
            list.AddBefore(list.First, 0);
            list.RemoveBefore(three);
            list.RemoveAfter(list.First);
            
            foreach (var value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Search binary serch. index = {0}", new int[] {1, 100, 1000 }.BinarySearch(100));

            Console.ReadKey();
        }
    }
}
