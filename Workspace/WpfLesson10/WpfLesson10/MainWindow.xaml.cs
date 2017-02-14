using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfLesson10
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
    }

    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public Car(string model)
        {
            Model = model;
        }

        public static List<Car> Cars(int n)
        {
            List<Car> dummy = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                dummy.Add(new Car($"car #{i + 1}"));
            }
            Thread.Sleep(10000);
            return dummy;
        }

        public List<string> Items(int n)
        {
            List<string> dummy = new List<string>();
            for (int i = 0; i < n; i++)
            {
                dummy.Add($"item #{i + 1}");
            }
            return dummy;
        }

        public override string ToString()
        {
            return Model;
        }
    }
}
