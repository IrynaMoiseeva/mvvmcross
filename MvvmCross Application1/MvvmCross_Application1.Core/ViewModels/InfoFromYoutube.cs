using MvvmCross_Application1.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.ViewModels
{
    public  class InfoFromYoutube
    {
        public const string ApiKey = "AIzaSyAn95XgsxmK2c3fwrtyV0-pxOm6RhIr-cI";
        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
           + "{0}"
           //+ "0ce22qhacyo,j8GU5hG-34I,_0aQJHoI1e8"
           //+ "Your_Videos_Id"
           + "&key="
           + ApiKey;

        public async Task<List<YoutubeItem>> GetVideosDetailsAsync(List<string> videoIds)
        {
            // IPlatformService platformservice = null;
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

                    var youtubeItem = new YoutubeItem()
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
