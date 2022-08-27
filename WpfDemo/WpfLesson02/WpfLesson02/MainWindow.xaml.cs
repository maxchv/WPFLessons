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

namespace WpfLesson02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Button button = new Button();
            //button.Content = "Push me";
            //button.Width = 75;
            //button.Height = 50;
            //Grid1.Children.Add(button);
        }
    }

    public class Person: UIElement
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}
