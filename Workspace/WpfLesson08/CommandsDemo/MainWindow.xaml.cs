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

namespace CommandsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string password = "qwerty";
        bool isAllow = false;
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            binding.Executed += Binding_Executed;
            binding.CanExecute += Binding_CanExecute;
            this.CommandBindings.Add(binding);
        }

        private void Binding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isAllow;
        }

        private void Binding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New document");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New document");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cut?");
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            isAllow = tb.Text == password;
        }
    }

    class UserCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(UserCommands),
                new InputGestureCollection() {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
            );
    }
}
