using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross_Application1.Core.ViewModels;
//using Android.Support.V4.App;

using MvvmCross.Binding.Droid.BindingContext;
//using Android.App;
using Android.Support.V4.App;
using Android.App;
using Com.Google.Android.Youtube.Player;

namespace MvvmCross_Application1.Droid.Views
{


    /* public class VideoFragment : YouTubePlayerFragment, IYouTubePlayerOnInitializedListener
     {
         FragmentActivity mContext;
         private IYouTubePlayer player;
         private string videoId;


             public void onAttach(Activity activity)
         {
             base.OnAttach(activity);

            // if (activity instanceof FragmentActivity) {
                 mContext = (FragmentActivity)activity;
           //  }
         }
         public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
         {
             base.OnCreateView(inflater, container, savedInstanceState);
             var view = inflater.Inflate(Resource.Layout.youtube_fragment, null);
             YouTubePlayerFragment youTube = YouTubePlayerFragment.NewInstance();
             //this.BindingInflate(Resource.Layout.youtube_fragment, null);
             Android.App.FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
             fragmentTransaction.Replace(Resource.Id.content_frame, youTube);
             fragmentTransaction.Commit();

             return view;
         }

         public override void OnCreate(Bundle savedInstanceState)
         {
             base.OnCreate(savedInstanceState);


                 Initialize(DeveloperKey.Key, this);
         }

         public override void OnDestroy()
         {
             if (player != null)
             {
                 player.Release();
             }

             base.OnDestroy();
         }

         public void SetVideoId(string videoId)
         {
             if (videoId != null && videoId != this.videoId)
             {
                 this.videoId = "1KhZKNZO8mQ";// videoId;
                if (player != null)
                {
                   player.CueVideo(videoId);
                }
             }
         }

         public void Pause()
         {
             if (player != null)
             {
                 player.Pause();
             }
         }

         void IYouTubePlayerOnInitializedListener.OnInitializationFailure(IYouTubePlayerProvider provider, YouTubeInitializationResult result)
         {
             player = null;
         }

         void IYouTubePlayerOnInitializedListener.OnInitializationSuccess(IYouTubePlayerProvider provider, IYouTubePlayer player, bool restored)
         {
             this.player = player;
             //player.AddFullscreenControlFlag(YouTubePlayer.FullscreenFlagCustomLayout);
            //player.SetOnFullscreenListener((VideoListDemoActivity)Activity);
             player.SetFullscreen(false);
             // if (!restored && videoId != null)
             // {
             player.CueVideo("cdgQpa1pUUE");
            // player.Play();
             //}
         }

         public static VideoFragment Create() => new VideoFragment();
     }

     public class VideoEntry : Java.Lang.Object
     {
         public VideoEntry(string text, string videoId)
         {
             Text = text;
             VideoId = videoId;
         }

         public string Text { get; private set; }
         public string VideoId { get; private set; }


         // Utility methods for layouting.

         private int DpToPx(int dp)
         {

             return 1;
             //  return (int)(dp * Resources.DisplayMetrics.Density + 0.5f);
         }

         private static void SetLayoutSize(View view, int width, int height)
         {
             var param = view.LayoutParameters;
             param.Width = width;
             param.Height = height;
             view.LayoutParameters = param;
         }

         private static void SetLayoutSizeAndGravity(View view, int width, int height, GravityFlags gravity)
         {
             var param = (FrameLayout.LayoutParams)view.LayoutParameters;
             param.Width = width;
             param.Height = height;
             param.Gravity = gravity;
             view.LayoutParameters = param;
         }

     }*/
}