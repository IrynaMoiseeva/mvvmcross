using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
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
            string[] ids = new string[] { "Resource.Drawable.peppa", "Resource.Drawable.peppa", "Resource.Drawable.peppa" };
            int id = Resources.GetIdentifier("peppa", "drawable", PackageName);

            navigationView = FindViewById<NavigationView>(Resource.Id.mNavigationView);
            var chan = ViewModel.Channels.ToList();
            
        /*    for (int i = 0; i < chan.Count(); i++)ˆ
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
             MenuInflater.Inflate(Resource.Menu.options_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


       /* public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.options_menu, menu);
          //  //return base.OnPrepareOptionsMenu(menu);
            var chan = ViewModel.Channels.ToList();

            //    navigationView.Menu.Add(chan[1].PlayListId.ToString());
            // MenuInflater.Inflate(Resource.Menu.options_menu, menu);
            //   IMenuItem menuItem = menu.FindItem(Resource.Id.cart_item);
            int cart_count = 10;
            // menuItem.SetIcon(Converter.ConvertLayoutToImage(this, cart_count, Resource.Drawable.cart1));*/
          //  return base.OnPrepareOptionsMenu(menu);
       // }

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
            itemview.Click += (sender, e) => listener(Position);
        }
    }



}