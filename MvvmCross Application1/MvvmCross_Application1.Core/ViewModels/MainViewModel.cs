using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Services;
using System;
using System.Collections.Generic;
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

        public PlayVideoViewModel PlayVideoViewModel => playvideoViewModel.Value;

        private List<Channel> channels;
        public List<Channel> Channels //{ get; set; }
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

            //  _foodrecyclerViewModel = new Lazy<FoodRecyclerViewModel>(Mvx.IocConstruct<FoodRecyclerViewModel>);
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            Channels = new List<Channel> {
                new Channel(0,"PLyxLqRfXH_eOMYvGsYRYkrjaoZ8DG3Sxu", "Little Angel", "angel" ),
                new Channel(1,"PLKtBoDIM5r2XqS3iqLrcySCqtSNSFjM7j" ,"Peppa Pig","peppa"),
                new Channel(2,"PL8XvIF6dDmUt8MuEVKuv86uO96qMk0dk6" ,"Caillou","calilou"),
                            new Channel(3,"PLdkj6XH8GYPRc1lmIqwbWkWdqsY17XsLo" ,"Super Simple Songs","shark")



            };
        }
        private IMvxAsyncCommand _navigateCommand;
        private readonly IMvxNavigationService _navigationService;

        public void SomeMethod()
        {
            //  MyObject MyObject1 = new MyObject(i);
            _navigationService.Navigate<PlayVideoViewModel>();

            //Do something with the result MyReturnObject that you get back
        }

        public async Task ChooseChannel(int i)
        {
            MyObject MyObject1 = new MyObject(i);
            
            await _navigationService.Navigate<PlayVideoViewModel, string>(Channels[i].PlayListId);
           // _navigationService.Navigate<PlayVideoViewModel>();

           
        }

        public async Task ChooseFavourites()
        {

            await _navigationService.Navigate<FavouritesViewModel>();

        }




    }
}