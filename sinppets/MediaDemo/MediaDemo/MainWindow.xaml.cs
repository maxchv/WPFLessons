using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace MediaDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MediaPlayer mp = new MediaPlayer();
            MediaElement me = new MediaElement();
            MediaTimeline mtl;
        }

        public string duration { get; private set; }

        private void MediaTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {

            pos.Text = player.Position.ToString(@"mm\:ss") + "/" + duration;
        }

        private void player_MediaOpened(object sender, RoutedEventArgs e)
        { 
            duration = player.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        }
    }
}
