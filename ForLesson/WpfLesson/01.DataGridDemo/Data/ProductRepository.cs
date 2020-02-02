using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DataGridDemo
{
    public class ProductRepository
    {
        static ObservableCollection<Product> products = new ObservableCollection<Product>
        {
            new Product{Id=1, Name="IPhone X", Price=23_000, Count=100},
            new Product{Id=2, Name="Samsung S10", Price=25_000, Count=10},
            new Product{Id=3, Name="Nokia 3310", Price=1_000, Count=1000},
        };

        public IEnumerable<Product> FindAll() => products;
    }
}
