using System;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross.Core.Navigation;
using MvvmCross_Application1.Core.Repositories;
using static MvvmCross_Application1.Core.ViewModels.SettingsViewModel;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        public Channels entity;
        private readonly IChannelRepository localSettingsRepository;
        private readonly IMvxNavigationService navigationService;
        public static SettingsViewModel Instance = new SettingsViewModel();
        private static ObservableCollection<Channels> channels = new ObservableCollection<Channels>();
        public  ObservableCollection<Channels> Channels
        {
            get { return channels; }
            set { channels = value; RaisePropertyChanged(() => Channels); }
        }
        public SettingsViewModel()
        {

        }

        public SettingsViewModel(IMvxNavigationService navigationService,IChannelRepository localSettingsRepository)

        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            this.localSettingsRepository = localSettingsRepository;

        }


        public override async Task Initialize()
        {
            await base.Initialize();

            await InitDataAsync();
        }

        private MvxAsyncCommand removeCommand;
        public MvxAsyncCommand RemoveCommand
        {
            get
            {
                removeCommand = new MvxAsyncCommand(() => Remove(entity));
                return removeCommand;
            }
        }

        public async Task Remove(Channels entity)
        {
            var result= await localSettingsRepository.Delete(entity);
            IEnumerable<Channels> list = await localSettingsRepository.ReadAll();
            Channels = new ObservableCollection<Channels>(list);

        }

        public async Task InitDataAsync()
        {
            // await localSettingsRepository.DropTable();
           // await localSettingsRepository.CreateTable();
        //    await localSettingsRepository.UpdateOrCreate(new Channels { PlayListId = "34343434", Title="ggggg" });*/
            IEnumerable<Channels> list = await localSettingsRepository.ReadAll();
            Channels = new ObservableCollection<Channels>(list);

        }
       

        public async Task AddNewChannel()
        {

            MyReturnObject result = await navigationService.Navigate<NewChannelViewModel, MyObject, MyReturnObject>(new MyObject(1));
            IEnumerable<Channels> list = await localSettingsRepository.ReadAll();
            Channels = new ObservableCollection<Channels>(list);
            this.RaisePropertyChanged(() => this.Channels); // update data on the view 
          
        }


        public class MyReturnObject
        {
            public int channel;
            public MyReturnObject(int channel)
            {
                this.channel = channel;
            }
        }

    }
}