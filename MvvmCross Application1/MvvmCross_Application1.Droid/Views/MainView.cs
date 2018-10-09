using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross.Droid.Views;
using MvvmCross_Application1.Core.ViewModels;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V4;

namespace MvvmCross_Application1.Droid.Views

{// @style/MyTheme
    [Activity(Label = "Activity1", MainLauncher = true, Theme = "@style/MyTheme.Base")]
    public class MainView : MvxAppCompatActivity<MainViewModel>, NavigationView.IOnNavigationItemSelectedListener

    {

        private FragmentManager _fragmentManager;
        private DrawerLayout mDrawerlayout;
        private NavigationView navigationView;
        ActionBarDrawerToggle mtoogle;

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
            mtoogle = new ActionBarDrawerToggle(this, mDrawerlayout, toolbar1, Resource.String.open, Resource.String.close);

            mDrawerlayout.AddDrawerListener(mtoogle);
            mtoogle.SyncState();
            string[] ids = new string[] { "Resource.Drawable.peppa", "Resource.Drawable.peppa", "Resource.Drawable.peppa" };

            navigationView = FindViewById<NavigationView>(Resource.Id.mNavigationView);
            var chan = ViewModel.Channels.ToList();
            for (int i = 0; i < chan.Count(); i++)
            {
                var t=chan[i].Id;
                var u = Int32.Parse(ids[i]);
                navigationView.Menu.Add(1, t,t, chan[i].Title.ToString()).SetIcon(u);
                //GetDrawable
                    
               


            }



            // navigationView.InflateMenu(Resource.Menu.activity_main_drawer);
            // navigationView.Menu.Add("vvv");
            navigationView.SetNavigationItemSelectedListener(this);
            ViewModel.SomeMethod();

            //var fragment = new PlayVideoFragment();
            //  SupportFragmentManager.BeginTransaction().Add()
            // .Add(Resource.Id.content_frame, fragment)
            //  .Commit();




        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            // navigationView.InflateMenu(Resource.Menu.nav_menu); //Navigation Drawer Layout Menu Creation  
            // MenuInflater.Inflate(Resource.Menu.popUp_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnPrepareOptionsMenu(IMenu menu)
        {

            var chan = ViewModel.Channels.ToList();

            //    navigationView.Menu.Add(chan[1].PlayListId.ToString());
            // MenuInflater.Inflate(Resource.Menu.options_menu, menu);
            //   IMenuItem menuItem = menu.FindItem(Resource.Id.cart_item);
            int cart_count = 10;
            // menuItem.SetIcon(Converter.ConvertLayoutToImage(this, cart_count, Resource.Drawable.cart1));*/
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            
            return false;
        }

       

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
                ViewModel.ChooseChannel(menuItem.ItemId);
          
            return true;
        }
    }
    public class Converter
    {



        public static Drawable ConvertLayoutToImage(Context mContext, int count, int drawableId)
        {
            LayoutInflater inflater = LayoutInflater.From(mContext);
            View view = inflater.Inflate(Resource.Layout.cart, null);
            ImageView b = (ImageView)view.FindViewById(Resource.Id.icon_badge);
            b.SetImageResource(drawableId);


            TextView textView = (TextView)view.FindViewById(Resource.Id.badge_notification_1);
            textView.Text = "12";//count.ToString();

            view.Measure(View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified),
                      View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified));
            view.Layout(0, 0, view.MeasuredWidth, view.MeasuredHeight);

            view.DrawingCacheEnabled = true;
            view.DrawingCacheQuality = DrawingCacheQuality.High;//view.DrawingCacheEnabled=false;

            //view.BuildDrawingCache();


            Bitmap bitmap = Bitmap.CreateBitmap(view.GetDrawingCache(true));
            Bitmap resized = Bitmap.CreateScaledBitmap(bitmap, (int)(bitmap.Width * 0.8), (int)(bitmap.Height * 0.8), false);


            return new BitmapDrawable(mContext.Resources, resized);
        }
    }

}