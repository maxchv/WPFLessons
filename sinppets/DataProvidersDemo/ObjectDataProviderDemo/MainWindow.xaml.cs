using System;
using System.Collections.Generic;
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

namespace ObjectDataProviderDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Photo
    {
        public string Url { get; set; }
        public Photo(string url="")
        {
            Url = url;
        }

        public List<string> GetItems(int max)
        {
            List<string> list = new List<string>();
            for(int i=0; i<max; i++)
            {
                list.Add($"itme {i + 1}");
            }
            return list;
        }
    }
}
