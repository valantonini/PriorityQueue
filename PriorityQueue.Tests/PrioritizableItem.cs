using System;
using System.Collections.Generic;

namespace PriorityQueueCollection.Tests
{
    internal class PrioritizableItem : IPrioritizable
    {
        private Action _indexUpdated;
        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                _indexUpdated();
                _value = value;
            }
        }

        public PrioritizableItem(int value)
        {
            _indexUpdated = () => { };
            Value = value;
        }

        public void AddIndexUpdatedAction(Action indexUpdated)
        {
            _indexUpdated = indexUpdated;
        }

        public void RemoveIndexUpdatedAction()
        {
            _indexUpdated = () => { };
        }
    }

    internal class ComparePrioritizableItem : IComparer<PrioritizableItem>
    {
        public int Compare(PrioritizableItem x, PrioritizableItem y)
        {
            if (x.Value > y.Value)
            {
                return 1;
            }
            if (x.Value < y.Value)
            {
                return -1;
            }
            return 0;
        }
    }
}
