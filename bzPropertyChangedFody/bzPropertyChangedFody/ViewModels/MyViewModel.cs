using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace bzPropertyChangedFody.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string Result { get; set; }
        public void OnTitleChanged()
        {
            Result = $"Your answor is {Title}";
        }
    }
}
