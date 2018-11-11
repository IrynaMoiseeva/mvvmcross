using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Data;

using MvvmCross_Application1.Core.Services;
using MvvmCross_Application1.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvvmCross_Application1.Core.Model
{

   
    public class YoutubeItem:MvxViewModel
    {
      
        public string VideoId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ChannelTitle { get; set; }

        public string DefaultThumbnailUrl { get; set; }

        public string MediumThumbnailUrl { get; set; }

        public string HighThumbnailUrl { get; set; }

        public string StandardThumbnailUrl { get; set; }

        public string MaxResThumbnailUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        public int? ViewCount { get; set; }

        public int? LikeCount { get; set; }

        public int? DislikeCount { get; set; }

        public int? FavoriteCount { get; set; }

        public int? CommentCount { get; set; }

        public List<string> Tags { get; set; }

        
        public YoutubeItem()
        {
            
            SubCommand = new MvxCommand(Sub);
            
           // var t = f.GetPlatform();
           // f.GetConnection();
        }

        public IPlatformService platformservice;
        public MvxCommand SubCommand { get; }
        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }


        public void Sub()
        {
            
            var v = VideoId;
            
            Db.platform.GetConnection();
           /* var f = MainViewModel._platformService;
            var t = f.GetPlatform();
            f.GetConnection();*/
           // f.InsertIntoTableFavourities(new Favorite(VideoId));

          
            

        }

        public MvxCommand AddCommand { get; }

        public void Add()
        {
            var f = MainViewModel._platformService;
           
            var v = VideoId;
        }
    }
    public class Db

    {
        public static Db Instance = new Db();
        public IPlatformService platform;
        public Db()
        {
            platform = MainViewModel._platformService;
        }

    }
}
