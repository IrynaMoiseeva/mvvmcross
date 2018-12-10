using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.DataBase;
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
        public SQLite.SQLiteAsyncConnection sqlconection;
        public IRepository<Favor12> favorRepo;
        public static FavouritesViewModel Instance = new FavouritesViewModel();
        private static ObservableCollection<YoutubeItem> favoritesVideos = new ObservableCollection<YoutubeItem>();
        public ObservableCollection<YoutubeItem> FavoritesVideos
        {
            get { return favoritesVideos; }
            set { favoritesVideos = value; RaisePropertyChanged(() => FavoritesVideos); }
        }
     
        public FavouritesViewModel()
        {

            sqlconection = MainViewModel.connectionfactory.ProduceConnection();

        }

        public async Task Remove(YoutubeItem entity)
        {
            var v = 2;

            IRepository<Favor12> stockRepo = new Repository<Favor12>(sqlconection);
            var list = await stockRepo.Get();

            var entitytoremove = list.Where(x => x.VideoId==entity.VideoId);
            var d = entitytoremove.FirstOrDefault();
            var result = await stockRepo.Delete(d);

           var  l=FavoritesVideos.Where(x => x.VideoId != entity.VideoId);
            FavoritesVideos = new ObservableCollection<YoutubeItem>(l);

          
        }

    public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }


        public async Task InitDataAsync()
        {

            await sqlconection.CreateTablesAsync<Favor12, Channels>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);
            IRepository<Favor12> stockRepo = new Repository<Favor12>(sqlconection);
           
            var list = await stockRepo.Get();
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
