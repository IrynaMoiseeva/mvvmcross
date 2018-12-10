using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Airbnb.Lottie;
using Com.Google.Android.Youtube.Player;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.ViewModels;
using MvvmCross_Application1.Droid.Controls;
using MvvmCross_Application1.Droid.Views;

namespace MvvmCross_Application1.Droid.Adapters
{
    public class FavoriteListAdapter : MvxRecyclerAdapter
    {
        public MvxViewModel ViewModel { get; set; }
        public Boolean AllChecked { get; set; } // for removed tooglebutton
        public Context mcon { get; set; }
        private readonly Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader> thumbnailViewToLoaderMap;
        public View View;
        public int ToogleIcon { get; set; }
        public LottieAnimationView animationView;

        private LottieFavoriteButton likeButton;

        public bool? isLiked;
        public bool? IsLiked
        {
            get { return isLiked; }
            set
            {
                isLiked = value;

                likeButton.LazyAnimationProgress = (value.HasValue && value.Value)
                            ? LottieFavoriteButton.AnimationProgressEndFrame
                    : LottieFavoriteButton.AnimationProgressStartFrame;
            }
        }

        public FavoriteListAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {

           // thumbnailViewToLoaderMap = new Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader>();
        }



        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);


            View = this.InflateViewForHolder(parent, viewType, itemBindingContext);

            return new MyViewHolder(View, itemBindingContext);
        }

        public static Bitmap GetBitmapFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }


        public class MyViewHolder : MvxRecyclerViewHolder
        {

            public TextView title;
            public TextView published_date;
            public ImageView imageView;
            public Button removeButton;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)

            {
                title = itemView.FindViewById<TextView>(Resource.Id.titletext);
                published_date = itemView.FindViewById<TextView>(Resource.Id.published_date);
                imageView = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);

                removeButton = itemView.FindViewById<Button>(Resource.Id.RemoveButton);
            }
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            YoutubeItem video = (GetItem(position)) as YoutubeItem;

            MyViewHolder myHolder = holder as MyViewHolder;

            myHolder.title.Text = video.Title;
            myHolder.published_date.Text = video.PublishedAt.ToString();


            Bitmap bbb = GetBitmapFromUrl(video.MediumThumbnailUrl);
            myHolder.imageView.SetImageBitmap(bbb);

            myHolder.imageView.Click += (sender, args) =>
            {
                var intent = new Intent(mcon, typeof(PlayVideoActivity));
                intent.AddFlags(ActivityFlags.NewTask);

                intent.PutExtra(PlayVideoActivity.ExtraUrlKey, video.VideoId);

                mcon.StartActivity(intent);
            };



            myHolder.removeButton.Click += (s, e) =>
            {
                var result =  ((FavouritesViewModel)ViewModel).Remove(video);
                    // channel.Remove();
                    //if (ViewModel != null)
                    //    ViewModel.Initialize(); // to refresh page  


               // video.UnCheck();
                if (ViewModel != null)
                    ViewModel.Initialize(); // to refresh page  
            };

        }


        protected override void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }


    }



}
