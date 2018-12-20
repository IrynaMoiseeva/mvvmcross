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
    [Register("MvvmCross_Application1.Droid.Views.SettingsFragment")]
    public class SettingsFragment: MvxFragment<SettingsViewModel>
    {
        public ChannelListAdapter adapter;
        public SettingsViewModel ViewModel
        {
            get { return base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public override void OnResume()
        {
            base.OnResume();
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.settings_list, null);


            adapter = new ChannelListAdapter((IMvxAndroidBindingContext)this.BindingContext);
            MvxRecyclerView m = view.FindViewById<MvxRecyclerView>(Resource.Id.rvItems);
            adapter.NotifyDataSetChanged();
            m.Adapter = adapter;
            adapter.ViewModel = ViewModel;

            FloatingActionButton AddButton = view.FindViewById<FloatingActionButton>(Resource.Id.Add);
            AddButton.Click += (s, e) =>
            {
                 ViewModel.AddNewChannel();
                // move to new form to input url and title forchannel
            };
            return view;
        }
    }
        

}
