using _02.TreeViewDemo.Model;
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
                        new Category { Name = "Subcategory 1" },
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


        }
    }
}
