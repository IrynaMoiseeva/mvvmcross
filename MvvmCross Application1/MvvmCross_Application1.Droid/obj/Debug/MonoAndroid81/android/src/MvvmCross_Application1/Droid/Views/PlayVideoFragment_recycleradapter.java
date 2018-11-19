package MvvmCross_Application1.Droid.Views;


public class PlayVideoFragment_recycleradapter
	extends mvvmcross.droid.support.v7.recyclerview.MvxRecyclerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateViewHolder:(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;:GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.PlayVideoFragment+recycleradapter, MvvmCross_Application1.Droid", PlayVideoFragment_recycleradapter.class, __md_methods);
	}


	public PlayVideoFragment_recycleradapter ()
	{
		super ();
		if (getClass () == PlayVideoFragment_recycleradapter.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.PlayVideoFragment+recycleradapter, MvvmCross_Application1.Droid", "", this, new java.lang.Object[] {  });
	}


	public android.support.v7.widget.RecyclerView.ViewHolder onCreateViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateViewHolder (p0, p1);
	}

	private native android.support.v7.widget.RecyclerView.ViewHolder n_onCreateViewHolder (android.view.ViewGroup p0, int p1);

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
