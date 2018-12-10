using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class NewChannelViewModel:MvxViewModel
    {
        public IRepository<Channels> channelRepo;
        private static Channels channel = new Channels();
        public Channels Channel
        {
            get { return channel; }
            set { channel = value; RaisePropertyChanged(() => Channel); }
        }

        public MvxCommand AddCommand { get; }

        public NewChannelViewModel()
        {
            AddCommand = new MvxCommand(Add); 
        }

        public string Error { get; private set; }



        public async  void Add()
        {
            string playlistid;
            this.Error = null;

            if (string.IsNullOrEmpty(Channel.PlayListId))
            {
                this.Error = "Playlist is empty";
            }

            if (string.IsNullOrEmpty(this.Error))// no error, save settings...
            {
                var apiUrl = PlayVideoViewModel.apiUrlForPlaylist;
                string url = Channel.PlayListId;//"https://www.youtube.com/watch?v=xOpU3U3cgjA&list=PLOso76FsKY3WiSUm-qEeSkMb90pr4JKQH";
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

                        var sqlconection = MainViewModel.connectionfactory.ProduceConnection();
                        IRepository<Channels> stockRepo = new Repository<Channels>(sqlconection);
                        Channel.PlayListId = playlistid;
                        var list = await stockRepo.Insert(Channel);

                    }

                    catch (Exception exception)
                    {

                    }
                }
            }
            else
            {
                this.RaisePropertyChanged(() => this.Error);
            }



        }
    }
}
