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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Grid grd = new Grid();
            grd.ShowGridLines = true;
            Content = grd;

            Button btn1 = new Button();
            btn1.Content = "Open Window";
            btn1.Width = 150;
            btn1.Height = 70;
            btn1.Click += Btn1_Click;

            Button btn2 = new Button();
            btn2.Content = "Button2";
            btn2.Width = 150;
            btn2.Height = 70;

            grd.Children.Add(btn1);
            grd.Children.Add(btn2);

            grd.RowDefinitions.Add(new RowDefinition());
            grd.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(btn1, 0);
            Grid.SetRow(btn2, 1);

            btn2.Click += Btn2_Click;

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            new WPFContols().ShowDialog();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            new UserObject().ShowDialog();
        }
    }
}
