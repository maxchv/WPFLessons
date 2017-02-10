using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfLesson08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students.Add(new Student { Id = 1, Email="mail@mail.com", Gender=Gender.Male, Name = "Вася", BirthDay = new DateTime(2010, 10, 10) });
            students.Add(new Student { Id = 2, Email = "mail@mail.com", Gender = Gender.Female, Name = "Маша", BirthDay = new DateTime(2000, 1, 10) });
            students.Add(new Student { Id = 3, Email = "mail@mail.com", Gender = Gender.Female, Name = "Даша", BirthDay = new DateTime(1980, 10, 1) });
            students.Add(new Student { Id = 4, Email = "mail@mail.com", Gender = Gender.Male, Name = "Петя", BirthDay = new DateTime(1985, 11, 20) });
            dgStudents.ItemsSource = students;            
        }
    }

    enum Gender
    {
        Male, Female
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMarried { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
