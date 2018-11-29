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
using MvvmCross_Application1.Droid.Controls;
using MvvmCross_Application1.Droid.Views;

namespace MvvmCross_Application1.Droid
{
    public class VideoListAdapter : MvxRecyclerAdapter, YouTubeThumbnailView.IOnInitializedListener,
    IYouTubeThumbnailLoaderOnThumbnailLoadedListener, ValueAnimator.IAnimatorUpdateListener
    {
        private EventHandler animationButtonClickedHandler;
        public MvxViewModel ViewModel { get; set; }
        public Boolean AllChecked { get; set; } // for removed tooglebutton
        public Context mcon { get; set; }
        private readonly Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader> thumbnailViewToLoaderMap;
        public View View;
        private ValueAnimator animator;
        public int ToogleIcon { get; set; }
        private ImageView imageView;
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

        public VideoListAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {

            thumbnailViewToLoaderMap = new Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader>();
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


        public class MyViewHolder : MvxRecyclerViewHolder//RecyclerView.ViewHolder
        {

            public TextView title;
            public TextView published_date;
            public ImageView imageView;
            public LottieFavoriteButton likebutton;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context):base(itemView,context)

            {
                title  = itemView.FindViewById<TextView>(Resource.Id.titletext);
                published_date=itemView.FindViewById<TextView>(Resource.Id.published_date);
                imageView = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);
                likebutton = itemView.FindViewById<LottieFavoriteButton>(Resource.Id.favorite);
            }
        }
       

        public  override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
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



            likeButton = View.FindViewById<LottieFavoriteButton>(Resource.Id.favorite);
            likeButton.OnClickCommandLike = video.CheckCommand;
            likeButton.OnClickCommandDisLike = video.UnCheckCommand;
           
            if (video.IsLiked)
                likeButton.LazyAnimationProgress = 0.8f;
            else
                likeButton.LazyAnimationProgress = 0.0f;
           
        }

       /* public void startCheckAnimation()
        {
            animator.AddUpdateListener(new OnAnimationClickListener(animationView));


            if (animationView.Progress == 0.0f)

                animator.Start();
            else
            {
                animationView.Progress = 0.0f;

               
                animator.Cancel();
                animator.RemoveAllListeners();
               
            }
           
        }


        public class OnAnimationClickListener : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            private LottieAnimationView animationView;
            public OnAnimationClickListener(LottieAnimationView animationView)
            {
                this.animationView = animationView;
            }

            public void OnAnimationUpdate(ValueAnimator animator)
            {

                animationView.Progress = (float)animator.AnimatedValue;
            }
        }
*/




        protected override void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }





        protected override View InflateViewForHolder(ViewGroup parent, int viewType, IMvxAndroidBindingContext bindingContext)
        {
            var view = base.InflateViewForHolder(parent, viewType, bindingContext);

            // var clickablePiece1 = view.FindViewById<View>(Resource.Id.clickable_piece1);
            // var clickablePiece2 = view.FindViewById<View>(Resource.Id.clickable_piece2);

            // clickablePiece1.SetOnClickListener(this);
            // clickablePiece2.SetOnClickListener(this);

            return view;
        }
        public void ReleaseLoaders()
        {
            foreach (IYouTubeThumbnailLoader loader in thumbnailViewToLoaderMap.Values)
            {
                loader.Release();
            }
        }
        void YouTubeThumbnailView.IOnInitializedListener.OnInitializationFailure(YouTubeThumbnailView view, YouTubeInitializationResult result)
        {
            view.SetImageResource(Resource.Drawable.cart1);// no_thumbnail
        }

        void YouTubeThumbnailView.IOnInitializedListener.OnInitializationSuccess(YouTubeThumbnailView view, IYouTubeThumbnailLoader loader)
        {
            loader.SetOnThumbnailLoadedListener(this);

            if (!thumbnailViewToLoaderMap.ContainsKey(view))
                thumbnailViewToLoaderMap.Add(view, loader);

            view.SetImageResource(Resource.Drawable.cart1);//loading_thumbnail
                                                           // var videoId = (string)view.Tag;
                                                           //loader.SetVideo(videoId);
        }

        void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailError(YouTubeThumbnailView view, YouTubeThumbnailLoaderErrorReason errorReason)
        {
            view.SetImageResource(Resource.Drawable.cart1);//no_thumbnail
        }

        void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailLoaded(YouTubeThumbnailView view, string videoId)
        {

        }

        public void OnAnimationUpdate(ValueAnimator animation)
        {
            throw new NotImplementedException();
        }
    }




}









