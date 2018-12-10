using System.Linq;
using Android.App;
using Android.Views;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using System;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Model;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Binding.Droid.BindingContext;
using System.Windows.Input;
using MvvmCross_Application1.Core.ViewModels;

namespace MvvmCross_Application1.Droid.Adapters
{

    public class MainListChannelAdapter : MvxRecyclerAdapter
    {
        public event EventHandler<string> ItemClick;
        //public List<Core.Model.Channels> mchannel;
        public MvxViewModel ViewModel { get; set; }

        public View View;
        public MainListChannelAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {
            var f = 0;
        }


        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);

            View = this.InflateViewForHolder(parent, viewType, itemBindingContext);

            return new MenuItemViewHolder(View, itemBindingContext, OnClick);
            

        }
        private void OnClick(string p)
        {
            ItemClick(this, p);
        }





        public class MenuItemViewHolder : MvxRecyclerViewHolder
    {

        public ImageView Image { get; set; }
        public TextView Caption { get; set; }

        public MenuItemViewHolder(View itemview, IMvxAndroidBindingContext context, Action<string> listener) : base(itemview, context)

        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.image);
                Caption = itemview.FindViewById<TextView>(Resource.Id.textview);
                //itemview.Click += (sender, e) => listener(Position);
                //itemview.SetOnClickListener
              //  itemview.Click += (sender, e) => listener("dff");
                //  itemview.Click += (sender, e) => listener(Position);

            }


        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MenuItemViewHolder vh = holder as MenuItemViewHolder;
            var packageName = Application.Context.PackageName.ToString();
            Channels mchannel = (GetItem(position)) as Channels;
            vh.Caption.Text = mchannel.Title;

            vh.Caption.Click +=(s, e) => 
            { 
                (ViewModel as MainViewModel).ChooseChannel (mchannel.PlayListId); 
                OnClick(mchannel.PlayListId); 
            };


            //vh.Click=

            //!! var  id = (int)typeof(Resource.Drawable).GetField(mchannel[position].Image.ToString()).GetValue(null);


            //!!  vh.Image.SetImageResource(id) ;//Resource.Drawable.peppa);//(mchannel[position].Id);

        }

        /*  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)

      {
              MenuItemViewHolder vh = holder as MenuItemViewHolder;
              var packageName = Application.Context.PackageName.ToString();
              Channels mchannel = (GetItem(position)) as Channels;
              YoutubeItem video = (GetItem(position)) as YoutubeItem;

              MenuItemViewHolder myHolder = holder as MyViewHolder;

          myHolder.title.Text = video.Title;
          myHolder.published_date.Text = video.PublishedAt.ToString();


          Bitmap bbb = GetBitmapFromUrl(video.MediumThumbnailUrl);
          myHolder.imageView.SetImageBitmap(bbb);

          myHolder.imageView.Click += (sender, args) =>
          {
              var intent = new Intent(mcon, typeof(PlayVideoActivity));
              intent.AddFlags(ActivityFlags.NewTask);

              intent.PutExtra(PlayVideoActivity.ExtraUrlKey, video.VideoId);

              mcon.StartActivity(intent);
          };



          myHolder.removeButton.Click += (s, e) =>
          {
              video.UnCheck();
              if (ViewModel != null)
                  ViewModel.Initialize(); // to refresh page  
          };

      }*/



    }
}
