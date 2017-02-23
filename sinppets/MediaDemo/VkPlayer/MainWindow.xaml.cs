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
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace VkPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ulong appID = 5888917;                    // ID приложения
            string email = "+380634758439";         // email или телефон
            string pass = "ItstepTeacher#2000";               // пароль для авторизации
            Settings scope = Settings.Friends;      // Приложение имеет доступ к друзьям

            var vk = new VkApi();
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = appID,
                Login = email,
                Password = pass,
                Settings = Settings.All
            });

            long count;
            AudioSearchParams search = new AudioSearchParams();
            search.Autocomplete = true;
            search.Query = "Linkin Park";
            search.SearchOwn = true;
            //vk.Messages.Send(new MessagesSendParams() { Message="test" });
            var audios = vk.Audio.Search(search);
            if(audios.Count > 0 )
            {
                MediaPlayer mp = new MediaPlayer();
                mp.Open(audios[0].Uri);
                mp.Play();

            }
            
        }
    }
}
