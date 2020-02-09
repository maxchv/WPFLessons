using _02.TreeViewDemo.Model;
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

namespace _02.TreeViewDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CategoriesTreeView.ItemsSource = new ObservableCollection<Category>
            {
                new Category
                {
                    Name = "First Category",
                    Categories = new ObservableCollection<Category>()
                    {
                        new Category
                        {
                            Name = "Subcategory 1",
                            Categories = new ObservableCollection<Category>
                            {
                                new Category{Name = "SubSubcategory 1"}
                            }
                        },
                        new Category { Name = "Subcategory 2" },
                        new Category { Name = "Subcategory 3" }
                    }
                },
                new Category
                {
                    Name = "Second Category",
                    Categories = new ObservableCollection<Category>()
                    {
                        new Category { Name = "Subcategory 1" },
                        new Category { Name = "Subcategory 2" },
                        new Category { Name = "Subcategory 3" }
                    }
                }
            };

            foreach (DriveInfo driver in DriveInfo.GetDrives())
            {
                var d = new TreeViewItem
                {
                    Header = driver,
                    Tag = driver.Name
                };
                d.Items.Add("Loading...");
                Explorer.Items.Add(d);
            }

        }

        private void Explorer_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            if (item != null)
            {
                if (item.Tag != null)
                {
                    string fullPath = item.Tag as string;

                    if (fullPath != null)
                    {
                        if (item.Items.Count == 1 && item.Items[0] is string)
                        {
                            item.Items.Clear();
                        }
                        foreach (var entity in new DirectoryInfo(fullPath).EnumerateFileSystemInfos())
                        {
                            var data = new TreeViewItem
                            {
                                Header = entity.Name,
                                Tag = entity.FullName
                            };
                            if (Directory.Exists(entity.FullName))
                            {
                                data.Items.Add("Loading...");
                            }
                            item.Items.Add(data);
                        }
                    }
                }
            }
        }
    }
}
