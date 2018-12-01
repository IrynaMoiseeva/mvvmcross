package md5317d0fdc1ffc64bc5dd9daf464b159b5;


public class ChannelListAdapter
	extends mvvmcross.droid.support.v7.recyclerview.MvxRecyclerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Adapters.ChannelListAdapter, MvvmCross_Application1.Droid", ChannelListAdapter.class, __md_methods);
	}


	public ChannelListAdapter ()
	{
		super ();
		if (getClass () == ChannelListAdapter.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Adapters.ChannelListAdapter, MvvmCross_Application1.Droid", "", this, new java.lang.Object[] {  });
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
