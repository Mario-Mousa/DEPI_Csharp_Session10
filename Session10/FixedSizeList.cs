using System;

namespace Session10
{
    public class FixedSizeList<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public FixedSizeList(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item)
        {
            if (count >= capacity)
                throw new InvalidOperationException(
                    "Cannot add item: the list is already full (capacity = " + capacity + ").");

            items[count] = item;
            count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException(
                    "Invalid index: " + index + ". Valid range is 0 to " + (count - 1) + ".");

            return items[index];
        }
    }
}