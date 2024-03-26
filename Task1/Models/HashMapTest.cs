using System;

namespace Task1.Models
{
    public class HashMapTest
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

    }
}
