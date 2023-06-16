using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStucturesLibrary
{
    internal abstract class Node<T>
    {
        public T Value { get; set; }

        public Node(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(Value), "Полю \"Value\" не может быть присвоено значение типа null.");
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
