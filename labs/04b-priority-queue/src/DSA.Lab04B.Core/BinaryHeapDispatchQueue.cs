using System;
using System.Collections.Generic;

namespace DSA.Lab04B
{
    /// <summary>
    /// Priority queue implemented with a binary min-heap.
    ///
    /// Invariant:
    /// each parent's Priority is <= the Priority of each of its children.
    ///
    /// The heap is NOT fully sorted.
    /// </summary>
    public sealed class BinaryHeapDispatchQueue<T>
    {
        private readonly List<PriorityEntry<T>> _heap = new List<PriorityEntry<T>>();

        public int Count => _heap.Count;

        public void Enqueue(T item, int priority)
        {
            // TODO:
            // 1. Append the new entry at the end.
            // 2. Restore the heap invariant upward.

            _heap.Add(new PriorityEntry<T>(item, priority));

            SiftUp(_heap.Count - 1); //Count - 1 because the first index is 0, not one, so the entire bunch of indices are shifted down by 1.
        }

        public PriorityEntry<T> PeekNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {
            // TODO:
            // 1. Reject an empty queue.
            // 2. Remember the root: that is the minimum.
            // 3. Move the final heap entry to the root and remove the final slot.
            // 4. If anything remains, restore the invariant downward.
            // 5. Return the old root.

            if (_heap.Count == 0) throw new InvalidOperationException("The dispatch queue is empty.");

            PriorityEntry<T> topItem = _heap[0];
            
            _heap[0] = _heap[_heap.Count - 1];

            _heap.RemoveAt(_heap.Count - 1);

            SiftDown(0);

            return topItem;
        } 

        private void SiftUp(int internalIndex) //always takes in the last index of queue + creates its own int variable
        {
            // TODO: compare the entry with its parent and swap while needed.
            
            while (internalIndex > 0) //as it processes the variable the index decreases as it get swapped with its parent
            {
                if (_heap[ParentIndex(internalIndex)].Priority <= _heap[internalIndex].Priority) return; //priority here refers to the "priority tag" an item carries

                Swap(ParentIndex(internalIndex), internalIndex); //"Swap" Operates on the heap
                internalIndex = ParentIndex(internalIndex); //updates while loop argument
            }
        }

        private void SiftDown(int internalIndex)
        {
            // TODO:
            // Compare the current entry with its children.
            // If a child should come first, swap with the smaller-priority child.

            while (LeftChildIndex(internalIndex) < _heap.Count)
            {
                int leftChildIndex = LeftChildIndex(internalIndex);
                int rightChildIndex = RightChildIndex(internalIndex);

                int smallestChildIndex = leftChildIndex;

                if (rightChildIndex < _heap.Count && _heap[rightChildIndex].Priority < _heap[leftChildIndex].Priority) //smallest child is picked because when it becomes the new parent, it needs to be smaller than or equal to both its children, including its pre-swap sibling
                {
                    smallestChildIndex = rightChildIndex;
                } 

                if (_heap[internalIndex].Priority > _heap[smallestChildIndex].Priority)
                {
                    Swap(internalIndex, smallestChildIndex);
                    internalIndex = smallestChildIndex;
                }
                else return;
            }
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            PriorityEntry<T> temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
    }
}
