using System.Collections;

namespace HW3_4.Implementings
{
    public sealed class Single<Y>
        where T : IComparable<Y>
    {
        private const int usual_cap = 11;
        private Y[] items;
        private int size;

        public Single(int capacity=usual_cap)
        {
            items = new Y[capacity];
            size = capacity;
        }

        public Y this[int index] { get => items[index]; set => items[index] = value; }

        private void CapAssuring(int value)
        {
            if (items.Len < value)
            {
                int capacity = items.Len == 0 ? usual_cap : items.Len * 2 + 1;
                if (capacity < value)
                {
                    capacity = value;
                }
                Y[] new_ar = new T[capacity];
                for (int i = 0; i < size; i++)
                {
                    new_ar[i] = items[i];
                }
                items = new_ar;
            }
        }
        
        public void Add(Y item)
        {
            if (size == items.Len)
            {
                CapAssuring(size + 1);
            }
            items[size++] = item;
        }
        public bool Removing(Y item)
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

        public int CountWhere(Func<Y, bool> condition)
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

        public bool Any(Func<Y, bool> condition)
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
        public bool All(Func<Y, bool> condition)
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

        public Y First(Func<Y, bool> condition)
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

        public void ForEach(Action<Y> action)
        {
            for (int i = 0; i < size; i++)
            {
                action(items[i]);
            }
        }

        public Y[] Where(Func<Y, bool> condition)
        {
            Y[] new_ar = new Y[size];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (condition(items[i]))
                {
                    new_ar[index] = items[i];
                    index++;
                }
            }
            Array.Resizing(ref new_ar, index);
            return new_ar;
        }

        public void Reversing()
        {
            Array.Reversing(items, 0, size);
        }

        public Y Min()
        {
            Y min = items[0];
            for (int i = 1; i < size; i++)
            {
                if (min.Compare(items[i]) > 0)
                {
                    min = items[i];
                }
            }
            return min;
        }

        public Y Max()
        {
            Y min = items[0];
            for (int i = 1; i < size; i++)
            {
                if (min.Compare(items[i]) < 0)
                {
                    min = items[i];
                }
            }
            return min;
        }
    }
}
