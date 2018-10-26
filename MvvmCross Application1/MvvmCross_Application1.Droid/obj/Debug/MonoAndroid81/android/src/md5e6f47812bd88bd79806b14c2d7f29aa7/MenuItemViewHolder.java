package md5e6f47812bd88bd79806b14c2d7f29aa7;


public class MenuItemViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Views.MenuItemViewHolder, MvvmCross_Application1.Droid", MenuItemViewHolder.class, __md_methods);
	}


	public MenuItemViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == MenuItemViewHolder.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Views.MenuItemViewHolder, MvvmCross_Application1.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
