using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public string SomeText { get; set; } = "The title for this window";

        public ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            Resources["items"] = new[] { "one", "two", "three" };
            Resources["text"] = "some text";
            InitializeComponent();
            DataContext = this;
            Students = new ObservableCollection<Student>
            {
               new Student{FirstName="Вася", LastName="Пупкин"},
               new Student{FirstName="Маша", LastName="Девяткина"},
               new Student{FirstName="Рома", LastName="Иванов"},
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Students.Add(new Student { FirstName = "Владимир", LastName = "Заленский" });
            (sender as Button).Content = $"Added {Students.Count} students";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach(Student s in Students)
            {
                s.LastName = "Зеленский";
            }
        }
    }

    public class Student: INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { 
                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
