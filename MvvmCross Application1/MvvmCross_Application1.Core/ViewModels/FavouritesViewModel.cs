using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.ViewModels
{
  public  class FavouritesViewModel: MvxViewModel
    {
        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }
        public static FavouritesViewModel Instance = new FavouritesViewModel();
        private static ObservableCollection<YoutubeItem> favoritesVideos = new ObservableCollection<YoutubeItem>();
        public ObservableCollection<YoutubeItem> FavoritesVideos
        {
            get { return favoritesVideos; }
            set { favoritesVideos = value; RaisePropertyChanged(() => FavoritesVideos); }
        }
     /*  private List<YoutubeItem> favoritesVideos;
        public List<YoutubeItem> FavoritesVideos 
        {
            get { return favoritesVideos; }
            set
            {
                favoritesVideos = value;
                RaisePropertyChanged(() => FavoritesVideos);
            }
        }*/
        public FavouritesViewModel()
        {
           
          Db.platform.GetConnection();
        }

        public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }

        public virtual void Start()

        {
            var f = 1;

        }
        public virtual void Prepare()
        {
            var f = 1;
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
            FavoritesVideos =new ObservableCollection<YoutubeItem>(FavoritesVideos1);

                }
    }
}
