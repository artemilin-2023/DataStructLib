using System;
using System.Collections.Generic;

namespace MyDataStucturesLibrary
{
    public class Stack<T> where T: IComparable
    {
        private DataNode<T> peak;

        public int Count { get; private set; }

        public Stack()
        {
            Count = 0;
        }

        public void Add(T value)
        {
            if (peak == null)
            {
                peak = new DataNode<T>(value, null);
            }
            else
            {
                peak = new DataNode<T>(value, peak);
            }

            Count++;
        }

        public T Pop()
        {
            ThrowExcetionIfStackIsEmpty();

            var result = peak.Value;

            if (peak.NextNode == null)
            {
                peak = null;
            }
            else
            {
                peak = peak.NextNode;
            }

            Count--;
            return result;
        }
        
        private void ThrowExcetionIfStackIsEmpty()
        {
            if (peak == null)
            {
                throw new ArgumentNullException(nameof(peak), "Невозможно получить значение, так как стек пуст.");
            }
        }

        public T Peek()
        {
            ThrowExcetionIfStackIsEmpty();

            return peak.Value;
        }

        public void Clear()
        {
            peak = null;
            Count = 0;
        }

        public bool Contains(T desiredValue)
        {
            ThrowExcetionIfStackIsEmpty();

            var tmpPeak = peak;

            while(tmpPeak != null)
            {
                if (tmpPeak.Value.CompareTo(desiredValue) == 0)
                {
                    return true;
                }

                tmpPeak = tmpPeak.NextNode;
            }

            return false;
        }

        public List<T> ToList()
        {
            ThrowExcetionIfStackIsEmpty();

            var tmpPeak = peak;
            var result = new List<T> { tmpPeak.Value };
            
            while (tmpPeak.NextNode != null)
            {
                result.Add(tmpPeak.NextNode.Value);
                tmpPeak = tmpPeak.NextNode;
            }

            return result;
        }

    }
}
