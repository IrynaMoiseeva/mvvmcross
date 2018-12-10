using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Data;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Services;
using MvvmCross_Application1.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvvmCross_Application1.Core.Model
{
    public class YoutubeItem: MvxViewModel
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


        public bool IsLiked { get; set; }

        public YoutubeItem()
        {
            
            CheckCommand = new MvxCommand(Check);
            UnCheckCommand = new MvxCommand(UnCheck);
            
           
        }
        // private readonly Lazy<PlayVideoViewModel> playvideoViewModel;



        //public PlayVideoViewModel PlayVideoViewModel => playvideoViewModel.

        public IPlatformService platformservice;

        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }


        public MvxCommand CheckCommand { get; }
        public void Check()
        {

            var v = VideoId;
            IsLiked = true;
            var d = PlayVideoViewModel.Instance.YoutubeItems;

            Db.platform.GetConnection();
            Db.platform.Insert(VideoId);
                 
          

        }


        public MvxCommand UnCheckCommand { get; }

        public void UnCheck()
        {

            IsLiked = false;



            var v = VideoId;
            Db.platform.GetConnection();
            Db.platform.Remove(VideoId);
            var dd=Db.platform.Select();
            var favvideos = FavouritesViewModel.Instance.FavoritesVideos.ToArray();
            var FavvideosExcludeDel = favvideos.Where(x => x.VideoId != v).ToList();
            FavouritesViewModel.Instance.FavoritesVideos = new ObservableCollection<YoutubeItem> (FavvideosExcludeDel);
            //RaiseCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }
     
    }
    public class Db

    {
        public static Db Instance = new Db();
        public IPlatformService platform;
       // public IConnectionFactory connectionfactory;
       // var ff = new DbOperations(MainViewModel.connectionfactory.ProduceConnection());

        public Db()
        {
            platform = MainViewModel._platformService;
            // var dbconection = MainViewModel.connectionfactory.
         //   connectionfactory = MainViewModel.connectionfactory;
            

        }

    }
}
