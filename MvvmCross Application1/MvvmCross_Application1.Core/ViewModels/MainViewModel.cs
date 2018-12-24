using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Repositories;
using MvvmCross_Application1.Core.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        public static IDbConnectionManager dbConnection;
        public IChannelRepository localSettingsRepository;
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


        public MainViewModel(IMvxNavigationService navigationService, IChannelRepository localSettingsRepository)
        {
          
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            this.localSettingsRepository = localSettingsRepository;

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

            IEnumerable<Channels> list = await localSettingsRepository.ReadAll();
            Channels = new ObservableCollection<Channels>(list);
        }


        private readonly IMvxNavigationService _navigationService;

        public void SomeMethod()
        {
            _navigationService.Navigate<PlayVideoViewModel>();

        }

        public async Task ChooseChannel(string playlist)
        {
            
            await _navigationService.Navigate<PlayVideoViewModel, string>(playlist);
           
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