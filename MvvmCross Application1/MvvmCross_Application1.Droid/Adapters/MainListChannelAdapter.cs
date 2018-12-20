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
        public MvxViewModel ViewModel { get; set; }

        public View View;
        public MainListChannelAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {

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

            }


        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MenuItemViewHolder vh = holder as MenuItemViewHolder;
            var packageName = Application.Context.PackageName.ToString();
            Channels mchannel = (GetItem(position)) as Channels;
            vh.Caption.Text = mchannel.Title;

            vh.Caption.Click += (s, e) =>
             {
                 (ViewModel as MainViewModel).ChooseChannel(mchannel.PlayListId);
                 OnClick(mchannel.PlayListId);
             };

        }

    }
}
