package md54eafeed878b92cb2b3abae2c153f3459;


public class MyViewHolder1
	extends mvvmcross.droid.support.v7.recyclerview.MvxRecyclerViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.MyViewHolder1, MvvmCross_Application1.Droid", MyViewHolder1.class, __md_methods);
	}


	public MyViewHolder1 (android.view.View p0)
	{
		super (p0);
		if (getClass () == MyViewHolder1.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.MyViewHolder1, MvvmCross_Application1.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
