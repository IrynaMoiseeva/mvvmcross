using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross_Application1.Core.Enums;
using MvvmCross_Application1.Core.ViewModels;


namespace MvvmCross_Application1.Droid.Views
{
    public class PageFragment : Fragment
    {
        const string ARG_PAGE = "ARG_PAGE";
        private int mPage;
        private int pagenum { get; set; }

        public static PageFragment newInstance(int page)
        {

            var args = new Bundle();
            args.PutInt(ARG_PAGE, page);
            var fragment = new PageFragment();
            fragment.Arguments = args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //  mPage = Arguments.GetInt(ARG_PAGE);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FoodRecyclerView, container, false);



            return view;
        }
    }
    public class CustomPagerAdapter : FragmentStatePagerAdapter
    {
        const int PAGE_COUNT = 2;
        private string[] tabTitles = { "Fruits", "Vegetables" };
        readonly Context context;



        public CustomPagerAdapter(FragmentManager fm) : base(fm)
        {
            this.context = context;
        }

        public override int Count
        {
            get { return PAGE_COUNT; }
        }



        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            Type tabpages = typeof(TabPageTypes);
            string[] tabnames = (System.Enum.GetNames(tabpages));
            return CharSequence.ArrayFromStringArray(tabnames)[position];

        }

        public View GetTabView(int position)
        {
           // var tv = (TextView)LayoutInflater.From(context).Inflate(Resource.Layout.custom_tab, null);
            //tv.Text = tabTitles[position];
            return null;
        }

        public override Fragment GetItem(int position)
        {
            
            return PageFragment.newInstance(position + 1);

        }
    }

    
    }
