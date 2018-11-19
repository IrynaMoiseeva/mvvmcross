using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Data;

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

   
    public class YoutubeItem: MvxNotifyPropertyChanged
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
            
            CheckCommand = new MvxCommand(Check);
            UnCheckCommand = new MvxCommand(UnCheck);
            
           // var t = f.GetPlatform();
           // f.GetConnection();
        }

        public IPlatformService platformservice;
        public MvxCommand CheckCommand { get; }
        public Db Db
        {
            get
            {
                return (Db.Instance);
            }
        }


        public void Check()
        {
            
            var v = VideoId;
            
            Db.platform.GetConnection();
            Db.platform.Insert(VideoId);
           /* var f = MainViewModel._platformService;
            var t = f.GetPlatform();
            f.GetConnection();*/
           // f.InsertIntoTableFavourities(new Favorite(VideoId));

          
            

        }

        public MvxCommand UnCheckCommand { get; }

        public void UnCheck()
        {
           // var f = MainViewModel._platformService;
           
            var v = VideoId;
            Db.platform.GetConnection();
            Db.platform.Remove(VideoId);
            var dd=Db.platform.Select();
            var favvideos = FavouritesViewModel.Instance.FavoritesVideos.ToArray();
            var FavvideosExcludeDel = favvideos.Where(x => x.VideoId != v).ToList();
            FavouritesViewModel.Instance.FavoritesVideos = new ObservableCollection<YoutubeItem> (FavvideosExcludeDel);
            //RaiseCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }
      /*  public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void RaiseCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            var handler = CollectionChanged;
            if (handler == null)
                return;

            handler(this, args);
        }*/
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
