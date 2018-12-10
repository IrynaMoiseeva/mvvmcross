using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCross_Application1.Core.DataBase;
using System.Collections.ObjectModel;

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
        //public static FavouritesViewModel Instance = new FavouritesViewModel();

        SQLite.SQLiteAsyncConnection sqlconection;
        private MyObject myObject;
        public static PlayVideoViewModel Instance = new PlayVideoViewModel();
        private List<Video> videos;
        private List<Channel> channels;
        public const string ApiKey = "AIzaSyAn95XgsxmK2c3fwrtyV0-pxOm6RhIr-cI";
        public const string Key = "AIzaSyAqB61v3YI6H7Q-jhx3HVSPNBDvX-dr_yY";
        private  string apiUrlForContent = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=5&playlistId="
            + Key + "&key=" + ApiKey;

        //+""+"&key="+Deleliper.key
        private string listid = "PL8XvIF6dDmUs4bjs3qMbX7coPsqCCcGHu";
        public static string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=5&playlistId="
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

        public ObservableCollection<Favor12> FavoriteList;
        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }

        public PlayVideoViewModel()
        {
            sqlconection = MainViewModel.connectionfactory.ProduceConnection();
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
            //int r = (int)param.channel;



           apiUrlForPlaylist =string.Format(apiUrlForPlaylist, param);

        }

        private MvxAsyncCommand addToFavoritiesCommand;
        public MvxAsyncCommand AddToFavoritiesCommand
        {
            get
            {
                addToFavoritiesCommand = new MvxAsyncCommand(() => AddToFavourites(null));
                return addToFavoritiesCommand;
            }
        }
       

        public async Task AddToFavourites(YoutubeItem entity)
        {
            IRepository<Favor12> stockRepo = new Repository<Favor12>(sqlconection);
            var list = await stockRepo.Get();
            Favor12 add = new Favor12{ VideoId = entity.VideoId };
            var result=await stockRepo.Insert(add);
        


        }

    private MvxAsyncCommand removeFromFavoritiesCommand;
        public MvxAsyncCommand RemoveFromFavoritiesCommand
        {
            get
            {
                removeFromFavoritiesCommand = new MvxAsyncCommand(() => RemoveFromFavorities(null));
                return removeFromFavoritiesCommand;
            }
        }


        public async Task RemoveFromFavorities(YoutubeItem entity)
        {
           
            IRepository<Favor12> stockRepo = new Repository<Favor12>(sqlconection);
            var list = await stockRepo.Get();
            var entitytoremove = list.Where(x => x.VideoId == entity.VideoId);

            var d = entitytoremove.FirstOrDefault();
            var result = await stockRepo.Delete(d);


        }

        public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }
        public List<string> FavoriteListid {get;set;}


        public async Task InitDataAsync()
        {
           
            await sqlconection.CreateTablesAsync<Favor12, Channels>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);

            IRepository<Favor12> stockRepo = new Repository<Favor12>(sqlconection);
            var list = await stockRepo.Get();


             FavoriteList = new ObservableCollection<Favor12>();
            foreach (var item in list)
            {
                FavoriteList.Add(item);
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

                    var f = FavoriteList.Where(x => x.VideoId == youtubeItem.VideoId);

                    youtubeItem.IsLiked = f.Count()>0; //FavoriteList.Where(x => x.VideoId == youtubeItem.VideoId);//Contains(youtubeItem.VideoId);
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
    

