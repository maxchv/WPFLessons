using Microsoft.Win32;
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
using System.Windows.Threading;

namespace WpfLesson16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string mediaFile;
        MediaPlayer mediaPlayer = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == true)
            {
                mediaFile = dlg.FileName;
                mediaPlayer.Open(new Uri(mediaFile));

                pb_time.Minimum = 0;
                

                DispatcherTimer dt = new DispatcherTimer();
                dt.Interval = TimeSpan.FromMilliseconds(1000);
                dt.Tick += Dt_Tick;
                dt.Start();
            }
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                pb_time.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                time_end.Text = pb_time.Maximum.ToString();
            }
            pb_time.Value = mediaPlayer.Position.TotalSeconds;
            time_curr.Text = pb_time.Value.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }
    }
}
