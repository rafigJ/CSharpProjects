# CSharpProjects
ForUniversity

## Task 1
В каждой задаче необходимо создать класс, членами которого являются указанные поля и методы. Интерфейс к задаче желательно выполнить на форме (WPF) с использованием компонентов. Нужно придерживаться модели MVVM. Можно реализовать консольное приложение, но оценка за это будет снижена.

На что следует обратить внимание (за невыполнение оценка будет снижена): 

1. Обязательно классы реализуются в отдельном модуле. 
2. Программа оформляется в соответствии с требованиями к разработке ПО (отступы, названия переменных и т.п.). 
3. В конструкторе класса могут и должны быть настроены значения полей и свойств класса, но инициализация значений должна быть вне класса. Например, не следует в конструкторе класса задавать в списке какие-то значения, или какое-то имя студента, если они не передаются в конструктор через параметр.
Варианты задач 1-5 рекомендуется сделать как обобщённые типы.


**Класс «Словарь» (Dictionary).**
- Свойства: количество элементов, есть ли элементы (IsEmpty), массив ключей, массив значений, массив пары ключ-значение (создать для этого соответствующую структуру), индексатор, возвращающий элемент по ключу.
- Методы: добавить пару ключ и значение, удалить элемент по ключу, проверить, есть ли элемент с заданным ключом в словаре (возвращает true, если элемент с таким ключом есть, иначе - false ), очистить словарь. Способ хранения данных в словаре не важен, можно использовать массив или список (List), ключ должен быть уникальным, значения могут повторяться.



## Task 2

Создать иерархию классов, состоящую из одного базового класса и двух классов-наследников. 

На что следует обратить внимание (за невыполнение оценка будет снижена): 

1. Должен быть хотя-бы один вирутальный или абстрактный метод или свойство и их перекрытие.
2. Программу желательно сделать с использованием форм (WPF).
3. Необходимо придерживаться модели MVVM.

**Базовый класс:** элемент файловой системы (свойства название, свойство на папку, в которой он находится (если корневой, то значение null), свойство указывающее местоположение (вычисляемое), статические методы копирования и переноса объекта в другую папку, абстрактное свойство, определяющее тип элемента (сделать перечисление: папка, файл), абстрактное свойство, возвращающее размер).
Производные классы: папка, файл. Папка должна содержать список элементов файловой системы. В производных классах реализовать свойство, определяющее их назначение (папка или файл), и размер (для папки он вычисляется по размеру элементов, которые она содержит, для файла задаётся при создании в конструкторе).


## Task 3
Используя решение задачи 2. Необходимо с помощью рефлексии реализовать возможность создания  и вызова методов данных классов на форме. В программе необходимо предусмотреть ввод пути к библиотеке классов, программа должна загрузить её, найти все классы, которые реализуют нужный интерфейс.  Получить всю информацию о данных классах, вывести список названий классов. При выборе класса на форму должны динамически подгружаться все методы класса с возможностью ввода параметров пользователем. При нажатии кнопки «Выполнить» должен создаваться объект и выполняться выбранный метод.

## Task 4
В зависимости от задачи необходимо смоделировать ситуацию/процесс. В каждой модели есть набор возможных ситуаций. Для некоторых событий необходимо определить вероятность возникновения данного события. Интерфейс необходимо реализовать, используя 3 и более классов.

Для решения задач необходимо использовать:

- Делегаты/события.
- Многопоточность
- Где необходимо рефлексию
- На форме должно быть динамическое изменение моделей – все должно двигаться. Иметь возможность добавлять несколько моделей на форму.


Добыча нефти – смоделировать добычу нефти. Реализовать классы – Нефтяная вышка, Механик, интерфейс – погрузчик. События - возгорание платформы(с некоторой долей вероятности), отправка нефти – приезжает погрузчик.
