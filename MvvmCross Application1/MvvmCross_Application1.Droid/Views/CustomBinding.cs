using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Youtube.Player;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace MvvmCross_Application1.Droid.Views
{
    public class MyCustomBinding: //MvxTargetBinding<YouTubeThumbnailView, Tag>
       // MvxPropertyInfoTargetBinding<YouTubeThumbnailView>
    MvxPropertyInfoTargetBinding<YouTubeThumbnailView>
    {
        public MyCustomBinding(object target, PropertyInfo targetPropertyInfo)
        : base(target, targetPropertyInfo)
        {
            var e = 7;
        }
        // describes how to set MyProperty on MyView
        protected override void SetValueImpl(object target, object value)
        {
            var view = target as YouTubeThumbnailView;
            if (view == null) return;

            view.Tag = (string)value;
           
        }
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
      

        /* private readonly TextView _textView;

         public MyCustomBinding(TextView textView)
         {
             _textView = textView;
         }

         public override void SetValue(object value)
         {
             var colorValue = (Color)value;
             _textView.SetTextColor(colorValue);
         }

         public override Type TargetType
         {
             get { return typeof(Color); }
         }

         public override MvxBindingMode DefaultMode
         {
             get { return MvxBindingMode.OneWay; }
         }*/
    }
}