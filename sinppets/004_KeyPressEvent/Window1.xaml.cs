using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _005_KeyPressEvent
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        /*
            События в порядке их возникновения:
            1. PreviewKeyDown – нажатие клавиши.
            2. KeyDown – нажатие клавиши.
            3. PreviewTextInput – нажатие завершено и элемент получил текстовый ввод. (не работает для тех клавиш, которые не отображаются)
            4. TextChanged – смена текста в элементе управления.
            5. PreviewKeyUp – отпускание клавиши.
            6. KeyUp - отпускание клавиши.
            Все события Preview нужны для того, что бы отловить события, которые были перехвачены стандартной реализацией элемента управления. 
            Например, TextBox блокирует клавиши управление курсором, так как обрабатывает их самостоятельно.
         */

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            string message = 
                "Event: " + e.RoutedEvent + " " +
                " Key: " + e.Key;
            lstMessages.Items.Add(message);
        }

        private void TextInputHandler(object sender, TextCompositionEventArgs e)
        {
            string message = 
                "Event: " + e.RoutedEvent + " " +
                " Text: " + e.Text;
            lstMessages.Items.Add(message);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            string message =
                "Event: " + e.RoutedEvent;
            lstMessages.Items.Add(message);
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
        }
    }
}