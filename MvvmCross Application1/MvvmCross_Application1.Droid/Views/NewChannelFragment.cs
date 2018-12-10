using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross_Application1.Core.ViewModels;
using MvvmCross_Application1.Droid.Adapters;
using Android.Support.Design.Widget;

namespace MvvmCross_Application1.Droid.Views
{
    [Activity(//MainLauncher = true,
             Theme = "@style/MyTheme.Base")]
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("MvvmCross_Application1.Droid.Views.NewChannelFragment")]
    public class NewChannelFragment : MvxFragment<NewChannelViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.NewChannel, null);
            return view;
        }


    }


}