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

namespace _03.RoutedEventsDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mouse down: " + sender);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = false; // событие не будет распространяться по дереву
            MessageBox.Show("Clicked by: " + (sender as FrameworkElement)?.Name + "\n" +
                "Source: " + (e.Source as FrameworkElement)?.Name + "\n" +
                "OriginalSource: " + (e.OriginalSource as FrameworkElement)?.Name + "\n" +
                "RoutedEvent: " + e.RoutedEvent.Name);           
        }

        private void Inner_ExtendClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Extend Click");
        }
    }

    public class ExtendButton: Button
    {
        // snippet propdp - добавляет свойство зависимости

        public string MyProperty
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(ExtendButton), new PropertyMetadata(""));
        
        // Создание собственного маршрутизируемого события
        
        public static readonly RoutedEvent ExtendClickEvent = EventManager.RegisterRoutedEvent(
       "ExtendClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ExtendButton));
        
        public event RoutedEventHandler ExtendClick
        {
            add { AddHandler(ExtendClickEvent, value); }
            remove { RemoveHandler(ExtendClickEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            RaiseEvent(new RoutedEventArgs(ExtendClickEvent)); // вызов (поднятие) события
        }

    }
}
