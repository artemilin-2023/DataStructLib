using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStucturesLibrary
{
    internal class DataNode<T> : Node<T>
    {
        public DataNode<T> NextNode;

        public DataNode(T value, DataNode<T> nextNode = null) : base(value)
        {
            NextNode = nextNode;
        }
    }
}
