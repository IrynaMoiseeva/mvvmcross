using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross_Application1.Core.ViewModels;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;
using MvvmCross_Application1.Droid.Adapters;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.BindingContext;
using System;
using System.Net.Http;

namespace MvvmCross_Application1.Droid.Views

{// @style/MyTheme
    [Activity(Label = "Baby Channel", MainLauncher = true, Theme = "@style/MyTheme.Base")]
    public class MainView : MvxAppCompatActivity<MainViewModel>//, NavigationView.IOnNavigationItemSelectedListener

    {
        private DrawerLayout mDrawerlayout;
        private NavigationView navigationView;
        ActionBarDrawerToggle mtoogle;
        MvxRecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        MainListChannelAdapter mAdapter;

        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainView);

            var toolbar1 = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar1);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_plus);

            mDrawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mtoogle = new CustomActionBarDrawerToggle(this, ViewModel, mDrawerlayout, toolbar1, Resource.String.open, Resource.String.close);
            
            
                   mDrawerlayout.AddDrawerListener(mtoogle);

            mtoogle.SyncState();
            string[] ids = new string[] { "Resource.Drawable.peppa", "Resource.Drawable.peppa", "Resource.Drawable.peppa" };
            int id = Resources.GetIdentifier("peppa", "drawable", PackageName);

            //navigationView = FindViewById<NavigationView>(Resource.Id.mNavigationView);

            mRecycleView = FindViewById<MvxRecyclerView>(Resource.Id.menuitems);

            mAdapter = new MainListChannelAdapter((IMvxAndroidBindingContext)this.BindingContext);
            mAdapter.ItemClick += MAdapter_ItemClick;

            mRecycleView.Adapter = mAdapter;
            mAdapter.ViewModel = ViewModel;

        }

    
        private void MAdapter_ItemClick(object sender, string e)
        {

            mDrawerlayout.CloseDrawer(GravityCompat.Start);

        }
       


        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            //navigationView.InflateMenu(Resource.Menu.options_menu); //Navigation Drawer Layout Menu Creation  
             MenuInflater.Inflate(Resource.Menu.options_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId== Resource.Id.favourites)
                    {
                        ViewModel.ChooseFavourites();
            }

            if (item.ItemId == Resource.Id.settings )
            {
                ViewModel.ChooseSettings();
            }

            return base.OnOptionsItemSelected(item);
        }


    }


}