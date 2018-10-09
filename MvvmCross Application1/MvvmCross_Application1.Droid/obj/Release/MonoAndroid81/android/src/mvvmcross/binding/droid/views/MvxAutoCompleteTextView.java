package mvvmcross.binding.droid.views;


public class MvxAutoCompleteTextView
	extends android.widget.AutoCompleteTextView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Binding.Droid.Views.MvxAutoCompleteTextView, MvvmCross.Binding.Droid", MvxAutoCompleteTextView.class, __md_methods);
	}


	public MvxAutoCompleteTextView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MvxAutoCompleteTextView.class)
			mono.android.TypeManager.Activate ("MvvmCross.Binding.Droid.Views.MvxAutoCompleteTextView, MvvmCross.Binding.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MvxAutoCompleteTextView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MvxAutoCompleteTextView.class)
			mono.android.TypeManager.Activate ("MvvmCross.Binding.Droid.Views.MvxAutoCompleteTextView, MvvmCross.Binding.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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
