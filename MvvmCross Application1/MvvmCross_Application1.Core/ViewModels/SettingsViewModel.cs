using System;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross.Core.Navigation;

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

       // public static SettingsViewModel Instance = new SettingsViewModel();
        public IRepository<Channels> channelRepo;
        private static ObservableCollection<Channels> channels = new ObservableCollection<Channels>();
        public ObservableCollection<Channels> Channels
        {
            get { return channels; }
            set { channels = value; RaisePropertyChanged(() => Channels); }
        }

        public SettingsViewModel(IMvxNavigationService navigationService)

        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

        }


        public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }
        private IMvxAsyncCommand _navigateCommand;
        private readonly IMvxNavigationService _navigationService;

        private MvxAsyncCommand removeCommand;
        public MvxAsyncCommand RemoveCommand
        {
            get
            {
                removeCommand =  new MvxAsyncCommand(() => Remove(null));
                return removeCommand;
            }
        }
      //  public MvxAsyncCommand RemoveCommand { get; }
        public async Task Remove(Channels entity)
        {


           var result = await channelRepo.Delete(entity);
            List<Channels> list = await channelRepo.Get();
            Channels = new ObservableCollection<Channels>(list);
            /* IsLiked = true;
             var d = PlayVideoViewModel.Instance.YoutubeItems;

             Db.platform.GetConnection();
             Db.platform.Insert(VideoId);*/



        }
        public async Task InitDataAsync()
        {
            var sqlconection = MainViewModel.connectionfactory.ProduceConnection();
       //!!    await sqlconection.DropTableAsync<Channels>();
           //await sqlconection.CreateTablesAsync<Favor12, Channels>();

            await sqlconection.CreateTablesAsync<Favor12, Channels>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);

           

            channelRepo = new Repository<Channels>(sqlconection);
          //!!  await channelRepo.Insert((new Channels() { PlayListId = "PLyxLqRfXH_eOMYvGsYRYkrjaoZ8DG3Sxu", Title = "Little Angel" }));
            List<Channels> list =await channelRepo.Get();
            Channels= new ObservableCollection<Channels>(list);

            /*var list = await stockRepo.Get();

            var list = Db.platform.Select();
            List<string> listid = new List<string>();
            foreach (var item in list)
            {
                listid.Add(item.VideoId);
            }

            var info = new InfoFromYoutube();
            var FavoritesVideos1 = await info.GetVideosDetailsAsync(listid);
           // FavoritesVideos = new ObservableCollection<YoutubeItem>(FavoritesVideos1);

*/

        }
        public async Task AddNewChannel()
        {

            await _navigationService.Navigate<NewChannelViewModel>();

        }
    }
}