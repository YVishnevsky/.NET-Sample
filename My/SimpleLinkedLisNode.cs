using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My
{
    public class SimpleLinkedLisNode<T>
    {
        public T Value { get; internal set; }
        public SimpleLinkedLisNode<T> Next { get; internal set; }
        public SimpleLinkedLisNode<T> Previous { get; internal set; }
    }
}
