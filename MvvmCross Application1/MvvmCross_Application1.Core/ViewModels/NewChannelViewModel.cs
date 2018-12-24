using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static MvvmCross_Application1.Core.ViewModels.SettingsViewModel;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class NewChannelViewModel: MvxViewModel<MyObject, MyReturnObject>
    {
        private readonly IChannelRepository localSettingsRepository;
        private static Channels channel = new Channels();
        public Channels Channel
        {
            get { return channel; }
            set { channel = value; RaisePropertyChanged(() => Channel); }
        }

        public MvxCommand AddCommand { get; }

        public NewChannelViewModel(IChannelRepository localSettingsRepository)
        {
            AddCommand = new MvxCommand(Add);
            Channel.PlayListId = null;
            Channel.Title = null;
            this.localSettingsRepository = localSettingsRepository;
        }

        public string Error { get; private set; }



        public async void Add()
        {
            string playlistid;
            this.Error = null;

            if (string.IsNullOrEmpty(Channel.PlayListId))
            {
                this.Error = "Playlist or/and Title can not be empty";
            }

            if (string.IsNullOrEmpty(this.Error))// no error, save settings...
            {
                var apiUrl = PlayVideoViewModel.apiUrlForPlaylist;

                string url = Channel.PlayListId; // format of link user should input "https://www.youtube.com/watch?v=xOpU3U3cgjA&list=PLOso76FsKY3WiSUm-qEeSkMb90pr4JKQH";

                Regex regexPattern = new Regex("(?<=(list=)|,)[^(,|&)]*");

                Match matchResults = regexPattern.Match(url);


                if (matchResults.Success)
                {
                    playlistid = matchResults.Value;
                    apiUrl = string.Format(apiUrl, playlistid);
                    var httpClient = new HttpClient();
                    var json = await httpClient.GetStringAsync(apiUrl);

                    try
                    {
                        JObject response = JsonConvert.DeserializeObject<dynamic>(json);
                        Channel.PlayListId = playlistid;
                        var f= await localSettingsRepository.InsertAsync(Channel);


                    }

                    catch (Exception exception)
                    {

                    }
                }
                else
                    this.Error = "Link is invalid. Please use another one.";
            }


            if (!string.IsNullOrEmpty(this.Error))
            {
                this.RaisePropertyChanged(() => this.Error);
            }

            else
                    Close(this);


        }

        public override void Prepare(MyObject parameter)
        {

        }
    }
}
