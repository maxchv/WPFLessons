using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEventsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Brush backgroudColod;
        public Brush BackgroundColor {
            get => backgroudColod;
            set
            {
                backgroudColod = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackgroundColor"));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            BackgroundColor = Brushes.White;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is ButtonBase button)
            {
                string color = button.Content.ToString();
                Type brushesType = typeof(Brushes);
                BackgroundColor = brushesType.GetProperty(color, BindingFlags.Static | BindingFlags.Public).GetValue(null) as Brush;
            }
        }
    }
}
