using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    class Presenter: ObservableObject
    {
        private TextConverter _textConverter
            = new TextConverter(s => s.ToUpper());
        
        private string _someText;

        public ICommand ConverterTextCommand
        {
            get { return new DelegateCommand(ConverterText); }
        }

        private void ConverterText()
        {
            if(!string.IsNullOrWhiteSpace(SomeText))
            {
                AddHistory(_textConverter.ConvertText(SomeText));
                SomeText = "";
            }
        }

        private ObservableCollection<string> _history
            = new ObservableCollection<string>();
        
        public IEnumerable<string> History
        {
            get { return _history; }
        }
            

        private void AddHistory(string item)
        {
            if(!_history.Contains(item))
            {
                _history.Add(item);
            }
        }

        public string SomeText
        {
            get { return _someText; }
            set {
                _someText = value;
                RaizePropertyChangedEvent("SomeText");
            }
        }


    }
}
