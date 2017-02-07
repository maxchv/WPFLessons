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
using System.Windows.Shapes;

namespace WpfLesson02
{
    /// <summary>
    /// Interaction logic for WPFContols.xaml
    /// </summary>
    public partial class WPFContols : Window
    {
        public WPFContols()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            if (img != null)
            {
                img.Source = new BitmapImage(new Uri("https://rimdevblog.files.wordpress.com/2015/04/push-button.png"));
            }
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(LblValue != null)
            LblValue.Content = e.NewValue;
        }
    }
}
