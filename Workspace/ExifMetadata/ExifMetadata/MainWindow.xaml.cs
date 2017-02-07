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
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Microsoft.Win32;

namespace ExifMetadata
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

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Img.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                var directories = ImageMetadataReader.ReadMetadata(openFileDialog.FileName);
                
                foreach (var directory in directories)
                    foreach (var tag in directory.Tags)
                        Lbl.Content += $"{directory.Name} - {tag.Name} = {tag.Description}\n";
            }
        }
    }
}
