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
    /// Interaction logic for UserObject.xaml
    /// </summary>
    public partial class UserObject : Window
    {
        public UserObject()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Person {Person}");
        }
    }
}
