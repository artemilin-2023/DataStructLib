using MyDataStucturesLibrary.ProjectFiles.Nodes;
using System;
using System.Collections.Generic;

namespace MyDataStucturesLibrary
{
    public class MyStack<T> where T: IComparable
    {
        public int Count { get; private set; }

        private Node<T> peak;

        public MyStack()
        {
            Count = 0;
        }

        public void Add(T value)
        {
            if (peak == null)
            {
                peak = new Node<T>(value, null);
            }
            else
            {
                peak = new Node<T>(value, peak);
            }

            Count++;
        }

        public T Pop()
        {
            if (StackIsEmpty())
                throw new Exception("Стек пуст.");

            var result = peak.Data;

            if (peak.Next == null)
            {
                peak = null;
            }
            else
            {
                peak = peak.Next;
            }

            Count--;
            return result;
        }
        
        private bool StackIsEmpty()
        {
            return Count == 0;
        }

        public T Peek()
        {
            if (StackIsEmpty())
                throw new Exception("Стек пуст.");

            return peak.Data;
        }

        public void Clear()
        {
            peak = null;
            Count = 0;
        }

        public bool Contains(T desiredValue)
        {
            if (StackIsEmpty())
                return false;

            var tmpPeak = peak;

            while(tmpPeak != null)
            {
                if (tmpPeak.Data.CompareTo(desiredValue) == 0)
                {
                    return true;
                }

                tmpPeak = tmpPeak.Next;
            }

            return false;
        }

    }
}
