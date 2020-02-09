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

namespace _05.Styles
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Resources["buttonColor"] = new SolidColorBrush(Colors.Purple);
            MessageBox.Show("Clicked by button " + (e.Source as Button).Content);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var color = Resources["buttonColor"] as SolidColorBrush;
            color.Color = Colors.Blue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Window1().ShowDialog();
        }

        private void StyleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.Clear();
            switch (StyleCombo.SelectedIndex)
            {
                case 0:
                    Application.Current.Resources.MergedDictionaries.Add(
                        new ResourceDictionary()
                        {
                            Source = new Uri("pack://application:,,,/StylesLib;component/light_style.xaml", UriKind.RelativeOrAbsolute)
                        });
                    break;
                case 1:
                    Application.Current.Resources.MergedDictionaries.Add(
                        new ResourceDictionary()
                        {
                            Source = new Uri("pack://application:,,,/StylesLib;component/dark_style.xaml", UriKind.RelativeOrAbsolute)
                        });
                    break;
                default:                
                    break;
            }
        }
    }
}
