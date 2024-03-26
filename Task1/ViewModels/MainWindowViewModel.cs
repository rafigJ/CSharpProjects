using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Task1.Models;

namespace Task1.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _title = "Анализ";
        private string _keyInput;
        private string _valueInput;
        private HashMap<string, string> _hashMap;

        public MainWindowViewModel()
        {
            HashMap = new HashMap<string, string>();
            AddCommand = new LambdaCommand(AddPair, CanAddPair);
            GetCommand = new LambdaCommand(GetValue, CanGetValue);
            RemoveCommand = new LambdaCommand(RemovePair, CanRemovePair);
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string KeyInput
        {
            get => _keyInput;
            set
            {
                if (_keyInput != value)
                {
                    _keyInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ValueInput
        {
            get => _valueInput;
            set
            {
                if (_valueInput != value)
                {
                    _valueInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public HashMap<string, string> HashMap
        {
            get => _hashMap;
            set
            {
                if (_hashMap != value)
                {
                    _hashMap = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; }
        public ICommand GetCommand { get; }
        public ICommand RemoveCommand { get; }

        private void AddPair(object parameter)
        {
            if (!string.IsNullOrEmpty(KeyInput) && !string.IsNullOrEmpty(ValueInput))
            {
                try
                {
                    HashMap.Put(KeyInput, ValueInput);
                    OnPropertyChanged(nameof(HashMap));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    // Здесь можно добавить логику обработки ошибок, если ключ уже существует
                }
            }
        }

        private bool CanAddPair(object parameter)
        {
            return !string.IsNullOrEmpty(KeyInput) && !string.IsNullOrEmpty(ValueInput);
        }

        private void GetValue(object parameter)
        {
            if (!string.IsNullOrEmpty(KeyInput))
            {
                try
                {
                    string value = HashMap.Get(KeyInput);
                    Console.WriteLine($"Value for key {KeyInput}: {value}");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    // Здесь можно добавить логику обработки ошибок, если ключ не найден
                }
            }
        }

        private bool CanGetValue(object parameter)
        {
            return !string.IsNullOrEmpty(KeyInput);
        }

        private void RemovePair(object parameter)
        {
            if (!string.IsNullOrEmpty(KeyInput))
            {
                try
                {
                    HashMap.Remove(KeyInput);
                    OnPropertyChanged(nameof(HashMap));
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    // Здесь можно добавить логику обработки ошибок, если ключ не найден
                }
            }
        }

        private bool CanRemovePair(object parameter)
        {
            return !string.IsNullOrEmpty(KeyInput);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
