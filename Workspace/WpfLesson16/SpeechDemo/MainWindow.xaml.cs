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
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace SpeechDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public MainWindow()
        {
            InitializeComponent();            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            ss.Speak(text.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PromptBuilder pb = new PromptBuilder();
            pb.AppendText("Сегодня ");
            //pb.AppendBreak();
            pb.AppendTextWithHint(DateTime.Now.ToShortDateString(), SayAs.Date);
            pb.AppendText("Текст с акцентом", PromptEmphasis.Strong);
            pb.AppendBreak();
            pb.AppendText("Текущее время ");
            //pb.AppendBreak();
            pb.AppendTextWithHint(DateTime.Now.ToShortTimeString(), SayAs.Time);
            
            ss.Speak(pb);
        }
    }
}
