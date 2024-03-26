using System;
using System.Collections.Generic;

namespace Task1.Models
{
    public class HashMap<K, V>
    {
        private List<Pair<K, V>>[] pairs;
        private int size = 0;
        private int capacity = 10;

        public HashMap()
        {
            pairs = new List<Pair<K, V>>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                pairs[i] = new List<Pair<K, V>>();
            }
        }

        // Добавляем новый конструктор для инициализации с начальными значениями
        public HashMap(params Pair<K, V>[] initialPairs) : this()
        {
            foreach (var pair in initialPairs)
            {
                Put(pair.Key, pair.Value);
            }
        }

        public void Clear()
        {
            foreach (var item in pairs)
            {
                item.Clear();
            }
            size = 0;
        }

        public bool Contains(K key)
        {
            int hashCode = key.GetHashCode();
            foreach (var item in pairs[hashCode % capacity])
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public V Get(K key)
        {
            int hashCode = key.GetHashCode();
            foreach (var item in pairs[hashCode % capacity])
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            throw new KeyNotFoundException($"Key '{key}' not found.");
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public K[] Keys()
        {
            var keys = new List<K>();
            foreach (var list in pairs)
            {
                foreach (var pair in list)
                {
                    keys.Add(pair.Key);
                }
            }
            return keys.ToArray();
        }

        public void Put(K key, V value)
        {
            int hashCode = key.GetHashCode();
            foreach (var item in pairs[hashCode % capacity])
            {
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException($"Key '{key}' already exists.");
                }
            }
            pairs[hashCode % capacity].Add(new Pair<K, V>(key, value));
            size++;
        }

        public void Remove(K key)
        {
            int hashCode = key.GetHashCode();
            var list = pairs[hashCode % capacity];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Key.Equals(key))
                {
                    list.RemoveAt(i);
                    size--;
                    return;
                }
            }
            throw new KeyNotFoundException($"Key '{key}' not found.");
        }

        public int Size()
        {
            return size;
        }

        public V[] Values()
        {
            var values = new List<V>();
            foreach (var list in pairs)
            {
                foreach (var pair in list)
                {
                    values.Add(pair.Value);
                }
            }
            return values.ToArray();
        }

    }

    public class Pair<K, V>
    {

        public K Key { get; set; }
        public V Value { get; set; }

        public Pair() { }

        public Pair(K key, V value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

}
