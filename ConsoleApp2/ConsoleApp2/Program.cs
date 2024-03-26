using System;
using System.Collections.Generic;

// Определение пространства имен
namespace ConsoleApp1
{
    // Определение класса HashMap
    public class HashMap<K, V>
    {
        private const double LoadFactor = 0.75;
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

        public HashMap(params Pair<K, V>[] initialPairs) : this()
        {
            foreach (var pair in initialPairs)
            {
                Put(pair.Key, pair.Value);
            }
        }

        public void Clear()
        {
            Array.Clear(pairs, 0, pairs.Length);
            size = 0;
        }

        public bool Contains(K key)
        {
            int index = GetIndex(key);
            foreach (var item in pairs[index])
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
            int index = GetIndex(key);
            foreach (var item in pairs[index])
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
            ResizeIfNeeded();

            int index = GetIndex(key);
            foreach (var item in pairs[index])
            {
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException($"Key '{key}' already exists.");
                }
            }
            pairs[index].Add(new Pair<K, V>(key, value));
            size++;
        }

        public void Remove(K key)
        {
            int index = GetIndex(key);
            var list = pairs[index];
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

        private int GetIndex(K key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode) % capacity;
        }

        private void ResizeIfNeeded()
        {
            if ((double)size / capacity >= LoadFactor)
            {
                int newCapacity = capacity * 2;
                List<Pair<K, V>>[] newPairs = new List<Pair<K, V>>[newCapacity];
                for (int i = 0; i < newCapacity; i++)
                {
                    newPairs[i] = new List<Pair<K, V>>();
                }

                foreach (var list in pairs)
                {
                    foreach (var pair in list)
                    {
                        int index = Math.Abs(pair.Key.GetHashCode()) % newCapacity;
                        newPairs[index].Add(pair);
                    }
                }

                capacity = newCapacity;
                pairs = newPairs;
            }
        }
    }

    // Определение класса Pair
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

    // Определение класса Program
    class Program
    {
        public static void RunTests()
        {
            // Создаем карту и добавляем некоторые элементы для тестирования
            var map = new HashMap<int, string>();
            map.Put(1, "One");
            map.Put(2, "Two");
            map.Put(3, "Three");

            // Проверяем методы карты
            Console.WriteLine("Size of map: " + map.Size());
            Console.WriteLine("Value for key 2: " + map.Get(2));
            Console.WriteLine("Contains key 3: " + map.Contains(3));
            Console.WriteLine("Contains key 4: " + map.Contains(4));

            // Удаляем элемент и проверяем его отсутствие
            map.Remove(1);
            Console.WriteLine("Size of map after removal: " + map.Size());
            Console.WriteLine("Contains key 1 after removal: " + map.Contains(1));

            // Выводим все ключи и значения
            Console.WriteLine("Keys in map:");
            foreach (var key in map.Keys())
            {
                Console.WriteLine(key);
            }
            Console.WriteLine("Values in map:");
            foreach (var value in map.Values())
            {
                Console.WriteLine(value);
            }
        }

        static void Main(string[] args)
        {
            // Выводим приветствие
            Console.WriteLine("Hello, World!");

            // Вызываем метод тестирования HashMap
            RunTests();

            // Добавляем эту строку, чтобы консоль не закрывалась сразу после завершения работы
            Console.ReadLine();
        }
    }
}