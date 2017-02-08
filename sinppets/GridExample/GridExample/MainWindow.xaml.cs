using System;
using System.Collections.Generic;
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

namespace GridExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<User> users = new List<User>();

            users.Add(new User { Id = 1, Name = "Вася", Sex=Sex.Male, Email = "vasja@mail.com", Birthday = new DateTime(1990, 1, 1) });
            users.Add(new User { Id = 1, Name = "Маша", Sex=Sex.Female, Email = "masha@mail.com", Birthday = new DateTime(1995, 1, 1) });

            dgUser.ItemsSource = users;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_CutCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textEdit != null && (textEdit.SelectionLength > 0);
        }

        private void CommandBinding_CutExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textEdit.Cut();
        }

        private void CommandBinding_PasteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void CommandBinding_PasteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textEdit.Paste();
        }
    }

    public enum Sex
    {
        Male, Female
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }
    }

    class CustomCommands
    {
        public static readonly RoutedUICommand Exit = 
            new RoutedUICommand("Exit", 
                "Exit", 
                typeof(CustomCommands), 
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
            );
    }
}
