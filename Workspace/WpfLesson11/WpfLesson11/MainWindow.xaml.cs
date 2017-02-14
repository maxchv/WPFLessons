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


namespace WpfLesson11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Node> nodes = new List<Node>();
            var root = new Node { Title = "Root" };

            var subnode = new Node { Title = "First subnode" };
            root.Nodes.Add(subnode);

            var subsubnode = new Node { Title = "Second subnode" };
            subnode.Nodes.Add(subsubnode);

            nodes.Add(root);

            SimpletTreeView.ItemsSource = nodes;

            List<TreeViewItem> list = new List<TreeViewItem>();

            list.Add(CreateNode("first"));            
            list.Add(CreateNode("second"));            
            list.Add(CreateNode("third"));

            trvExample.ItemsSource = list;
        }

        private TreeViewItem CreateNode(string name)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = name;
            item.Tag = name; // поместить связанные данные
            item.Items.Add(new TreeViewItem { Header="Load..." });
            return item;
        }

        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem expandedItem = e.Source as TreeViewItem;
            if(expandedItem != null)
            {
                expandedItem.Items.Clear();
                expandedItem.Items.Add(CreateNode("subnode #1"));
                expandedItem.Items.Add(CreateNode("subnode #2"));
                expandedItem.Items.Add(CreateNode("subnode #3"));
                expandedItem.Items.Add(CreateNode("subnode #4"));
            }
        }
    }
    public class Node
    {
        public string Title { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }

        public Node()
        {
            Nodes = new ObservableCollection<Node>();
        }
    }

    public class Group
    {
        public Brush Color { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public Group()
        {
            Students = new ObservableCollection<Student>();
        }

        public static List<Group> CreateGroups()
        {
            List<Group> groups = new List<Group>();

            Group programmers = new Group { Name = "ЕКО-П-3", Color = Brushes.White };
            programmers.Students.Add(new Student { Name = "Вася", Age = 19 });
            programmers.Students.Add(new Student { Name = "Петя", Age = 20 });
            programmers.Students.Add(new Student { Name = "Рита", Age = 21 });
            Group designers = new Group { Name = "ЕКО-Г-2", Color = Brushes.LightBlue };
            designers.Students.Add(new Student { Name = "Соня", Age = 19 });
            designers.Students.Add(new Student { Name = "Дуня", Age = 18 });
            designers.Students.Add(new Student { Name = "Роза", Age = 27 });
            designers.Students.Add(new Student { Name = "Ева", Age = 18 });
            Group admins = new Group { Name = "ЕКО-А-5", Color = Brushes.Brown };
            admins.Students.Add(new Student { Name = "Жора", Age = 23 });

            groups.Add(programmers);
            groups.Add(designers);
            groups.Add(admins);

            return groups;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

