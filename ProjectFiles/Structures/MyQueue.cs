using MyDataStucturesLibrary.ProjectFiles.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDataStucturesLibrary
{
    public class MyQueue<T> where T : IComparable
    {
        public int Count { get; private set; }

        private Node<T> peak;
        private Node<T> lastNode;

        public MyQueue()
        {
            Count = 0;
        }

        public void Enqueue(T value)
        {
            if (peak == null && lastNode == null)
            {
                AddFirstNode(value);
            }
            else
            {
                AddNode(value);
            }

            Count++;
        }

        private void AddFirstNode(T value)
        {
            var newNode = new Node<T>(value);

            peak = newNode;
            lastNode = newNode;
        }

        private void AddNode(T value)
        {
            var newNode = new Node<T>(value);

            lastNode.Next = newNode;
            lastNode = newNode;
        }

        public T Dequeue()
        {
            if (QueueIsEmpty())
                throw new Exception("Очередь пуста.");
            
            Count--;

            if (peak == lastNode)
            {
                return GetLastValue();
            }
            else
            {
                return GetPeakValue();
            }
        }

        private bool QueueIsEmpty()
        {
            return Count == 0;
        }
        
        private T GetLastValue()
        {
            var result = peak.Data;

            peak = null;
            lastNode = null;

            return result;
        }

        private T GetPeakValue()
        {
            var result = peak.Data;

            peak = peak.Next;

            return result;
        }

        public T Peek()
        {
            if (QueueIsEmpty())
                throw new Exception("Очередь пуста.");

            return peak.Data;
        }

        public bool Contains(T desiredValue)
        {
            if (QueueIsEmpty())
                return false;

            var tmpPeak = peak;

            while (tmpPeak != null)
            {
                if (tmpPeak.Data.CompareTo(desiredValue) == 0)
                {
                    return true;
                }
                tmpPeak = tmpPeak.Next;
            }

            return false;
        }

        public void Clear()
        {
            peak = null;
            lastNode = null;
            Count = 0;
        }

    }
}
