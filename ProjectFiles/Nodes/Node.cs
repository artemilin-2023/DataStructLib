using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStucturesLibrary.ProjectFiles.Nodes
{
    internal class Node<T> : BaseNode<T>
    {
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> nextNode = null) : base(value)
        {
            Next = nextNode;
        }

    }
}
