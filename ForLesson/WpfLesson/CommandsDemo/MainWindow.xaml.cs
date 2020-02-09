using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandsDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                        
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Text files|*.txt|All Files|*.*"
            };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBox1.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }

    public static class UserCommands
    {
        public static readonly RoutedUICommand Exit =
            new RoutedUICommand("Exit", "Exit", typeof(UserCommands), new InputGestureCollection {
                new KeyGesture(Key.X, ModifierKeys.Control)
            });

    }

}
