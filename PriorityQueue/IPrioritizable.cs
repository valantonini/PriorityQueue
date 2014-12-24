using System;

namespace PriorityQueueCollection
{
    public interface IPrioritizable
    {
        /// <summary>
        /// Adds an action to be called each time the PriorityQueue's index is updated
        /// </summary>
        /// <param name="indexUpdated">An action to call after the indexed value is updated</param>
        void AddIndexUpdatedAction(Action indexUpdated);

        /// <summary>
        /// Removes the action thats called when the index is updated
        /// </summary>
        void RemoveIndexUpdatedAction();
    }
}
