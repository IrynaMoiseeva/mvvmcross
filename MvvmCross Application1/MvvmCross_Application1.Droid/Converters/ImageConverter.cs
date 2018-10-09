using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace MvvmCross_Application1.Droid.Converters
{
    /*public class ImageConverter : MvxValueConverter<string, int>
    {
        
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var imagefileName = value.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resources).GetField(imagefileName).GetValue(null);
            return id;

        }
    }*/
}