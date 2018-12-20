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
using MvvmCross_Application1.Core.Repositories;

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
        public IFavorRepository localFavorsRepository;
       
        public static PlayVideoViewModel Instance = new PlayVideoViewModel();
        //private List<Video> videos;
        public const string ApiKey = "AIzaSyAn95XgsxmK2c3fwrtyV0-pxOm6RhIr-cI";
        public const string Key = "AIzaSyAqB61v3YI6H7Q-jhx3HVSPNBDvX-dr_yY";
        private  string apiUrlForContent = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=3&playlistId="
            + Key + "&key=" + ApiKey;

        //+""+"&key="+Deleliper.key
        public static string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=3&playlistId="
       + "{0}"
       //+ "Your_PlaylistId"
       + "&key="
       + ApiKey;
        public string apiUrlPlaylist;

        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "{0}"
            //+ "0ce22qhacyo,j8GU5hG-34I,_0aQJHoI1e8"
            //+ "Your_Videos_Id"
            + "&key="
            + ApiKey;

        public ObservableCollection<FavoriteVideos> FavoriteList;
        /* public Db Db
         {
             get
             {
                 return (Db.Instance);
             }
         }*/
        public PlayVideoViewModel()
        {

        }
        public async Task Init()
        {
            await  InitDataAsync();
           this.RaisePropertyChanged(() => this.YoutubeItems);
        }

        public PlayVideoViewModel(IFavorRepository localFavorsRepository)
        {
            this.localFavorsRepository = localFavorsRepository;
           
        }

        private  static ObservableCollection<YoutubeItem> youtubeItems = new ObservableCollection<YoutubeItem>();

        public ObservableCollection<YoutubeItem> YoutubeItems
        {
            get { return youtubeItems; }
            set
            {
                youtubeItems = value;
                RaisePropertyChanged(() => YoutubeItems);

            }
        }


       /* public List<Video> Videos 
        {
            get { return videos; }
            set
            {
                videos = value;
                RaisePropertyChanged(() => Videos);
            }
        }*/

       
        public string VideoUrl { get; private set; }
        public string PlayListUrl
        {
            get { var b = youtubeItems.First(); return b.VideoId; }
            private set { RaisePropertyChanged(() => PlayListUrl); }
        }


        public override void Prepare(string param)
        {

           apiUrlPlaylist =string.Format(apiUrlForPlaylist, param);

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
           
          var entitytoadd = new FavoriteVideos { VideoId = entity.VideoId };
          var result = await localFavorsRepository.InsertAsync(entitytoadd);

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
           var list = await localFavorsRepository.ReadAll();
            var entitytoremove = list.Where(x => x.VideoId == entity.VideoId).FirstOrDefault();

          var v=  await localFavorsRepository.Delete(entitytoremove);

           // var entitytoremove = FavoriteList.Where(x => x.VideoId == entity.VideoId).FirstOrDefault();
            // var result = await localFavorsRepository.Delete(entitytoremove);
           
        }

      /*  public override async Task Initialize()
        {
            await base.Initialize();


            await InitDataAsync();
        }*/

        public List<string> FavoriteListid {get;set;}


        public async Task InitDataAsync()
        {
            IEnumerable<FavoriteVideos> list = await localFavorsRepository.ReadAll();
           
               FavoriteList = new ObservableCollection<FavoriteVideos>();
              foreach (var item in list)
              {
                  FavoriteList.Add(item);
              }

            var videoIds = await GetVideosIdsFromPlayListAsync();

        }

        public async Task<List<string>> GetVideosIdsFromPlayListAsync()
        {
        

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlPlaylist);
           
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

        private async Task<ObservableCollection<YoutubeItem>> GetVideosDetailsAsync(List<string> videoIds)
        {

            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(apiUrlForVideosDetails, videoIdsString));

            var youtubeItems = new ObservableCollection<YoutubeItem>();

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

                    youtubeItem.IsLiked = f.Count()>0; 
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
    

