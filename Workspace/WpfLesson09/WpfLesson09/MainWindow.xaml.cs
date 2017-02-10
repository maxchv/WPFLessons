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

namespace WpfLesson09
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

        private void ExtraButton_ExtraClick(object sender, RoutedEventArgs e)
        {
            string msg = $@"Name: {(sender as ExtraButton).Name}
                            Source: {e.Source}
                            Original Source: {e.OriginalSource}
                            Handled: {e.Handled}";
            e.Handled = true;// событие не распространять по дереву
            MessageBox.Show(msg);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            lbKeyEvents.Items.Add("Key: " + e.Key);
            lbKeyEvents.Items.Add("EventName: " + e.RoutedEvent.Name);
            // e.KeyboardDevice.Modifiers == ModifierKeys.Alt
            var modifiers = e.KeyboardDevice.Modifiers;
            if ((modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
            {
                lbKeyEvents.Items.Add("Alt pressed");
            }
            if(e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control))
            {
                lbKeyEvents.Items.Add("Control pressed");
            }
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                lbKeyEvents.Items.Add("Shift pressed");
            }
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Windows))
            {
                lbKeyEvents.Items.Add("Windows pressed");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            lbKeyEvents.Items.Add("EventName: " + e.RoutedEvent.Name);
            //e.Handled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbKeyEvents.Items.Add("EventName: " + e.RoutedEvent.Name);
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked on " + (e.OriginalSource as Button).Name);
        }

        private void StackPanel_ExtraClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cought StackPanel");
        }
    }

    class ExtraButton: Button
    {
        #region ExtraClick Routed Event

        public static readonly RoutedEvent ExtraClickEvent = 
            EventManager.RegisterRoutedEvent(
            "ExtraClick",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(ExtraButton)
        );

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
            RoutedEventArgs newEventArgs = 
                new RoutedEventArgs(ExtraButton.ExtraClickEvent);
            RaiseEvent(newEventArgs);
        }

        #endregion
    }
}
