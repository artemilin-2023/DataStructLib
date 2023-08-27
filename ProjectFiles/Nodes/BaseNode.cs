using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStucturesLibrary.ProjectFiles.Nodes
{
    internal abstract class BaseNode<T>
    {
        public T Data { get; set; }

        public BaseNode(T value)
        { 
            Data = value;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
