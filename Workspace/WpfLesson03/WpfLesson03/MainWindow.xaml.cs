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

namespace WpfLesson03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            checkBox.IsChecked = null;

            foreach (var child in stackPanel.Children)
            {
                outBox.Text += ((ContentControl) child).Content + "\n";
            }
        }

        private void ButtonBase_OnClickAccept(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Default action");
        }

        private void ButtonBase_OnClickEsc(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel action");
        }

        private void Selector_OnSelected(object sender, RoutedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            MessageBox.Show(cb.SelectedItem.ToString());
        }
    }
}
