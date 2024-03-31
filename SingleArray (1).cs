using System.Collections;

namespace HW3_4.Implementations
{
    public sealed class SingleArray<T>
        where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 11;
        private T[] items;
        private int size;

        public SingleArray(int capacity=DEFAULT_CAPACITY)
        {
            items = new T[capacity];
            size = capacity;
        }

        public T this[int index] { get => items[index]; set => items[index] = value; }

        private void EnsureCapacity(int value)
        {
            if (items.Length < value)
            {
                int capacity = items.Length == 0 ? DEFAULT_CAPACITY : items.Length * 2 + 1;
                if (capacity < value)
                {
                    capacity = value;
                }
                T[] new_array = new T[capacity];
                for (int i = 0; i < size; i++)
                {
                    new_array[i] = items[i];
                }
                items = new_array;
            }
        }
        
        public void Add(T item)
        {
            if (size == items.Length)
            {
                EnsureCapacity(size + 1);
            }
            items[size++] = item;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item, 0, size);
            if (index >= 0)
            {
                size--;
                if (index < size)
                {
                    for (int i = index; i < size; i++)
                    {
                        items[i] = items[i + 1];
                        items[size] = default;
                    }
                    return true;
                }
            }
            return false;
        }

        public int Count => size;

        public int CountWhere(Func<T, bool> condition)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (condition(items[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public bool Any(Func<T, bool> condition)
        {
            for (int i = 0; i < size; i++)
            {
                if (condition(items[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool All(Func<T, bool> condition)
        {
            for (int i = 0; i < size; i++)
            {
                if (!condition(items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public T First(Func<T, bool> condition)
        {
            for (int i = 0; i < size; i++)
            {
                if (condition(items[i]))
                {
                    return items[i];
                }
            }
            return default;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < size; i++)
            {
                action(items[i]);
            }
        }

        public T[] Where(Func<T, bool> condition)
        {
            T[] new_array = new T[size];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (condition(items[i]))
                {
                    new_array[index] = items[i];
                    index++;
                }
            }
            Array.Resize(ref new_array, index);
            return new_array;
        }

        public void Reverse()
        {
            Array.Reverse(items, 0, size);
        }

        public T Min()
        {
            T min = items[0];
            for (int i = 1; i < size; i++)
            {
                if (min.CompareTo(items[i]) > 0)
                {
                    min = items[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T min = items[0];
            for (int i = 1; i < size; i++)
            {
                if (min.CompareTo(items[i]) < 0)
                {
                    min = items[i];
                }
            }
            return min;
        }
    }
}