PriorityQueue
=============

[![Build Status](https://travis-ci.org/valantonini/PriorityQueue.svg?branch=master)](https://travis-ci.org/valantonini/PriorityQueue)

A C# priority queue

Items will need to implement the provided [IPrioritizable](https://github.com/valantonini/PriorityQueue/blob/master/PriorityQueue/IPrioritizable.cs) interface which has 2 methods AddIndexUpdatedAction(Action indexUpdated) and RemoveIndexUpdatedAction(). Save the indexUpdated action to a field variable and call it whenever the indexed value is changed. A comparer class will also need to be provided.

e.g.

    public class PrioritizableItem : IPrioritizable
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

    public class ComparePrioritizableItem : IComparer<PrioritizableItem>
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
