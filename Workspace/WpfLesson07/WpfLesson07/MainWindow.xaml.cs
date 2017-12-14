using System;
using System.Collections.Generic;
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

namespace WpfLesson07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListSortDirection sortDirection = ListSortDirection.Ascending;
        public MainWindow()
        {
            InitializeComponent();

            List<ToDoItem> todoList = new List<ToDoItem>();
            todoList.Add(new ToDoItem { Title = "Выучить C#", Completion = 80 });
            todoList.Add(new ToDoItem { Title = "Выучить WinForms", Completion = 75 });
            todoList.Add(new ToDoItem { Title = "Выучить WPF", Completion = 30 });
            todoList.Add(new ToDoItem { Title = "Выгулять собаку", Completion = 0 });
            icToDoList.ItemsSource = todoList;

            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Вася", Age = 21, Email = "vasilij@dot.com" });
            students.Add(new Student { Name = "Петя", Age = 25, Email = "petron@gmail.com" });
            students.Add(new Student { Name = "Маша", Age = 24, Email = "masha@mail.com" });
            students.Add(new Student { Name = "Даша", Age = 32, Email = "darina@yahoo.com" });
            lvStudents.ItemsSource = students;
            lvStudents.Items.Filter = NameFilter;
            //CollectionViewSource.GetDefaultView(lvStudents.ItemsSource).Filter = NameFilter;
        }

        private bool NameFilter(object obj)
        {
            return string.IsNullOrEmpty(filter.Text) 
                || (obj as Student).Name.StartsWith(filter.Text);            
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            string headerName = header.Content.ToString();
            //MessageBox.Show(headerName);
            lvStudents.Items.SortDescriptions.Clear();
            lvStudents.Items.SortDescriptions.Add(new SortDescription(headerName, sortDirection));
            sortDirection = (sortDirection == ListSortDirection.Ascending) ?
                                 ListSortDirection.Descending : ListSortDirection.Ascending;
            
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvStudents.ItemsSource).Refresh();
            //lvStudents.Items.Refresh();
        }
    }

    public class ToDoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
