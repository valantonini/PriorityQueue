using System;
using System.Collections.Generic;

namespace PriorityQueueCollection
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IPrioritizable
    {
        private readonly List<T> _innerList = new List<T>();
        private readonly IComparer<T> _comparer;
        private readonly Action _indexUpdatedAction;

        private bool _requiresSort = true;

        public int Count
        {
            get { return _innerList.Count; }
        }

        public PriorityQueue(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            _indexUpdatedAction = () => _requiresSort = true;
        }

        public void Push(T item)
        {
            item.AddIndexUpdatedAction(_indexUpdatedAction);
            _innerList.Add(item);
        }

        public T Pop()
        {
            if (_innerList.Count <= 0)
            {
                return default(T);
            }

            if (_requiresSort)
            {
                _innerList.Sort(_comparer);
                _requiresSort = false;
            }

            var item = _innerList[0];
            item.RemoveIndexUpdatedAction();

            _innerList.RemoveAt(0);

            return item;
        }

        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }
    }
}
