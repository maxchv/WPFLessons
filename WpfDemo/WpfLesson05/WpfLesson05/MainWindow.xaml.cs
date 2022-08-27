using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

namespace WpfLesson05
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
            //(DataContext as ViewModel).CarsListView = CarsListView;

        }

        private void SortByModel(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Sort by model");
            ICollectionView view =
                    CollectionViewSource.GetDefaultView(CarsListView.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription("Model", sortDirection));
            sortDirection = sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending :
                ListSortDirection.Ascending;
            view.Refresh();
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>
        {
            new Car { Id = 1, Model = "Mercedes XL", Price=100000},
            new Car { Id = 2, Model = "Tesla Model X", Price=150000,
                IsSold=true},
            new Car { Id = 3, Model = "BMW X6", Price=200000},
        };

        private string filtredText;

        public ViewModel()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Cars);
            view.Filter = CarFilter;
        }

        class SortCommand : ICommand
        {
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;

            public void Execute(object? parameter)
            {
                throw new NotImplementedException();
            }
        }

        private SortCommand sortCommand = new SortCommand();

        public ICommand SortCmd => sortCommand;

        //private ListView carsListView;

        //public ListView CarsListView
        //{
        //    get { return carsListView; }
        //    set
        //    {
        //        carsListView = value;
        //        ICollectionView view = new CollectionView(Cars);
        //            //CollectionViewSource.GetDefaultView(carsListView.ItemsSource);
        //        view.Filter = CarFilter;
        //    }
        //}

        private bool CarFilter(object obj)
        {
            if (string.IsNullOrEmpty(FiltredText))
            {
                return true;
            }
            if (obj is Car car)
            {
                return car.Model.Contains(FiltredText, StringComparison.OrdinalIgnoreCase);
            }
            return true;
        }

        public string FiltredText
        {
            get { return filtredText; }
            set
            {
                filtredText = value;
                DoFilter();
            }
        }

        private void DoFilter()
        {
            Debug.WriteLine($"Filter by {FiltredText}");
            CollectionViewSource.GetDefaultView(Cars).Refresh();
           
        }

    }

    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
    }
}
