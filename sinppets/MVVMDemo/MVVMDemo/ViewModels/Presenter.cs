using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    class Presenter: ObservableObject
    {
        private readonly TextConverter _textConverter = 
            new TextConverter(s => s.ToUpper());    
            
        private readonly ObservableCollection<string> _history =
            new ObservableCollection<string>();

        private string _someText;

        public string SomeText
        {
            get { return _someText; }
            set {
                _someText = value;
                RaisePropertyChangeEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConverterTextCommand
        {
            get { return new DelegateCommand(ConverterText); }
        }

        public void ConverterText()
        {
            if(!string.IsNullOrWhiteSpace(SomeText))
            {
                AddHistory(_textConverter.ConvertText(SomeText));
                SomeText = string.Empty;                    
            }
        }

        private void AddHistory(string item)
        {
            if(!_history.Contains(item))
            {
                _history.Add(item);
            }
        }
    }
}
