using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TreeViewDemo.Model
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public Category()
        {
            
        }

        public ObservableCollection<Category> AllCateogories()
        {
            return Categories;
        }
    }
}
