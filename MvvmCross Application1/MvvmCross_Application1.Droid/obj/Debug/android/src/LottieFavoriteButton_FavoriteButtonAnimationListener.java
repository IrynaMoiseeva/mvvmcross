
public class LottieFavoriteButton_FavoriteButtonAnimationListener
	extends android.animation.AnimatorListenerAdapter
	implements
		mono.android.IGCUserPeer,
		android.animation.ValueAnimator.AnimatorUpdateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationEnd:(Landroid/animation/Animator;)V:GetOnAnimationEnd_Landroid_animation_Animator_Handler\n" +
			"n_onAnimationUpdate:(Landroid/animation/ValueAnimator;)V:GetOnAnimationUpdate_Landroid_animation_ValueAnimator_Handler:Android.Animation.ValueAnimator/IAnimatorUpdateListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Controls.LottieFavoriteButton+FavoriteButtonAnimationListener, MvvmCross_Application1.Droid", LottieFavoriteButton_FavoriteButtonAnimationListener.class, __md_methods);
	}


	public LottieFavoriteButton_FavoriteButtonAnimationListener ()
	{
		super ();
		if (getClass () == LottieFavoriteButton_FavoriteButtonAnimationListener.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Controls.LottieFavoriteButton+FavoriteButtonAnimationListener, MvvmCross_Application1.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnimationEnd (android.animation.Animator p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.animation.Animator p0);


	public void onAnimationUpdate (android.animation.ValueAnimator p0)
	{
		n_onAnimationUpdate (p0);
	}

	private native void n_onAnimationUpdate (android.animation.ValueAnimator p0);

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
