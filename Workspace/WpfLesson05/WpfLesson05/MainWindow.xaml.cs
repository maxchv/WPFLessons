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

namespace WpfLesson05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // локальные ресурсы
            ListBoxResources.Items.Add(StackPanel1.FindResource("LabelContent"));
            // ресурсы окна
            ListBoxResources.Items.Add(this.FindResource("WindowTitle"));
            // ресурсы приложения (глобальные)
            ListBoxResources.Items.Add(Application.Current.FindResource("GeneralTitle"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double newMargin = double.Parse(TextBoxMargin.Text);
            Thickness margin = new Thickness(newMargin);
            StackPanel1.Resources["ButtonMargin"] = margin;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new OtherWindow().ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Document");
        }


    }

    
}
