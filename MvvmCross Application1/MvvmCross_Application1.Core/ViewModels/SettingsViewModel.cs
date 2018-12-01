using System;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {

        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }

        public static SettingsViewModel Instance = new SettingsViewModel();
        private static ObservableCollection<Channel> channels = new ObservableCollection<Channel>();
        public ObservableCollection<Channel> Channels
        {
            get { return channels; }
            set { channels = value; RaisePropertyChanged(() => Channels); }
        }

        public SettingsViewModel()
        {
            Db.platform.GetConnection();
        }


        public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }


        public async Task InitDataAsync()
        {

            var list = Db.platform.Select();
            List<string> listid = new List<string>();
            foreach (var item in list)
            {
                listid.Add(item.VideoId);
            }

            var info = new InfoFromYoutube();
            var FavoritesVideos1 = await info.GetVideosDetailsAsync(listid);
           // FavoritesVideos = new ObservableCollection<YoutubeItem>(FavoritesVideos1);

        }
    }
}