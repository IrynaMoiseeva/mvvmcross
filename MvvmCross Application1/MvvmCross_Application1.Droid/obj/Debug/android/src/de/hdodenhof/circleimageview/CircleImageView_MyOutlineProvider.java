package de.hdodenhof.circleimageview;


@android.support.annotation.RequiresApi(
api = 21)
public class CircleImageView_MyOutlineProvider
	extends android.view.ViewOutlineProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOutline:(Landroid/view/View;Landroid/graphics/Outline;)V:GetGetOutline_Landroid_view_View_Landroid_graphics_Outline_Handler\n" +
			"";
		mono.android.Runtime.register ("DE.Hdodenhof.CircleImageView.CircleImageView+MyOutlineProvider, CircleImageView", CircleImageView_MyOutlineProvider.class, __md_methods);
	}


	public CircleImageView_MyOutlineProvider ()
	{
		super ();
		if (getClass () == CircleImageView_MyOutlineProvider.class)
			mono.android.TypeManager.Activate ("DE.Hdodenhof.CircleImageView.CircleImageView+MyOutlineProvider, CircleImageView", "", this, new java.lang.Object[] {  });
	}

	public CircleImageView_MyOutlineProvider (de.hdodenhof.circleimageview.CircleImageView p0)
	{
		super ();
		if (getClass () == CircleImageView_MyOutlineProvider.class)
			mono.android.TypeManager.Activate ("DE.Hdodenhof.CircleImageView.CircleImageView+MyOutlineProvider, CircleImageView", "DE.Hdodenhof.CircleImageView.CircleImageView, CircleImageView", this, new java.lang.Object[] { p0 });
	}


	public void getOutline (android.view.View p0, android.graphics.Outline p1)
	{
		n_getOutline (p0, p1);
	}

	private native void n_getOutline (android.view.View p0, android.graphics.Outline p1);

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
