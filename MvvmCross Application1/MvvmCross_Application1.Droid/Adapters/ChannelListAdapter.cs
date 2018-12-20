using System;
using System.Net;
using System.Runtime.Remoting.Contexts;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.ViewModels;

namespace MvvmCross_Application1.Droid.Adapters
{
    public class ChannelListAdapter: MvxRecyclerAdapter
    {

        public MvxViewModel ViewModel { get; set; }
        public Boolean AllChecked { get; set; } // for removed tooglebutton
        public Context mcon { get; set; }
        public View View;

        public ChannelListAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {

        }



        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);


            View = this.InflateViewForHolder(parent, viewType, itemBindingContext);

            return new MyViewHolder(View, itemBindingContext);
        }

        public static Bitmap GetBitmapFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }


        public class MyViewHolder : MvxRecyclerViewHolder
        {

            public TextView title;
           
            public Button removeButton;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)

            {
                title = itemView.FindViewById<TextView>(Resource.Id.title);
                removeButton = itemView.FindViewById<Button>(Resource.Id.RemoveButton);

                //imageView = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);


            }
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

           // YoutubeItem video = (GetItem(position)) as YoutubeItem;
            Channels channel= (GetItem(position)) as Channels;

            MyViewHolder myHolder = holder as MyViewHolder;

            myHolder.title.Text = channel.Title;

            myHolder.removeButton.Click += delegate
            {
                ((SettingsViewModel)ViewModel).entity = channel;

                ((SettingsViewModel)ViewModel).RemoveCommand.Execute();

            };

        }

    }
}
