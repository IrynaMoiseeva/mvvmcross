using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross_Application1.Core.ViewModels;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;

namespace MvvmCross_Application1.Droid.Views

{// @style/MyTheme
    [Activity(Label = "Baby Channel", MainLauncher = true, Theme = "@style/MyTheme.Base")]
    public class MainView : MvxAppCompatActivity<MainViewModel>, NavigationView.IOnNavigationItemSelectedListener

    {

        private FragmentManager _fragmentManager;
        private DrawerLayout mDrawerlayout;
        private NavigationView navigationView;
        ActionBarDrawerToggle mtoogle;
        Core.Model.Channel channel;
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        ChannelAdapter mAdapter;

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
           // SupportActionBar.menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_plus);

            mDrawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mtoogle = new ActionBarDrawerToggle(this, mDrawerlayout, toolbar1, Resource.String.open, Resource.String.close);
            
            mDrawerlayout.AddDrawerListener(mtoogle);
            
            mtoogle.SyncState();
            //int[] ids = new int[3] {Resource.Drawable.peppa, Resource.Drawable.peppa, Resource.Drawable.peppa };
            string[] ids = new string[] { "Resource.Drawable.peppa", "Resource.Drawable.peppa", "Resource.Drawable.peppa" };
            // GetDrawable(Resource.Drawable.peppa);
            int id = Resources.GetIdentifier("peppa", "drawable", PackageName);
            navigationView = FindViewById<NavigationView>(Resource.Id.mNavigationView);
            var chan = ViewModel.Channels.ToList();
            
        /*    for (int i = 0; i < chan.Count(); i++)
            {
                var t=chan[i].Id;
               // var u = Int32.Parse(ids[i]);
                //navigationView.Menu.Add(1, t, t, chan[i].Title.ToString()).SetIcon(Resource.Drawable.peppa);
              //  navigationView.Menu.Add(1, t, t, chan[i].Title.ToString()).SetIcon(id).SetShowAsAction(ShowAsAction.Always);
              }
            */


            
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.menuitems);
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new ChannelAdapter(chan);
            mAdapter.ItemClick += MAdapter_ItemClick;
            //mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);


            // navigationView.InflateMenu(Resource.Menu.activity_main_drawer);
            // navigationView.Menu.Add("vvv");
            navigationView.SetNavigationItemSelectedListener(this);
            ViewModel.SomeMethod();

            //var fragment = new PlayVideoFragment();
            //  SupportFragmentManager.BeginTransaction().Add()
            // .Add(Resource.Id.content_frame, fragment)
            //  .Commit();




        }
        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum= e ;
            ViewModel.ChooseChannel(photoNum);
            mDrawerlayout.CloseDrawer(GravityCompat.Start);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {

           //navigationView.InflateMenu(Resource.Menu.options_menu); //Navigation Drawer Layout Menu Creation  
            // MenuInflater.Inflate(Resource.Menu.popUp_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.options_menu, menu);
          //  //return base.OnPrepareOptionsMenu(menu);
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
            if (item.ItemId== Resource.Id.favourites)
                    {
                        ViewModel.ChooseFavourites();
                    }
            
            return base.OnOptionsItemSelected(item);
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
                ViewModel.ChooseChannel(menuItem.ItemId);
          
            return true;
        }
    }
    public class NavMenu
    {
        public int Menu { get; set; }
        public string MenuTitle { get; set; }
     //   public string MenuImage { get; set; }
    }
    public class PhotoAlbum
    {
       /* static NavMenu[] menuitem =
        {
            new NavMenu() {mPhotoID = Resource.Drawable.Android1, mCaption = "Ahsan 1"},
            new NavMenu() {mPhotoID = Resource.Drawable.Android2, mCaption = "Ahsan 2"},
            new NavMenu() {mPhotoID = Resource.Drawable.Android3, mCaption = "Ahsan 3"},
          */ 
        };
    public class ChannelAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<Core.Model.Channel> mchannel; 
        public ChannelAdapter(List<Core.Model.Channel> channel)
        {
            mchannel = channel;
        }
        public override int ItemCount => mchannel.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MenuItemViewHolder vh = holder as MenuItemViewHolder;
             var packageName=Application.Context.PackageName.ToString();

           var  id = (int)typeof(Resource.Drawable).GetField(mchannel[position].Image.ToString()).GetValue(null);
            // int id = Resources.GetIdentifier("peppa", "drawable", PackageName);

            vh.Image.SetImageResource(id) ;//Resource.Drawable.peppa);//(mchannel[position].Id);
            
            vh.Caption.Text = mchannel[position].Title.ToString();
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.menuitemview, parent, false);
            MenuItemViewHolder vh = new MenuItemViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int row)
        {
                ItemClick(this, row);
        }
    }

public class MenuItemViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public MenuItemViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.image);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textview);
            itemview.Click += (sender, e) => listener(base.Position);
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