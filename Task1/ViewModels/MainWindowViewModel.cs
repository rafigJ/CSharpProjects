using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Task1.Models;
using Task1.ViewModels.Base;

namespace Task1.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        private string _Title = "Анализ";

        private List<string> _List = new List<string>() { "a", "b" };


        /// <summary> Заголовок окна </summary>
        public string Title { 
            get =>  _Title;    
            set => Set(ref _Title, value); 
        }

       
    }
}
