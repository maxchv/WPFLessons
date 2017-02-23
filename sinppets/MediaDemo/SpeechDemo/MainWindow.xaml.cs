using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
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

namespace SpeechDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SpeechSynthesizer ss = new SpeechSynthesizer();
            foreach(InstalledVoice v in ss.GetInstalledVoices())
            {
                cb_voices.Items.Add(v.VoiceInfo.Name);
            }
            cb_voices.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.SelectVoice(cb_voices.SelectedItem.ToString());
            PromptBuilder pb = new PromptBuilder();
            
            pb.AppendTextWithHint(content.Text, SayAs.Text);
            pb.AppendBreak();
            PromptStyle style = new PromptStyle();
            style.Volume = PromptVolume.Loud;
            style.Emphasis = PromptEmphasis.Strong;
            pb.AppendText(content.Text);
            pb.StartStyle(style);
            pb.EndStyle();
            pb.AppendBreak();
            pb.AppendText("Сегодня ");
            
            pb.AppendTextWithHint(DateTime.Now.ToShortDateString(), SayAs.Date);
            pb.AppendTextWithHint(DateTime.Now.ToShortTimeString(), SayAs.Time);
            
            ss.SpeakAsync(pb);
        }

        private void recognize_Click(object sender, RoutedEventArgs e)
        {
            SpeechRecognizer r = new SpeechRecognizer();
            r.SpeechRecognized += R_SpeechRecognized;
      
        }

        private void R_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            content.Text = e.Result.Text;
        }
    }
}
