using System;
using System.Collections.Generic;
using System.Text;

namespace MyDataStucturesLibrary
{
    public class Queue<T> where T : IComparable
    {
        private DataNode<T> peak;
        private DataNode<T> lastNode;
        public int Count { get; private set; }

        public Queue()
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
            var newNode = new DataNode<T>(value);

            peak = newNode;
            lastNode = newNode;
        }

        private void AddNode(T value)
        {
            var newNode = new DataNode<T>(value);

            lastNode.NextNode = newNode;
            lastNode = newNode;
        }

        public T Dequeue()
        {
            ThrowExceptionIfQueueIsEmpty();

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

        private void ThrowExceptionIfQueueIsEmpty()
        {
            if (peak == null && lastNode == null)
            {
                throw new ArgumentNullException(nameof(peak), "Невозможно получить значение, так как очередь пуста");
            }
        }
        
        private T GetLastValue()
        {
            var result = peak.Value;

            peak = null;
            lastNode = null;

            return result;
        }

        private T GetPeakValue()
        {
            var result = peak.Value;

            peak = peak.NextNode;

            return result;
        }

        public T Peek()
        {
            ThrowExceptionIfQueueIsEmpty();

            return peak.Value;
        }

        public bool Contains(T desiredValue)
        {
            ThrowExceptionIfQueueIsEmpty();

            var tmpPeak = peak;

            while (tmpPeak != null)
            {
                if (tmpPeak.Value.CompareTo(desiredValue) == 0)
                {
                    return true;
                }
                tmpPeak = tmpPeak.NextNode;
            }

            return false;
        }

        public void Clear()
        {
            peak = null;
            lastNode = null;
            Count = 0;
        }

        public List<T> ToList()
        {
            ThrowExceptionIfQueueIsEmpty();

            var tmpPeak = peak;
            var result = new List<T>() { tmpPeak.Value };
            
            while (tmpPeak.NextNode != null)
            {
                result.Add(tmpPeak.NextNode.Value);
                tmpPeak = tmpPeak.NextNode;
            }

            return result;
        }
    }
}
