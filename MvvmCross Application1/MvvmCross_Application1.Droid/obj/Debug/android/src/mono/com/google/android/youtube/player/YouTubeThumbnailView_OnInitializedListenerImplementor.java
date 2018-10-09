package mono.com.google.android.youtube.player;


public class YouTubeThumbnailView_OnInitializedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.youtube.player.YouTubeThumbnailView.OnInitializedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInitializationFailure:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeInitializationResult;)V:GetOnInitializationFailure_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeInitializationResult_Handler:Com.Google.Android.Youtube.Player.YouTubeThumbnailView/IOnInitializedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onInitializationSuccess:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeThumbnailLoader;)V:GetOnInitializationSuccess_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeThumbnailLoader_Handler:Com.Google.Android.Youtube.Player.YouTubeThumbnailView/IOnInitializedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Youtube.Player.YouTubeThumbnailView+IOnInitializedListenerImplementor, Naxam.YoutubePlayerApi.Droid, Version=1.2.2.1, Culture=neutral, PublicKeyToken=null", YouTubeThumbnailView_OnInitializedListenerImplementor.class, __md_methods);
	}


	public YouTubeThumbnailView_OnInitializedListenerImplementor ()
	{
		super ();
		if (getClass () == YouTubeThumbnailView_OnInitializedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Youtube.Player.YouTubeThumbnailView+IOnInitializedListenerImplementor, Naxam.YoutubePlayerApi.Droid, Version=1.2.2.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onInitializationFailure (com.google.android.youtube.player.YouTubeThumbnailView p0, com.google.android.youtube.player.YouTubeInitializationResult p1)
	{
		n_onInitializationFailure (p0, p1);
	}

	private native void n_onInitializationFailure (com.google.android.youtube.player.YouTubeThumbnailView p0, com.google.android.youtube.player.YouTubeInitializationResult p1);


	public void onInitializationSuccess (com.google.android.youtube.player.YouTubeThumbnailView p0, com.google.android.youtube.player.YouTubeThumbnailLoader p1)
	{
		n_onInitializationSuccess (p0, p1);
	}

	private native void n_onInitializationSuccess (com.google.android.youtube.player.YouTubeThumbnailView p0, com.google.android.youtube.player.YouTubeThumbnailLoader p1);

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
