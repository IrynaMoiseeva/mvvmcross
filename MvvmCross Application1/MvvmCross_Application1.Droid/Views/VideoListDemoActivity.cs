﻿using System;
using System.Collections.Generic;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Youtube.Player;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.ViewModels;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using MvvmCross.Droid.Views.Attributes;
using Android.Support.V4.App;
using MvvmCross.Droid.Views.Fragments;

namespace MvvmCross_Application1.Droid.Views
{
    namespace YouTubePlayerSample
    {

        // A sample Activity showing how to manage multiple YouTubeThumbnailViews in an adapter for display
        // in a List. When the list items are clicked, the video is played by using a YouTubePlayerFragment.
        // 
        // The demo supports custom fullscreen and transitioning between portrait and landscape without
        // rebuffering.
        [Activity(//MainLauncher = true,
             Theme = "@style/MyTheme.Base")]
        [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
        [Register("MvvmCross_Application1.Droid.Views.PlayVideoFragment")]

        public class PlayVideoFragment : MvxFragment<PlayVideoViewModel>,
             YouTubeThumbnailView.IOnInitializedListener,
             IYouTubeThumbnailLoaderOnThumbnailLoadedListener,
             IYouTubePlayerOnFullscreenListener, NavigationView.IOnNavigationItemSelectedListener
        {
            FragmentActivity mContext;
            public void onAttach(Activity activity)
            {
                base.OnAttach(activity);

                //  if (activity instanceof FragmentActivity) {
                mContext = (FragmentActivity)activity;
            }

            public bool OnNavigationItemSelected(IMenuItem menuItem)
            {
                throw new NotImplementedException();
            }
            public PlayVideoFragment()
            {
                thumbnailViewToLoaderMap = new Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader>();
            }
            public PlayVideoViewModel ViewModel
            {
                get { return base.ViewModel; }
                set { base.ViewModel = value; }
            }


            // The duration of the animation sliding up the video in portrait.
            private const int AnimationDuration = 300;
            // The padding between the video list and the video in landscape orientation.
            private const int LandscapeVideoPadding = 5;
            public const int PlayActivityRequestCode = 42;
            // The request code when calling startActivityForResult to recover from an API service error.
            private const int RecoveryDialogRequest = 1;
            private const String PlaylistId = "PLFEgnf4tmQe_L3xlmtFwX8Qm5czqwCcVi";//"ECAE6B03CA849AD332";
            private DrawerLayout mDrawerlayout;
            private TextView text;
            private View videoBox;
            private View closeButton;
            private MvxListView listView;
            private bool isFullscreen;
            private readonly Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader> thumbnailViewToLoaderMap;

            private MyAdapter listadapter;

            private YouTubeThumbnailView thumbnail_channel;
            private IYouTubeThumbnailLoader thumbnailLoader;

           
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = this.BindingInflate(Resource.Layout.video_list_demo, null);
                ToggleButton togglebutton = view.FindViewById<ToggleButton>(Resource.Id.FavoriteButton);

                //  base.OnCreate(savedInstanceState);

                //  SetContentView(Resource.Layout.video_list_demo);

                /*  var toolbar1 = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                  SetSupportActionBar(toolbar1);
                  SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                  SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.menu_home);

                  mDrawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                  mtoogle = new ActionBarDrawerToggle(this, mDrawerlayout, toolbar1, Resource.String.open, Resource.String.close);

                  mDrawerlayout.AddDrawerListener(mtoogle);
                  mtoogle.SyncState();

                  NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.mNavigationView);

                  navigationView.InflateMenu(Resource.Menu.activity_main_drawer);
                  navigationView.SetNavigationItemSelectedListener(this);

                   navigationView = FindViewById<NavigationView>(Resource.Id.mNavigationView);*/
                //  var chan = ViewModel.Channels.ToList();
                //   navigationView.Menu.Add("vvv");*/

                listView = view.FindViewById<MvxListView>(Resource.Id.VideoItems);

                videoBox = view.FindViewById(Resource.Id.video_box);
                closeButton = view.FindViewById(Resource.Id.close_button);

                videoBox.Visibility = ViewStates.Visible; //invisible

                text = view.FindViewById<TextView>(Resource.Id.titletext);

                thumbnail_channel = view.FindViewById<YouTubeThumbnailView>(Resource.Id.thumbnail_channel);
                thumbnail_channel.Initialize(DeveloperKey.Key, this);

                listadapter = new MyAdapter(view.Context, (IMvxAndroidBindingContext)BindingContext); ;
                listView.Adapter = listadapter;

                var set = this.CreateBindingSet<PlayVideoFragment, PlayVideoViewModel>();

                set.Bind(this.listView).For(x => x.ItemsSource).To(x => x.YoutubeItems);

                set.Apply();

                return view;
            }

            private void listView_ItemClick(object sender, int e)
            {
                int photoNum = e;
                // ViewModel.ChooseChannel(photoNum);
            }


            void YouTubeThumbnailView.IOnInitializedListener.OnInitializationFailure(YouTubeThumbnailView view, YouTubeInitializationResult result)
            {
                view.SetImageResource(Resource.Drawable.cart1);// no_thumbnail
            }

            void YouTubeThumbnailView.IOnInitializedListener.OnInitializationSuccess(YouTubeThumbnailView view, IYouTubeThumbnailLoader loader)
            {

                this.thumbnailLoader = loader;
                thumbnailLoader.SetOnThumbnailLoadedListener(this);
                thumbnailLoader.SetPlaylist(PlaylistId);


            }
            public override void OnResume()
            {
                base.OnResume();

            }
            public override void OnViewCreated(View view, Bundle savedInstanceState)
            {
                base.OnViewCreated(view, savedInstanceState);

            }
            void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailLoaded(YouTubeThumbnailView thumbnail, string videoId)
            {
                
            }
            private void MaybeStartDemo()
            {

                thumbnailLoader.SetPlaylist(PlaylistId); // loading the first thumbnail will kick off demo

            }

            void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailError(YouTubeThumbnailView view, YouTubeThumbnailLoaderErrorReason errorReason)
            {
                view.SetImageResource(Resource.Drawable.cart1);//no_thumbnail
            }

            public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
            {
                base.OnConfigurationChanged(newConfig);
                ///Layout();
            }


            void IYouTubePlayerOnFullscreenListener.OnFullscreen(bool isFullscreen)
            {
                this.isFullscreen = isFullscreen;
                //Layout();
            }




        }

        public class MyAdapter : MvxAdapter,
        YouTubeThumbnailView.IOnInitializedListener,
        IYouTubeThumbnailLoaderOnThumbnailLoadedListener
        {
            private Context mcon;
            private readonly List<View> entryViews;
            private readonly Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader> thumbnailViewToLoaderMap;
            private readonly LayoutInflater inflater;
            public MyAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
            {
                mcon = context;
                entryViews = new List<View>();
                thumbnailViewToLoaderMap = new Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader>();
                inflater = LayoutInflater.From(context);

            }


            

            protected override View GetBindableView(View convertView, object source, ViewGroup parent, int templateId)
            {
                if (convertView == null)
                {
                     convertView = inflater.Inflate(Resource.Layout.video_list_item, parent, false);
                }
                var video = source as YoutubeItem;

                var title = convertView.FindViewById<TextView>(Resource.Id.titletext);
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

                togglebutton.Click += (sender, args) =>
                {
                    if (togglebutton.Checked)
                        video.Check();
                    else
                        video.UnCheck();

                };

              
                return convertView;
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
                thumbnailViewToLoaderMap.Add(view, loader);
                view.SetImageResource(Resource.Drawable.cart1);//loading_thumbnail
                var videoId = (string)view.Tag;
                loader.SetVideo(videoId);
            }

            void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailError(YouTubeThumbnailView view, YouTubeThumbnailLoaderErrorReason errorReason)
            {
                view.SetImageResource(Resource.Drawable.cart1);//no_thumbnail
            }

            void IYouTubeThumbnailLoaderOnThumbnailLoadedListener.OnThumbnailLoaded(YouTubeThumbnailView view, string videoId)
            {
            }
        }
    }
}