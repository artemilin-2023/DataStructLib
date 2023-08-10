using System;
using System.Collections.Generic;
using System.Text;

namespace MyDataStucturesLibrary.ProjectFiles.Nodes
{
    internal class ListNode<T> : BaseNode<T>
    {
        public ListNode<T> Previous { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T value, ListNode<T> previous = null, ListNode<T> next = null) : base(value)
        {
            Previous = previous;
            Next = next;
        }
        
    }
}
