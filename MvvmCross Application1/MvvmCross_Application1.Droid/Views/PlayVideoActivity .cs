using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Extractor;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2.UI;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Util;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross_Application1.Core.ViewModels;
using Uri = Android.Net.Uri;
using MvvmCross.Droid.Views.Attributes;

using MvvmCross.Droid.Views;
using Com.Google.Android.Youtube.Player;

namespace MvvmCross_Application1.Droid.Views
{

    [Activity(Label = "Menu3")]
    //      Label = "videolist_demo_name")]
    class PlayVideoActivity : YouTubeBaseActivity, IYouTubePlayerOnInitializedListener
    {

        
        private const int StartStandalonePlayerRequest = 1;
        private const int ResolveServiceMissingRequest = 2;
        public const string ExtraUrlKey = "ExtraUrlKey";
        private string VideoId;
        YouTubePlayerView player;
        private Button playVideoButton;

        private EditText startIndexEditText;
        private EditText startTimeEditText;
        private CheckBox autoplayCheckBox;
        private CheckBox lightboxModeCheckBox;
        IYouTubePlayer player1;
        string videoUrl;
        public string VideoUrl
        {
            get { return videoUrl; }
            set
            {
                videoUrl = value;
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

            }
        }



        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            
            player1.SetFullscreen(false);
           
            FinishActivity(0);
            Finish();
            return true;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = Intent;
            VideoId  = intent?.GetStringExtra(ExtraUrlKey);

            SetContentView(Resource.Layout.activity_video_fullscreen);
             player= FindViewById<YouTubePlayerView>(Resource.Id.youtube_view);
            player.Initialize(DeveloperKey.Key,this);

        }

        private void OnClick(object sender, EventArgs e)
        {

            Intent intent = null;
            if (sender == playVideoButton)
            {
                intent = YouTubeStandalonePlayer.CreateVideoIntent(this, DeveloperKey.Key, VideoId,0,false,false);// startTimeMillis, autoplay, lightboxMode);
            }

            if (intent != null)
            {
                if (CanResolveIntent(intent))
                {
                   // StartActivityForResult(intent, StartStandalonePlayerRequest);
                  
                }
                else
                {
                    // Could not resolve the intent - must need to install or update the YouTube API service.
                    YouTubeInitializationResult.ServiceMissing.GetErrorDialog(this, ResolveServiceMissingRequest).Show();
                }
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
         //   base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == StartStandalonePlayerRequest && resultCode != Result.Ok)
            {
                var errorReason = YouTubeStandalonePlayer.GetReturnedInitializationResult(data);
                if (errorReason.IsUserRecoverableError)
                {
                    errorReason.GetErrorDialog(this, 0).Show();
                }
                else
                {
                    //  var errorMessage = string.Format(GetString("fffff"), errorReason);
                    //Toast.MakeText(this, errorMessage, ToastLength.Long).Show();
                }
            }
          
            
        }

        private bool CanResolveIntent(Intent intent)
        {
            var resolveInfo = PackageManager.QueryIntentActivities(intent, 0);
            return resolveInfo != null && resolveInfo.Count > 0;
        }

        private int ParseInt(String text, int defaultValue)
        {
            if (int.TryParse(text, out int result))
            {
                return result;
            }
            return defaultValue;
        }

        public void OnInitializationFailure(IYouTubePlayerProvider p0, YouTubeInitializationResult p1)
        {
            throw new NotImplementedException();
        }

        public void OnInitializationSuccess(IYouTubePlayerProvider p0, IYouTubePlayer player, bool p2)
        {
            player.CueVideo(VideoId);
            player1 = player;
                
        }
    }
}