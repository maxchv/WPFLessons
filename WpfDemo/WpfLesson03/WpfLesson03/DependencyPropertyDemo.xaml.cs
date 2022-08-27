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

namespace WpfLesson03
{
    /// <summary>
    /// Interaction logic for DependencyPropertyDemo.xaml
    /// </summary>
    public partial class DependencyPropertyDemo : Window
    {
        public Student Student { get; set; }
        public Student2 Student2 { get; set; }

        public DependencyPropertyDemo()
        {
            InitializeComponent();
            Student = new Student { FirstName = "Вася", LastName = "Иванов" };
            StudentPanel1.DataContext = Student;
            Student2 = new Student2();
            StudentPanel2.DataContext = Student2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student2.FirstName = FirstNameTextBox.Text;
            Student2.LastName = LastNameTextBox.Text;
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Student2: DependencyObject
    {


        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName", typeof(string), typeof(Student2), new PropertyMetadata(""));



        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register("LastName", typeof(string), typeof(Student2), new PropertyMetadata(""));



    }
}
