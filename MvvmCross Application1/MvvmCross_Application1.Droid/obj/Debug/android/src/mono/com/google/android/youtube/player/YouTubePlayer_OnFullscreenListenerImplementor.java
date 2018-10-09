package mono.com.google.android.youtube.player;


public class YouTubePlayer_OnFullscreenListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.youtube.player.YouTubePlayer.OnFullscreenListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFullscreen:(Z)V:GetOnFullscreen_ZHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerOnFullscreenListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Youtube.Player.IYouTubePlayerOnFullscreenListenerImplementor, Naxam.YoutubePlayerApi.Droid, Version=1.2.2.1, Culture=neutral, PublicKeyToken=null", YouTubePlayer_OnFullscreenListenerImplementor.class, __md_methods);
	}


	public YouTubePlayer_OnFullscreenListenerImplementor ()
	{
		super ();
		if (getClass () == YouTubePlayer_OnFullscreenListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Youtube.Player.IYouTubePlayerOnFullscreenListenerImplementor, Naxam.YoutubePlayerApi.Droid, Version=1.2.2.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFullscreen (boolean p0)
	{
		n_onFullscreen (p0);
	}

	private native void n_onFullscreen (boolean p0);

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
