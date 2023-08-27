using System;
using System.Collections.Generic;
using System.Text;

namespace MyDataStucturesLibrary.ProjectFiles.Nodes
{
    internal class TwoLinksNode<T> : BaseNode<T>
    {
        public TwoLinksNode<T> Previous { get; set; }
        public TwoLinksNode<T> Next { get; set; }

        public TwoLinksNode(T value, TwoLinksNode<T> previous = null, TwoLinksNode<T> next = null) : base(value)
        {
            Previous = previous;
            Next = next;
        }
    }
}
