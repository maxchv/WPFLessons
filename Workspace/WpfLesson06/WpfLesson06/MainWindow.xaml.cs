using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace WpfLesson06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Car> cars = new ObservableCollection<Car>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            cars.Add(new Car { Id = 1, Model = "Ferrari", Price = 100000m });
            cars.Add(new Car { Id = 2, Model = "Lada", Price = 1000m });
            cars.Add(new Car { Id = 3, Model = "Maserati", Price = 150000m });
            cars.Add(new Car { Id = 4, Model = "Lamborghini", Price = 200000m });

            lbCars.ItemsSource = cars;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"User has name: {user.UName}");
        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txtResult.Text = txt.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            cars.Add(new Car { Id=cars.Max(c => c.Id) + 1, Model="Subaru", Price=10021m });
        }

        private void btnUpdateCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = lbCars.SelectedItem as Car;
            if (car != null)
            {
                car.Model = "New model";
            }
        }

        private void btnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = lbCars.SelectedItem as Car;
            if (car != null)
            {
                cars.Remove(car);
            }
        }
    }

    public class Car: INotifyPropertyChanged
    {
        private string model;

        public int Id { get; set; }
        public string Model {
            get
            {
                return model;
            }
            set
            {
                if(value != model)
                {
                    model = value;
                    NotifyPropertyChanged("Model");
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public decimal Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class User: FrameworkElement
    {
        public int Age { get; set; }

        // фасад
        public string UName
        {
            get { return (string)GetValue(UNameProperty); }
            set { SetValue(UNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UNameProperty =
            DependencyProperty.Register("UName", typeof(string), typeof(User));        
    }

    class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value.ToString().ToLower())
            {
                case "yes":
                case "true":
                case "да":
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                if((bool)value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
