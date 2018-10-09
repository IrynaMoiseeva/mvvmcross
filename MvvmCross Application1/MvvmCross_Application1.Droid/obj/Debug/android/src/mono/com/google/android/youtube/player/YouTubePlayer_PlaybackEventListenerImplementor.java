package mono.com.google.android.youtube.player;


public class YouTubePlayer_PlaybackEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.youtube.player.YouTubePlayer.PlaybackEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onBuffering:(Z)V:GetOnBuffering_ZHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onPaused:()V:GetOnPausedHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onPlaying:()V:GetOnPlayingHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onSeekTo:(I)V:GetOnSeekTo_IHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onStopped:()V:GetOnStoppedHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerImplementor, Naxam.YoutubePlayerApi.Droid, Version=1.2.2.1, Culture=neutral, PublicKeyToken=null", YouTubePlayer_PlaybackEventListenerImplementor.class, __md_methods);
	}


	public YouTubePlayer_PlaybackEventListenerImplementor ()
	{
		super ();
		if (getClass () == YouTubePlayer_PlaybackEventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Youtube.Player.IYouTubePlayerPlaybackEventListenerImplementor, Naxam.YoutubePlayerApi.Droid, Version=1.2.2.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onBuffering (boolean p0)
	{
		n_onBuffering (p0);
	}

	private native void n_onBuffering (boolean p0);


	public void onPaused ()
	{
		n_onPaused ();
	}

	private native void n_onPaused ();


	public void onPlaying ()
	{
		n_onPlaying ();
	}

	private native void n_onPlaying ();


	public void onSeekTo (int p0)
	{
		n_onSeekTo (p0);
	}

	private native void n_onSeekTo (int p0);


	public void onStopped ()
	{
		n_onStopped ();
	}

	private native void n_onStopped ();

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
