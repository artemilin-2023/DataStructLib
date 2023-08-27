using MyDataStucturesLibrary.ProjectFiles.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace MyDataStucturesLibrary.ProjectFiles.Structures
{
    public class MyLinkedList<T>
    {
        public int Count { get; private set; }

        private TwoLinksNode<T> firstNode;
        private TwoLinksNode<T> lastNode;

        public MyLinkedList()
        {
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if(!IndexIsCorrect(index))
                    throw new IndexOutOfRangeException();

                return GetNodeBy(index).Data;
            }
            set
            {
                if (!IndexIsCorrect(index))
                    throw new IndexOutOfRangeException();

                GetNodeBy(index).Data = value;
            }
        }
        private bool IndexIsCorrect(int index)
        {
            return index < Count && index >= 0;
        }

        private TwoLinksNode<T> GetNodeBy(int index)
        {
            if (index == 0)
            {
                return firstNode;
            }
            else if (index == Count - 1)
            {
                return lastNode;
            }

            if (index <= Count / 2)
            {
                return GetNodeInLeftPart(index);
            }
            else
            {
                return GetNodeInRightPart(index);
            }
        }

        private TwoLinksNode<T> GetNodeInLeftPart(int index)
        {
            var result = firstNode;

            for (int i = 0; i < index; i++)
            {
                result = result.Next;
            }

            return result;
        }

        private TwoLinksNode<T> GetNodeInRightPart(int index)
        {
            var result = lastNode;

            for (int i = Count - 1; i > index; i--)
            {
                result = result.Previous;
            }

            return result;
        }

        public void Add(T value)
        {
            if (firstNode == null)
            {
                AddFirstNode(value);
            }
            else
            {
                AddNewNode(value);
            }

            Count++;
        }

        private void AddFirstNode(T value)
        {
            firstNode = new TwoLinksNode<T>(value);
            lastNode = firstNode;
        }

        private void AddNewNode(T value)
        {
            var tmpNode = new TwoLinksNode<T>(value, previous: lastNode);

            lastNode.Next = tmpNode;
            lastNode = tmpNode;
        }

        public void RemoveBy(int index)
        {
            if (ListIsEmpty())
                throw new Exception("Список пуст.");

            if (!IndexIsCorrect(index))
                throw new IndexOutOfRangeException();

            if (Count == 1)
            {
                Clear();
                return;
            }

            if (index == 0)
            {
                firstNode = firstNode.Next;
                firstNode.Previous = null;
            }
            else if (index == Count - 1)
            {
                lastNode = lastNode.Previous;
                lastNode.Next = null;
            }
            else
            {
                var deletedNode = GetNodeBy(index);

                deletedNode.Previous.Next = deletedNode.Next;
                deletedNode.Next.Previous = deletedNode.Previous;
            }

            Count--;
        }

        private bool ListIsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            firstNode = null;
            lastNode = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            if (ListIsEmpty())
                return false;

            var leftNode = firstNode;
            var rightNode = lastNode;

            for (var i = 0; i < Count / 2; i++)
            {
                if (leftNode.Data.Equals(value) || rightNode.Data.Equals(value))
                    return true;

                leftNode = leftNode.Next;
                rightNode = rightNode.Previous;
            }

            return false;
        }

    }
}
