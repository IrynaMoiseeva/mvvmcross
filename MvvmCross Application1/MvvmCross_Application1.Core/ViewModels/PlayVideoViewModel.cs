using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SQLite;
using MvvmCross_Application1.Core.DataBase;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class MyObject
    {
        public int channel;
        public MyObject(int channel)
        {
            this.channel = channel;
        }
    }
    public class PlayVideoViewModel : MvxViewModel<string>,IMvxNotifyPropertyChanged
    {
        private MyObject myObject;
        public static PlayVideoViewModel Instance = new PlayVideoViewModel();
        private List<Video> videos;
        private List<Channel> channels;
        public const string ApiKey = "AIzaSyAn95XgsxmK2c3fwrtyV0-pxOm6RhIr-cI";
        public const string Key = "AIzaSyAqB61v3YI6H7Q-jhx3HVSPNBDvX-dr_yY";
        private string apiUrlForContent = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=5&playlistId="
            + Key + "&key=" + ApiKey;

        //+""+"&key="+Deleliper.key
        private string listid = "PL8XvIF6dDmUs4bjs3qMbX7coPsqCCcGHu";
        private string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=5&playlistId="
       + "{0}"
       //+ "Your_PlaylistId"
       + "&key="
       + ApiKey;

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.search.list
        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "{0}"
            //+ "0ce22qhacyo,j8GU5hG-34I,_0aQJHoI1e8"
            //+ "Your_Videos_Id"
            + "&key="
            + ApiKey;

        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }

        public PlayVideoViewModel()
        {
          Db.platform.GetConnection();

          //  var vv = MainViewModel.connectionfactory.ProduceConnection();



            //   apiUrlForPlaylist = string.Format(apiUrlForPlaylist, listid);
        }

        private  static List <YoutubeItem> youtubeItems = new List<YoutubeItem>();

        public List<YoutubeItem> YoutubeItems
        {
            get { return youtubeItems; }
            set
            {
                youtubeItems = value;
                RaisePropertyChanged(() => YoutubeItems);

            }
        }


        public List<Video> Videos //{ get; set; }
        {
            get { return videos; }
            set
            {
                videos = value;
                RaisePropertyChanged(() => Videos);
            }
        }

       
        public string VideoUrl { get; private set; }
        public string PlayListUrl
        {
            get { var b = youtubeItems.First(); return b.VideoId; }
            private set { RaisePropertyChanged(() => PlayListUrl); }
        }

        public void SomeMethod1()
        {
            var r = 1; //remove it
        }
        public override void Prepare(string param)
        { 
            
           // myObject = param;
           // int r = (int)param.channel;
            apiUrlForPlaylist=string.Format(apiUrlForPlaylist, param);

        }
        public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }
        public List<string> FavoriteListid {get;set;}


        public async Task InitDataAsync()
        {
            

               //!!! var list = Db.platform.Select();

           var sqlconection = MainViewModel.connectionfactory.ProduceConnection();
            await sqlconection.CreateTablesAsync<Favor12, Channels>();

            IRepository<Favor12> stockRepo = new Repository<Favor12>(sqlconection);
            var list = await stockRepo.Get();

            //var list = new DbOperations(sqlconection).Select();!!!


            // var f = new DbOperations(vv);     
            //  var list = f.Select(); 
            // var str = Db.platform.DestinationPath;

            // var con =  new SQLite.SQLiteConnection(str);
            //  var data = con.Table<Favor12>().ToList();


            FavoriteListid = new List<string>();
            foreach (var item in list)
            {
                FavoriteListid.Add(item.VideoId);
            }

            var videoIds = await GetVideosIdsFromPlayListAsync();



        }

        public async Task<List<string>> GetVideosIdsFromPlayListAsync()
        {
            //var api_key = "03e8168ffbb8cafb6b8b6679c528ec97";

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForPlaylist);
           // var f = new List<string>();
            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("contentDetails")?.Value<string>("videoId"));
                };

                YoutubeItems = await GetVideosDetailsAsync(videoIds);

            }
            catch (Exception exception)
            {
            }

            return videoIds;
        }

        private async Task<List<YoutubeItem>> GetVideosDetailsAsync(List<string> videoIds)
        {
            // IPlatformService platformservice = null;
            //var favvideos = FavouritesViewModel.Instance.FavoritesVideos.ToArray();

            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(apiUrlForVideosDetails, videoIdsString));

            var youtubeItems = new List<YoutubeItem>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    var snippet = item.Value<JObject>("snippet");
                    var statistics = item.Value<JObject>("statistics");
                    
                    var youtubeItem = new YoutubeItem ()
                    {
                        Title = snippet.Value<string>("title"),
                        Description = snippet.Value<string>("description"),
                        ChannelTitle = snippet.Value<string>("channelTitle"),
                        PublishedAt = snippet.Value<DateTime>("publishedAt"),
                        VideoId = item?.Value<string>("id"),
                        DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url"),
                        MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url"),
                        HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url"),
                        StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url"),
                        MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url"),

                        ViewCount = statistics?.Value<int>("viewCount"),
                        LikeCount = statistics?.Value<int>("likeCount"),
                        DislikeCount = statistics?.Value<int>("dislikeCount"),
                        FavoriteCount = statistics?.Value<int>("favoriteCount"),
                        CommentCount = statistics?.Value<int>("commentCount"),

                        Tags = (from tag in snippet?.Value<JArray>("tags") select tag.ToString())?.ToList(),
                    };
                    youtubeItem.IsLiked = FavoriteListid.Contains(youtubeItem.VideoId);
                    youtubeItems.Add(youtubeItem);

                }

                return youtubeItems;
            }
            catch (Exception exception)
            {
                return youtubeItems;
            }
        }
    }
}
    

