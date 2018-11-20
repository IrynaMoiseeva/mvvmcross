using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Binding.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Content;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross_Application1.Core.ViewModels;
using static Android.Support.V7.Widget.RecyclerView;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Droid.Views;
using Com.Google.Android.Youtube.Player;
using MvvmCross.Core.ViewModels;
using System.Collections.Specialized;
using Android.Graphics;
using Android.Media;
using System.IO;
using static Android.Provider.MediaStore.Video;
using System.Net;

namespace MvvmCross_Application1.Droid
{
    public class recycleradapter : MvxRecyclerAdapter, YouTubeThumbnailView.IOnInitializedListener,
    IYouTubeThumbnailLoaderOnThumbnailLoadedListener


    {
        private EventHandler _saveButtonClickedHandler;
        public MvxViewModel ViewModel { get; set; }
        public Boolean AllChecked { get; set; } // for removed tooglebutton
        public Context mcon { get; set; }
        private readonly Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader> thumbnailViewToLoaderMap;
        public View View;
        public int ToogleIcon { get; set; }
        private ImageView imageView;
        public recycleradapter(IMvxAndroidBindingContext bindingContext)
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
                    return Android.Graphics.BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }
        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
        {
            var n = ItemsSource;
            YoutubeItem video = (GetItem(position)) as YoutubeItem;
            var title = View.FindViewById<TextView>(Resource.Id.titletext);
            var published_date = View.FindViewById<TextView>(Resource.Id.published_date);
            title.Text = video.Title.ToString();
            published_date.Text = video.PublishedAt.ToString();

           
            Bitmap bbb = GetBitmapFromUrl(video.MediumThumbnailUrl);
            imageView= View.FindViewById<ImageView>(Resource.Id.thumbnail);
            imageView.SetImageBitmap(bbb);

            imageView.Click += (sender, args) =>
            {
                var intent = new Intent(mcon, typeof(PlayVideoActivity));
                intent.AddFlags(ActivityFlags.NewTask);

                intent.PutExtra(PlayVideoActivity.ExtraUrlKey, video.VideoId);

                mcon.StartActivity(intent);
            };
            
            var togglebutton = View.FindViewById<ToggleButton>(Resource.Id.FavoriteButton);

            togglebutton.SetBackgroundResource(ToogleIcon);
            if (AllChecked)
                togglebutton.Checked = true;
            _saveButtonClickedHandler = (s, e) =>
            {
                if (togglebutton.Checked)

                    video.Check();

                else
                { int wi=0;
                   // thumbnailViewToLoaderMap.Clear();
                    YouTubeThumbnailView Key;int b=0;
                    foreach (var item in thumbnailViewToLoaderMap)
                    {
                        if (position == wi) {
                            thumbnailViewToLoaderMap.Remove(item.Key);
                            
                           
                            break; }

                        wi = wi + 1;


                    }
                    //if (b==1)

                    video.UnCheck();
                    
                    if (AllChecked)
                    { //NotifyDataSetChanged(); 
                        if (ViewModel != null)
                            ViewModel.Initialize(); // to refresh page 
                                                    // NotifyDataSetChanged();
                    }
                }
            };

                togglebutton.Click += _saveButtonClickedHandler;




                //return View;


            }
        protected override void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var u = 0;
        }



        public class MyViewHolder : MvxRecyclerViewHolder
        {
            private readonly TextView textView;
            private ImageView imageView;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context)
             : base(itemView, context)
            {

                //var video = context.DataContext ;


                /* var title = convertView.FindViewById<TextView>(Resource.Id.titletext);
                 var published_date = convertView.FindViewById<TextView>(Resource.Id.published_date);
                 title.Text = video.Title.ToString();
                 published_date.Text = video.PublishedAt.ToString();

                 var thumbnail = convertView.FindViewById<YouTubeThumbnailView>(Resource.Id.thumbnail);
                 thumbnail.Tag = video.VideoId;
                 thumbnail.Initialize(DeveloperKey.Key, this);
                 thumbnail.Click += (sender, args) =>
                 {
                     var intent = new Intent(mcon, typeof(PlayVideoActivity));
                     intent.AddFlags(ActivityFlags.NewTask);

                     intent.PutExtra(PlayVideoActivity.ExtraUrlKey, video.VideoId);

                     mcon.StartActivity(intent);
                 };

                 //var imagebutton = convertView.FindViewById<ImageButton>(Resource.Id.mbutton);
                 var togglebutton = convertView.FindViewById<ToggleButton>(Resource.Id.FavoriteButton);
                 //togglebutton.SetOnClickListener();
                 // togglebutton.CheckedChange
                 togglebutton.SetBackgroundResource(ToogleIcon);
                 if (AllChecked)
                     togglebutton.Checked = true;
                 _saveButtonClickedHandler = (s, e) =>
                 {
                     if (togglebutton.Checked)

                         video.Check();

                     else

                         video.UnCheck();

                     if (ViewModel != null)
                         ViewModel.Initialize(); // to refresh page 
                                                 //NotifyDataSetChanged();};
                 };

                 togglebutton.Click += _saveButtonClickedHandler;




                 /*  this.textView = itemView.FindViewById<TextView>(Android.Resource.Id.Text1);

                   this.DelayBind(() =>
                   {
                       var set = this.CreateBindingSet<MyViewHolder, ViewModelItem>();
                       set.Bind(this.textView).To(x => x.Title);
                       set.Apply();
                   });
                   */
            }
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
            var videoId = (string)view.Tag;
            //loader.SetVideo(videoId);
        }

        void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailError(YouTubeThumbnailView view, YouTubeThumbnailLoaderErrorReason errorReason)
        {
            view.SetImageResource(Resource.Drawable.cart1);//no_thumbnail
        }

        void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailLoaded(YouTubeThumbnailView view, string videoId)
        {
            var v = 3;
        }
        
    }


    class MyAdapter : MvxRecyclerAdapter
    {

        public MyAdapter(IMvxAndroidBindingContext bindingContext)
                : base(bindingContext)
        {

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)

        {
            Context context = parent.Context;
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            // create a new view
            LayoutInflater inflater = LayoutInflater.From(context);

            View v = inflater.Inflate(Resource.Layout.Details, parent, false);
            // set the view's size, margins, paddings and layout parameters
            MyViewHolder1 vh = new MyViewHolder1(v, itemBindingContext);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            holder.ItemView.Click += (s, e) =>
            {
                SetAnimation(holder.ItemView);
            };
        }

        void SetAnimation(View viewToAnimate)
        {
            ScaleAnimation anim = new ScaleAnimation(0.0f, 1.0f, 0.0f, 1.0f, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f);
            anim.Duration = 2000;
            viewToAnimate.StartAnimation(anim);
        }
    }
    public class MyViewHolder1 : MvxRecyclerViewHolder
    {
        // describe our view holder of one item layout of recycler view
        TextView title;
        ImageView image;

        public MyViewHolder1(View itemView, IMvxAndroidBindingContext context)
        : base(itemView, context)
        {
            this.title = itemView.FindViewById<TextView>(Resource.Id.name1);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyViewHolder1, FoodRecyclerViewModel>();
                //  set.Bind(this.title).To(x => x.Details);
                //set.Apply();
            });
        }

    }


}





