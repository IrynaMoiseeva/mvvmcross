using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MvvmCross_Application1.Core.Model.Video;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly Lazy<PlayVideoViewModel> playvideoViewModel;

        public static IPlatformService _platformService;
        public static IConnectionFactory connectionfactory;
        public SQLiteAsyncConnection sqlconection;
        public PlayVideoViewModel PlayVideoViewModel => playvideoViewModel.Value;

        /* private List<Channels> channels;
        public List<Channels> Channels //{ get; set; } */
        private ObservableCollection<Channels> channels;
        public ObservableCollection<Channels> Channels //{ get; set; }
        {
            get { return channels; }
            set
            {
                channels = value;
                RaisePropertyChanged(() => Channels);
            }
        }


        public MainViewModel(IMvxNavigationService navigationService, IPlatformService platformService, IConnectionFactory Connectionfactory)
        {
            _platformService = platformService;
            connectionfactory = Connectionfactory;
           // _platformService.GetConnection(); 
            //  _foodrecyclerViewModel = new Lazy<FoodRecyclerViewModel>(Mvx.IocConstruct<FoodRecyclerViewModel>);
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
             sqlconection = connectionfactory.ProduceConnection();
            /*Channels = new List<Channel> {
                new Channel(0,"PLyxLqRfXH_eOMYvGsYRYkrjaoZ8DG3Sxu", "Little Angel", "angel" ),
                new Channel(1,"PLKtBoDIM5r2XqS3iqLrcySCqtSNSFjM7j" ,"Peppa Pig","peppa"),
                new Channel(2,"PL8XvIF6dDmUt8MuEVKuv86uO96qMk0dk6" ,"Caillou","calilou"),
                            new Channel(3,"PLdkj6XH8GYPRc1lmIqwbWkWdqsY17XsLo" ,"Super Simple Songs","shark")
            };*/

        }
        public MvxCommand<Channels> ChannelSelectedCommand
        {
            get
            {
                return new MvxCommand<Channels>(selectedList =>
                {
                    ShowViewModel<PlayVideoViewModel>
                    (new { listId = selectedList.PlayListId });
                });
            }
        }

        public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }


        public async Task InitDataAsync()
        {


           
            var channelRepo = new Repository<Channels>(sqlconection);
            //!! await channelRepo.Insert((new Channels() { PlayListId = "PLyxLqRfXH_eOMYvGsYRYkrjaoZ8DG3Sxu", Title = "Little Angel" }));
            List<Channels> list = await channelRepo.Get();

            Channels = new ObservableCollection<Channels>(list);
            /* Channels = new List<Channels> {
                (new Channels() { PlayListId = "PLyxLqRfXH_eOMYvGsYRYkrjaoZ8DG3Sxu", Title = "Little Angel" })};*/

            // channels = new ObservableCollection<Channels>(list);
            //var sqlconection = connectionfactory.ProduceConnection();


            // IRepository<Channels> stockRepo = new Repository<Channels>(sqlconection);

            //   Channels = await stockRepo.Get();

            var i = 0;


        }


        private IMvxAsyncCommand _navigateCommand;
        private readonly IMvxNavigationService _navigationService;

        public void SomeMethod()
        {
            //  MyObject MyObject1 = new MyObject(i);
            _navigationService.Navigate<PlayVideoViewModel>();

            //Do something with the result MyReturnObject that you get back
        }

        public async Task ChooseChannel(string playlist)
        {
           // MyObject MyObject1 = new MyObject(i);
            
            await _navigationService.Navigate<PlayVideoViewModel, string>(playlist);
           // _navigationService.Navigate<PlayVideoViewModel>();

           
        }
        public void SomeMethod1()
        {
            var r = 1; //remove it
        }

        public async Task ChooseFavourites()
        {

            await _navigationService.Navigate<FavouritesViewModel>();

        }
        public async Task ChooseSettings()
        {

            await _navigationService.Navigate<SettingsViewModel>();

        }





    }
}