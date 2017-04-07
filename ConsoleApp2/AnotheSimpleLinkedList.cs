using My;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AnotheSimpleLinkedList<T> : SimpleLinkedList<T>
    {
        protected override void OnNodeAdded(SimpleLinkedLisNode<T> node)
        {
            Console.WriteLine("Node added");
            base.OnNodeAdded(node);
        }
    }
}
