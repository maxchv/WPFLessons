using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Array values = Enum.GetValues(typeof(Gender));
        }
    }

    //public class GenderEnumSource
    //{
    //    public Gender[] GetValues() =>
    //        Enum.GetValues<Gender>();
    //}

    public class ViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; }

        public ViewModel()
        {
            Students = new ObservableCollection<Student>();
        }

        private ICommand loadCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new DelegateCommand(
                        LoadData,
                        parameter => true
                     );
                }
                return loadCommand;
            }
        }

        private void LoadData(object? obj)
        {
            Students.Add(new Student
            {
                Id = 1,
                FirstName = "Вася",
                LastName = "Пупкин",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = Gender.Male
            });
            Students.Add(new Student
            {
                Id = 2,
                FirstName = "Рома",
                LastName = "Пяточкин",
                BirthDate = new DateTime(1990, 3, 1),
                Gender = Gender.Male
            });
            Students.Add(new Student
            {
                Id = 3,
                FirstName = "Маша",
                LastName = "Растеряша",
                BirthDate = new DateTime(1997, 6, 7),
                Gender = Gender.Female,
                HasScolarship = true
            });
        }
    }

    class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object?> action;
        private Func<object?, bool> predicate;

        public DelegateCommand(Action<object?> action,
                               Func<object?, bool> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public bool CanExecute(object? parameter)
        {
            if (predicate == null)
            {
                throw new NotImplementedException();
            }
            return predicate(parameter);
        }

        public void Execute(object? parameter)
        {
            if (action == null)
            {
                throw new NotImplementedException();
            }
            action(parameter);
        }
    }

    public enum Gender // Model
    {
        Male, Female, Unknown
    }

    public class Student // Model
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool HasScolarship { get; set; }
    }
}
