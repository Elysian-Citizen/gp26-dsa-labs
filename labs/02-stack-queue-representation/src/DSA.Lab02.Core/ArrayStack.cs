using System;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            // TODO: place the item at the logical top and update the state.

            if (Count >= Capacity)
            {
                throw new InvalidOperationException();
            }

            _items[_count] = item;
            _count++;
        }

        public T Peek()
        {
            // TODO: return the logical top without removing it.
            if (_items[_count - 1] == null)
            {
                throw new InvalidOperationException();
            }

            return _items[_count - 1];
        }

        public T Pop()
        {
            // TODO: remove and return the logical top.
            
            if (_count <= 0)
            {
                throw new InvalidOperationException("Cannot pop from empty stack!");
            }

            _count--;
            T popItem = _items[_count];
            _items[_count] = default!;

            return popItem;

        }
    }
}
