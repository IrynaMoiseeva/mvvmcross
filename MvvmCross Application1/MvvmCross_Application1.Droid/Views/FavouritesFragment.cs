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
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross_Application1.Core.ViewModels;

namespace MvvmCross_Application1.Droid.Views
{
    [Activity(//MainLauncher = true,
             Theme = "@style/MyTheme.Base")]
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("MvvmCross_Application1.Droid.Views.FavouritesFragment")]
    public class FavouritesFragment : MvxFragment<FavouritesViewModel>
    {
        public recycleradapter adapter;
        public FavouritesViewModel ViewModel
        {
            get { return base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public override void OnResume()
        {
            base.OnResume();
            //adapter.NotifyDataSetChanged();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.favourite_list, null);

           //var  listadapter = new MyAdapter(view.Context, (IMvxAndroidBindingContext)BindingContext);

         /*   listadapter.ToogleIcon= Resource.Drawable.icons8_trash_50;
            listadapter.AllChecked = true;  
            var listView = view.FindViewById<MvxListView>(Resource.Id.VideoList);
            listadapter.ViewModel = ViewModel;
            listView.Adapter = listadapter;*/

            adapter = new recycleradapter((IMvxAndroidBindingContext)this.BindingContext);
            MvxRecyclerView m = view.FindViewById<MvxRecyclerView>(Resource.Id.rvItems);
            //m.NotifyDataSetChanged();
            adapter.NotifyDataSetChanged();
            m.Adapter = adapter;
            
            adapter.AllChecked = true;
            adapter.mcon = Context;
            adapter.ViewModel = ViewModel;
            adapter.ToogleIcon = Resource.Drawable.icons8_trash_50; 

             /*var set1 = this.CreateBindingSet<PlayVideoFragment, PlayVideoViewModel>();
             set1.Bind(adapter).For(x => x.ItemsSource).To(x => x.YoutubeItems);
             set1.Apply();*/
            return view;
        }
    }
}