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

namespace RoutedEvents
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Button Name: {(sender as Button).Name}");
            builder.AppendLine($"OriginalSource: {e.OriginalSource}");
            builder.AppendLine($"Source: {e.Source}");
            builder.AppendLine($"Handled: {e.Handled}");
            MessageBox.Show(builder.ToString());
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Button Name: {sender.ToString()}");
            builder.AppendLine($"OriginalSource: {e.OriginalSource}");
            builder.AppendLine($"Source: {e.Source}");
            builder.AppendLine($"Handled: {e.Handled}");
            MessageBox.Show(builder.ToString());
        }
    }

    class ExtraButton: Button
    {
        #region ExtraClick Routed Event

        public static readonly RoutedEvent ExtraClickEvent = EventManager.RegisterRoutedEvent(
            "ExtraClick",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(ExtraButton));

        public event RoutedEventHandler ExtraClick
        {
            add { AddHandler(ExtraClickEvent, value); }
            remove { RemoveHandler(ExtraClickEvent, value); }
        }

        /// <summary>
        /// Invoke this method when you wish to raise a(n) ExtraClick event
        /// </summary>
        protected override void OnClick()
        {
            base.OnClick();
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ExtraButton.ExtraClickEvent);
            RaiseEvent(newEventArgs);
        }

        #endregion
    }
}
