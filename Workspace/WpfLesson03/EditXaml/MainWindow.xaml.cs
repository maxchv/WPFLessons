using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xaml;

namespace EditXaml
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string xaml = @"<Window 
        xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
        xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
        xmlns:d='http://schemas.microsoft.com/expression/blend/2008'
        xmlns:mc='http://schemas.openxmlformats.org/markup-compatibility/2006'
        xmlns:local='clr-namespace:EditXaml'
        mc:Ignorable='d'
        Title='MainWindow' Height='350' Width='525'>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition Height = 'Auto' ></ RowDefinition >
        </ Grid.RowDefinitions >
        < TextBox
            Margin='5'
            AcceptsReturn='True'
            AcceptsTab='True'
            />
        <StackPanel Margin = '5' HorizontalAlignment='Right' Grid.Row='1' Orientation='Horizontal'>
            <Button>Open</Button>
        </StackPanel>
    </Grid>
</Window>";

        public MainWindow()
        {
            InitializeComponent();
            sourceXaml.Text = xaml;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Window wnd = null;
            File.WriteAllText("window.xaml", sourceXaml.Text);
            try
            {
                using (var stream = new FileStream("window.xaml", FileMode.Open, FileAccess.Read))
                {
                    wnd = System.Windows.Markup.XamlReader.Load(stream) as Window;
                }

                wnd?.ShowDialog();
                wnd?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
