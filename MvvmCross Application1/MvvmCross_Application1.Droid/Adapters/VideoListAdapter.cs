using System.Collections.Specialized;
using System.Net;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Airbnb.Lottie;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.ViewModels;
using MvvmCross_Application1.Droid.Controls;
using MvvmCross_Application1.Droid.Views;

namespace MvvmCross_Application1.Droid.Adapters
{
    public class VideoListAdapter : MvxRecyclerAdapter
    {
        public MvxViewModel ViewModel { get; set; }
        public bool AllChecked { get; set; } // for removed tooglebutton
        public Context mcon { get; set; }
        public View View;
        public int ToogleIcon { get; set; }
        public LottieAnimationView animationView;

        private LottieFavoriteButton likeButton;

        public VideoListAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {
          
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
            public LottieFavoriteButton likebutton;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)

            {
                var d=context.DataContext;
                title = itemView.FindViewById<TextView>(Resource.Id.titletext);
                published_date = itemView.FindViewById<TextView>(Resource.Id.published_date);
                imageView = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);
                likebutton = itemView.FindViewById<LottieFavoriteButton>(Resource.Id.favorite);
            }
        }

        protected object GetElementAt(int position)
        {
            return ItemsSource.ElementAt(position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var video = ItemsSource.ElementAt(position) as YoutubeItem;
           
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

            likeButton = myHolder.likebutton;

            likeButton.OnClickCommandDisLike = new MvxAsyncCommand(() =>(ViewModel as PlayVideoViewModel).RemoveFromFavorities(video));

            likeButton.OnClickCommandLike = new MvxAsyncCommand(() => (ViewModel as PlayVideoViewModel).AddToFavourites(video));

            if (video.IsLiked)
                likeButton.LazyAnimationProgress = 0.8f;
            else
                likeButton.LazyAnimationProgress = 0.0f;



        }

        protected override void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

    }

}









