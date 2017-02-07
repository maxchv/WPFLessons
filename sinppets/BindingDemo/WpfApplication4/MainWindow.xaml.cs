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

namespace WpfApplication4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> users = new ObservableCollection<User>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            users.Add(new User { Name = "Jhon Doe" });
            users.Add(new User { Name = "Jane Doe" });
            lbUsers.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User { Name = "New user" });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                (lbUsers.SelectedItem as User).Name = "Random Name";
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                users.Remove(lbUsers.SelectedItem as User);
            }
        }
    }

    class User: INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set {
                if (this.name != value)
                {
                    name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private string group;

        public string Group
        {
            get { return group; }
            set {
                if (this.group != value)
                {
                    group = value;
                    NotifyPropertyChanged("Group");
                }
            }
        }


        private void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class Car: DependencyObject
    {
        public string Model
        {
            get { return (string)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(string), typeof(Car));
    }
    
    class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value.ToString().ToLower())
            {
                case "true":
                case "yes":
                case "да":
                    return true;
                default:
                    return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                if((bool)value)
                {
                    return "yes";
                }                
            }
            return "no";
        }
    }
}
