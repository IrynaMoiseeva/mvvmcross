using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MvvmCross_Application1.Droid.Views
{
    
        public static class DeveloperKey
        {
            /// <summary>
            /// Please replace this with a valid API key which is enabled for the
            /// YouTube Data API v3 service. Go to the Google Developers Console
            /// to register a new developer key: 
            ///     https://console.developers.google.com/
            /// </summary>
            /// https://www.thewissen.io/embedding-youtube-feed-xamarin-forms/
            public const string Key = "AIzaSyAqB61v3YI6H7Q-jhx3HVSPNBDvX-dr_yY";

            static DeveloperKey()
            {
                if (Key == "YOUR_API_KEY")
                {
                    throw new Exception("You API key has not been set.");
                }
            }
        }

    }
