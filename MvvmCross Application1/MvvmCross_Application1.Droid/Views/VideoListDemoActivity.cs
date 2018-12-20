using System;
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
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross_Application1.Droid.Adapters;

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

            private TextView text;
            private View videoBox;
            private View closeButton;

            private bool isFullscreen;
            private readonly Dictionary<YouTubeThumbnailView, IYouTubeThumbnailLoader> thumbnailViewToLoaderMap;

            private YouTubeThumbnailView thumbnail_channel;
            private IYouTubeThumbnailLoader thumbnailLoader;


            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = this.BindingInflate(Resource.Layout.video_list_demo, null);
                // ToggleButton togglebutton = view.FindViewById<ToggleButton>(Resource.Id.FavoriteButton);


                videoBox = view.FindViewById(Resource.Id.video_box);
                closeButton = view.FindViewById(Resource.Id.close_button);

                videoBox.Visibility = ViewStates.Visible; //invisible

                text = view.FindViewById<TextView>(Resource.Id.titletext);

                thumbnail_channel = view.FindViewById<YouTubeThumbnailView>(Resource.Id.thumbnail_channel);
                thumbnail_channel.Initialize(DeveloperKey.Key, this);


                var adapter = new VideoListAdapter((IMvxAndroidBindingContext)this.BindingContext);

                MvxRecyclerView m = view.FindViewById<MvxRecyclerView>(Resource.Id.rvItems);
                m.Adapter = adapter;
                adapter.NotifyDataSetChanged();
                adapter.ViewModel = ViewModel;
                adapter.mcon = Context;
                adapter.ToogleIcon = Resource.Drawable.button_favorite;

                var set1 = this.CreateBindingSet<PlayVideoFragment, PlayVideoViewModel>();
                set1.Bind(adapter).For(x => x.ItemsSource).To(x => x.YoutubeItems);
                set1.Apply();

                return view;
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

            }
        }
    }


}
