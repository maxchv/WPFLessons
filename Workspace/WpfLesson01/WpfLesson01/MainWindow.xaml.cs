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

namespace WpfLesson01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // императивный подход
            //Button btn = new Button();
            //btn.Content = "Жмакни";
            //btn.Click += Btn_Click;
            //Content = btn;
            //Btn.Content = "test";
            Grid grd = new Grid();
            Button btn = new Button();
            
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
