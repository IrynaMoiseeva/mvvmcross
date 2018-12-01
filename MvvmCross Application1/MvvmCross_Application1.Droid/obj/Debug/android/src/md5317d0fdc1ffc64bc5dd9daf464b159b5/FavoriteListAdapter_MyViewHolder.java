package md5317d0fdc1ffc64bc5dd9daf464b159b5;


public class FavoriteListAdapter_MyViewHolder
	extends mvvmcross.droid.support.v7.recyclerview.MvxRecyclerViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Adapters.FavoriteListAdapter+MyViewHolder, MvvmCross_Application1.Droid", FavoriteListAdapter_MyViewHolder.class, __md_methods);
	}


	public FavoriteListAdapter_MyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == FavoriteListAdapter_MyViewHolder.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Adapters.FavoriteListAdapter+MyViewHolder, MvvmCross_Application1.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
