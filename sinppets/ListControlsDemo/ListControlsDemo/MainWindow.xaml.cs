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

namespace ListControlsDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<ToDoItem> todo = new List<ToDoItem>();

            todo.Add(new ToDoItem { Title="Complete this WPF tutorial", Completion=45 });
            todo.Add(new ToDoItem { Title = "Learn C#", Completion = 80 });
            todo.Add(new ToDoItem { Title = "Wash the car", Completion = 0 });

            icToDoList.ItemsSource = todo;

            List<User> users = new List<User>();
            users.Add(new User { Name="John Doe", Age=42, Mail="john@doe-fmily.com" });
            users.Add(new User { Name = "Jane Doe", Age = 39, Mail = "jane@doe-fmily.com" });
            lvDataBinding.ItemsSource = users;

            lvUsers.ItemsSource = users;
            // Filtering
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;

            dataGrid.ItemsSource = users;
        }

        private bool UserFilter(object obj)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (obj as User).Name.IndexOf(txtFilter.Text) >= 0;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            string sortBy = header.Tag.ToString();
            lvUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }
    }

    class ToDoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
    }
}
