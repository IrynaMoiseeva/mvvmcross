using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class FavouritesViewModel: MvxViewModel
    {
        public IFavorRepository localFavorsRepository;
        public YoutubeItem entity;
        public static FavouritesViewModel Instance = new FavouritesViewModel();
        private MvxAsyncCommand removeFromFavoritiesCommand;
        public MvxAsyncCommand RemoveFromFavoritiesCommand
        {
            get { 
            
            removeFromFavoritiesCommand = new MvxAsyncCommand(() => Remove(entity));
                return removeFromFavoritiesCommand;
            }

    }

        private ObservableCollection<YoutubeItem> favoritesVideos;//= new ObservableCollection<YoutubeItem>();
        public ObservableCollection<YoutubeItem> FavoritesVideos
        {
            get { return favoritesVideos; }
            set { favoritesVideos = value; RaisePropertyChanged(() => FavoritesVideos); }
        }

        public FavouritesViewModel()
        {

        }

        public FavouritesViewModel(IFavorRepository localFavorsRepository)
        {
            this.localFavorsRepository = localFavorsRepository;

        }


        public async Task Remove(YoutubeItem entity)
        {
            var list = await localFavorsRepository.ReadAll();
            var entitytoremove = list.Where(x => x.VideoId == entity.VideoId).FirstOrDefault();

            await localFavorsRepository.Delete (entitytoremove);
            var l = FavoritesVideos.Where(x => x.VideoId != entity.VideoId);
            FavoritesVideos = new ObservableCollection<YoutubeItem>(l);

            this.RaisePropertyChanged(() => this.FavoritesVideos);

        }

    public override async Task Initialize()
        {
            await base.Initialize();

            await InitDataAsync();
        }


        public async Task InitDataAsync()
        {
           // await localFavorsRepository.DropTable();
         //  await localFavorsRepository.CreateTable();
            FavoritesVideos = new ObservableCollection<YoutubeItem>();
            IEnumerable<FavoriteVideos> list = await localFavorsRepository.ReadAll();
           
              List<string> listid = new List<string>();
              foreach (var item in list)
              {
                  listid.Add(item.VideoId);
              }

              var info = new InfoFromYoutube();
              var favoritesVideos1 = await info.GetVideosDetailsAsync(listid);
              favoritesVideos =new ObservableCollection<YoutubeItem>(favoritesVideos1);
           this.RaisePropertyChanged(() => this.FavoritesVideos);

        }
    }
}
