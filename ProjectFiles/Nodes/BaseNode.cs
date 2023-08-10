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
            if (value == null)
            {
                throw new ArgumentNullException(nameof(Data), "Полю \"Data\" не может быть присвоено значение типа null.");
            }

            Data = value;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
