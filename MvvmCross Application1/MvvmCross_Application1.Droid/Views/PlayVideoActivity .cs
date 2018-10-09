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
    class PlayVideoActivity : YouTubeBaseActivity
    {

        
        private const int StartStandalonePlayerRequest = 1;
        private const int ResolveServiceMissingRequest = 2;
        public const string ExtraUrlKey = "ExtraUrlKey";
        private string VideoId;//="cdgQpa1pUUE";
        private const string PlaylistId = "7E952A67F31C58A3";
        private static readonly string[] VideoIds = { "cdgQpa1pUUE", "8aCYZ3gXfy8", "zMabEyrtPRg" };

        private Button playVideoButton;
        private Button playPlaylistButton;
        private Button playVideoListButton;

        private EditText startIndexEditText;
        private EditText startTimeEditText;
        private CheckBox autoplayCheckBox;
        private CheckBox lightboxModeCheckBox;

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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = Intent;
            VideoId  = intent?.GetStringExtra(ExtraUrlKey);

            SetContentView(Resource.Layout.activity_video_fullscreen);

            playVideoButton = FindViewById<Button>(Resource.Id.start_video_button);

            //   var set = this.CreateBindingSet<PlayVideoActivity, PlayVideoViewModel>();

            //  set.Bind(this).For(v => v.VideoUrl).To(vm => vm.VideoUrl).OneWay();

            // set.Apply();
            /*  playPlaylistButton = FindViewById<Button>(Resource.Id.start_playlist_button);
              playVideoListButton = FindViewById<Button>(Resource.Id.start_video_list_button);
              startIndexEditText = FindViewById<EditText>(Resource.Id.start_index_text);
              startTimeEditText = FindViewById<EditText>(Resource.Id.start_time_text);
              autoplayCheckBox = FindViewById<CheckBox>(Resource.Id.autoplay_checkbox);
              lightboxModeCheckBox = FindViewById<CheckBox>(Resource.Id.lightbox_checkbox);*/

            playVideoButton.Click += OnClick;
            //playPlaylistButton.Click += OnClick;
            //playVideoListButton.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            // int startIndex = ParseInt(startIndexEditText.Text, 0);
            //int startTimeMillis = ParseInt(startTimeEditText.Text, 0) * 1000;
            //bool autoplay = autoplayCheckBox.Checked;
            //bool lightboxMode = lightboxModeCheckBox.Checked;

            Intent intent = null;
            if (sender == playVideoButton)
            {
                intent = YouTubeStandalonePlayer.CreateVideoIntent(this, DeveloperKey.Key, VideoId);// startTimeMillis, autoplay, lightboxMode);
            }
            else if (sender == playPlaylistButton)
            {
                // intent = YouTubeStandalonePlayer.CreatePlaylistIntent(this, DeveloperKey.Key, PlaylistId, startIndex, startTimeMillis, autoplay, lightboxMode);
            }
            else if (sender == playVideoListButton)
            {
                //      intent = YouTubeStandalonePlayer.CreateVideosIntent(this, DeveloperKey.Key, VideoIds, startIndex, startTimeMillis, autoplay, lightboxMode);
            }

            if (intent != null)
            {
                if (CanResolveIntent(intent))
                {
                    StartActivityForResult(intent, StartStandalonePlayerRequest);
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
            base.OnActivityResult(requestCode, resultCode, data);

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
    }
}