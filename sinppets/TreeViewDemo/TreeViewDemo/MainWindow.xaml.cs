using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace TreeViewDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Container root = new Container { Title="First" };
            root.Items.Add(new Container { Title = "Second" });
            root.Items.Add(new Container { Title = "Third" });
            root.Items.Add(new Container { Title = "Fourth" });
            trvContainer.Items.Add(root);

            List<Family> families = new List<Family>();
            Family family = new Family { Name = "Админі" };
            families.Add(family);
            family.Members.Add(new FamilyMember { Name = "Маша", Age = 21 });

            trvFamily.ItemsSource = families;

            foreach (var driver in DriveInfo.GetDrives())
            {
                TreeViewItem tv = new TreeViewItem
                {
                    Header = driver,
                    Tag = driver                   
                };
                tv.Items.Add("Loading...");
                tvDrivers.Items.Add(tv);
            }
        }

        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if((item.Items.Count == 1) && (item.Items[0] is string))
            {
                item.Items.Clear();

            }
        }
    }

    public class Container
    {
        public string Title { get; set; }
        public ObservableCollection<Container> Items { get; set; } 
        
        public Container()
        {
            Items = new ObservableCollection<Container>();
        }       
    }

    class Family
    {
        public string Name { get; set; }
        public ObservableCollection<FamilyMember> Members { get; set; }
        public Family()
        {
            Members = new ObservableCollection<FamilyMember>();
        }
    }

    class FamilyMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
