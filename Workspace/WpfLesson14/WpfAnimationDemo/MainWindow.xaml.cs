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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnimationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ColorAnimation a = new ColorAnimation();
            a.To = Colors.Yellow;
            a.Duration = new Duration(TimeSpan.Parse("0:0:3"));
            tb.Background.BeginAnimation(SolidColorBrush.ColorProperty, a);
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation a = new DoubleAnimation();
            //a.From = 150;
            //a.To = 150;
            a.By = 100;
            a.AutoReverse = true;
            a.SpeedRatio = 10;
            a.RepeatBehavior = new RepeatBehavior(TimeSpan.Parse("0:0:1"));
            a.BeginTime = TimeSpan.Parse("0:0:1");
            // 1 с - Duration.Automatic;
            a.Duration = new Duration(TimeSpan.Parse("0:0:5"));
            //a.FillBehavior = FillBehavior.Stop;
            a.Completed += A_Completed;
            a.AccelerationRatio = 0.5;
            a.DecelerationRatio = 0.5;
            b.BeginAnimation(Button.WidthProperty, a);
            //BeginAnimation(Window.HeightProperty, a);
        }

        private void A_Completed(object sender, EventArgs e)
        {
            Title = "Completed";
        }
    }
}
