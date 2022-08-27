using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLesson06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var dlg = new OpenFileDialog();
        //    if (dlg.ShowDialog() == true)
        //    {
        //        TextBox1.Text = File.ReadAllText(dlg.FileName);
        //    }
        //}

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    var dlg = new OpenFileDialog();
        //    if(dlg.ShowDialog() == true)
        //    {
        //        TextBox1.Text = File.ReadAllText(dlg.FileName);
        //    }
        //}
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Visibility visibilityState = Visibility.Hidden;

        public Visibility VisibilityState
        {
            get
            {
                return visibilityState;
            }
            set
            {
                visibilityState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VisibilityState"));
                openFileCommand?.ChangedExecuted();
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                if (password == "qwerty")
                {
                    VisibilityState = Visibility.Visible;
                }

            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { 
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }

        private CustomCommand openFileCommand;

        public ICommand OpenFile
        {
            get
            {
                if (openFileCommand == null)
                {
                    openFileCommand = new CustomCommand(OpenFileAndSetTextBox, 
                        CanOpenFile);                

                }
                return openFileCommand;
            }
        }

        public ICommand Exit
        {
            get
            {
                return new CustomCommand(
                    param => Application.Current.MainWindow.Close(), param => true);
            }
        }

        private void OpenFileAndSetTextBox(object? param)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                Text = File.ReadAllText(dlg.FileName);
            }
        }

        private bool CanOpenFile(object? param) => IsUnlocked;

        public bool IsUnlocked => VisibilityState == Visibility.Visible;

    }

    public class CustomCommand : ICommand
    {
        Action<object?> execute;
        Func<object?, bool> canExecute;
        public CustomCommand(Action<object?> execute, Func<object?, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;            
        }

        public void ChangedExecuted()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? param) => (bool)(canExecute?.Invoke(param));

        public void Execute(object? parameter) => execute?.Invoke(parameter);

    }

}
