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

namespace WpfLesson04
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

        private void MyListBox_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListBox_Unselected(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"D:\shaptala\.net\WPF\Workspace\WpfLesson04\WpfLesson04\abonent.png"));
            img.Width = 70;
            stackPanel.Orientation = Orientation.Horizontal;
            TextSearch.SetText(stackPanel, "Новый абонент");
            stackPanel.Children.Add(img);
            StackPanel innerStackPanel = new StackPanel();
            innerStackPanel.Orientation = Orientation.Vertical;
            Label lblName = new Label { Content=name.Text };
            lblName.FontSize = 20;            
            Label lblPhone = new Label { Content = phone.Text };
            lblPhone.FontSize = 16;
            innerStackPanel.Children.Add(lblName);
            innerStackPanel.Children.Add(lblPhone);
            stackPanel.Children.Add(innerStackPanel);

            listbox.Items.Add(stackPanel);
            
        }
    }
}
