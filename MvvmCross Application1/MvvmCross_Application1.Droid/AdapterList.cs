using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Binding.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Content;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross_Application1.Core.ViewModels;
using static Android.Support.V7.Widget.RecyclerView;

namespace MvvmCross_Application1.Droid
{
    class MyAdapter : MvxRecyclerAdapter
    {

         public MyAdapter( IMvxAndroidBindingContext bindingContext)
                 : base(bindingContext)
         {
         }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)

        {
            Context context = parent.Context;
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
            // create a new view
           LayoutInflater inflater = LayoutInflater.From(context);

            View v = inflater.Inflate(Resource.Layout.Details, parent, false);
            // set the view's size, margins, paddings and layout parameters
            MyViewHolder vh = new MyViewHolder(v, itemBindingContext);
            return vh;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            holder.ItemView.Click += (s, e) =>
            {
                SetAnimation(holder.ItemView);  
            };
        }
        void SetAnimation(View viewToAnimate)
        {
            ScaleAnimation anim = new ScaleAnimation(0.0f, 1.0f, 0.0f, 1.0f, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f);
            anim.Duration = 2000;
            viewToAnimate.StartAnimation(anim);
        }
    }
    public class MyViewHolder : MvxRecyclerViewHolder
    { 
        // describe our view holder of one item layout of recycler view
        TextView title;
        ImageView image;

        public MyViewHolder(View itemView, IMvxAndroidBindingContext context)
        : base(itemView, context)
        {
            this.title = itemView.FindViewById<TextView>(Resource.Id.name1);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyViewHolder, FoodRecyclerViewModel>();
              //  set.Bind(this.title).To(x => x.Details);
                //set.Apply();
            });
        }
        
        }


    }





