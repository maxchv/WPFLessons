using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Providers
{
    public class ProductSource
    {
        static List<Product> prouducts = new List<Product>()
        {
            new Product{ Id=1, PhotoUrl="Img/01.jpg", Price=24999,
                         Name="Ноутбук Asus ROG Strix G531GT-BQ027 (90NR01L3-M02610) Black Суперціна!!!"},
            new Product{ Id=2, PhotoUrl="Img/02.jpg", Price=1899,
                         Name="Ноутбук HP Pavilion Gaming 15-cx0027ua (8KQ92EA) Суперціна!!!"},
            new Product{ Id=3, PhotoUrl="Img/03.jpg", Price=16499,
                         Name="Ноутбук HP Pavilion Gaming 15-bc504ur (7DT87EA) Black Суперціна!!!"},
            new Product{ Id=4, PhotoUrl="Img/04.jpg", Price=15499,
                         Name="Ноутбук Acer Aspire 5 A515-54G (NX.HFREU.038) Pure Silver Суперціна!!!"},
            new Product{ Id=5, PhotoUrl="Img/05.jpg", Price=5599,
                         Name="Ноутбук Lenovo IdeaPad 330-15AST (81D600M0RA) Onyx Black Суперцiна!!!"},
            new Product{ Id=6, PhotoUrl="Img/06.jpg", Price=22999,
                         Name="Ноутбук ASUS ZenBook 14 UX433FN-A5409 (90NB0JQ4-M11990) Icicle Silver"},

        };

        public List<Product> AllProducts(string name) => prouducts.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
    }
}
