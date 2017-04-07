using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        public SimpleLinkedLisNode<T> First { get; private set; }
        public SimpleLinkedLisNode<T> Last { get; private set; }
        public int Count { get; private set; }

        public delegate void ListChagedHandler(SimpleLinkedLisNode<T> node);
        
        public event ListChagedHandler NodeAdded;

        protected virtual void OnNodeAdded(SimpleLinkedLisNode<T> node)
        {
            if (NodeAdded != null)
            {
                NodeAdded(node);
            }
        }

        public SimpleLinkedLisNode<T> AddFirst(T element)
        {
            var newNode = new SimpleLinkedLisNode<T> { Value = element };

            if (Count == 0)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = First.Previous = newNode;
            }

            if (++Count == 2)
            {
                Last = newNode.Next;
            }

            OnNodeAdded(newNode);

            return newNode;
        }

        public SimpleLinkedLisNode<T> AddLast(T element)
        {
            var newNode = new SimpleLinkedLisNode<T> { Value = element };

            if (Count == 0)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Previous = Last;
                Last = Last.Next = newNode;
            }

            Count++;

            OnNodeAdded(newNode);

            return newNode;
        }

        public void RemoveFirst()
        {
            if (Count == 1)
            {
                Clear();
            }
            else
            {
                First = First.Next;
                First.Previous = null;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count == 1)
            {
                Clear();
            }
            else
            {
                Last = Last.Previous;
                Last.Next = null;
                Count--;
            }
        }

        public SimpleLinkedLisNode<T> AddAfter(SimpleLinkedLisNode<T> node, T element)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (node.Next == null)
            {
                return AddLast(element);
            }
            else
            {
                var newNode = new SimpleLinkedLisNode<T> { Value = element, Next = node.Next, Previous = node };
                node.Next = node.Next.Previous = newNode;
                Count++;

                OnNodeAdded(newNode);

                return newNode;
            }
        }

        public SimpleLinkedLisNode<T> AddBefore(SimpleLinkedLisNode<T> node, T element)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (node.Previous == null)
            {
                return AddFirst(element);
            }
            else
            {
                var newNode = new SimpleLinkedLisNode<T> { Value = element, Next = node, Previous = node.Previous };
                node.Previous = node.Previous.Next = newNode;
                Count++;

                OnNodeAdded(newNode);

                return newNode;
            }
        }

        public void RemoveBefore(SimpleLinkedLisNode<T> node)
        {
            if (node == null || node.Previous == null)
            {
                throw new ArgumentNullException();
            }

            if (node.Previous.Previous == null)
            {
                RemoveFirst();
            }
            else
            {
                node.Previous = node.Previous.Previous;
                node.Previous.Next = node;
            }
        }

        public void RemoveAfter(SimpleLinkedLisNode<T> node)
        {
            if (node == null || node.Next == null)
            {
                throw new ArgumentNullException();
            }

            if (node.Next.Next == null)
            {
                RemoveLast();
            }
            else
            {
                node.Next = node.Next.Next;
                node.Next.Previous = node;
            }
        }

        public void Clear()
        {
            First = Last = null;
            Count = 0;
        }

#region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
#endregion
    }
}
