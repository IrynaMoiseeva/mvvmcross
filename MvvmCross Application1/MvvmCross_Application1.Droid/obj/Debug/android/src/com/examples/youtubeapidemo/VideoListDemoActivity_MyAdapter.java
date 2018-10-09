package com.examples.youtubeapidemo;


public class VideoListDemoActivity_MyAdapter
	extends md542f353d1b1081f7745f0b06ca2e9e57a.MvxAdapter
	implements
		mono.android.IGCUserPeer,
		com.google.android.youtube.player.YouTubeThumbnailView.OnInitializedListener,
		com.google.android.youtube.player.YouTubeThumbnailLoader.OnThumbnailLoadedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"n_onInitializationFailure:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeInitializationResult;)V:GetOnInitializationFailure_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeInitializationResult_Handler:Com.Google.Android.Youtube.Player.YouTubeThumbnailView/IOnInitializedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onInitializationSuccess:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeThumbnailLoader;)V:GetOnInitializationSuccess_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeThumbnailLoader_Handler:Com.Google.Android.Youtube.Player.YouTubeThumbnailView/IOnInitializedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onThumbnailError:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeThumbnailLoader$ErrorReason;)V:GetOnThumbnailError_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeThumbnailLoader_ErrorReason_Handler:Com.Google.Android.Youtube.Player.IYouTubeThumbnailLoaderOnThumbnailLoadedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onThumbnailLoaded:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Ljava/lang/String;)V:GetOnThumbnailLoaded_Lcom_google_android_youtube_player_YouTubeThumbnailView_Ljava_lang_String_Handler:Com.Google.Android.Youtube.Player.IYouTubeThumbnailLoaderOnThumbnailLoadedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.VideoListDemoActivity+MyAdapter, MvvmCross_Application1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VideoListDemoActivity_MyAdapter.class, __md_methods);
	}


	public VideoListDemoActivity_MyAdapter ()
	{
		super ();
		if (getClass () == VideoListDemoActivity_MyAdapter.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.VideoListDemoActivity+MyAdapter, MvvmCross_Application1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public VideoListDemoActivity_MyAdapter (android.content.Context p0)
	{
		super ();
		if (getClass () == VideoListDemoActivity_MyAdapter.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.VideoListDemoActivity+MyAdapter, MvvmCross_Application1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);


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


	public void onThumbnailError (com.google.android.youtube.player.YouTubeThumbnailView p0, com.google.android.youtube.player.YouTubeThumbnailLoader.ErrorReason p1)
	{
		n_onThumbnailError (p0, p1);
	}

	private native void n_onThumbnailError (com.google.android.youtube.player.YouTubeThumbnailView p0, com.google.android.youtube.player.YouTubeThumbnailLoader.ErrorReason p1);


	public void onThumbnailLoaded (com.google.android.youtube.player.YouTubeThumbnailView p0, java.lang.String p1)
	{
		n_onThumbnailLoaded (p0, p1);
	}

	private native void n_onThumbnailLoaded (com.google.android.youtube.player.YouTubeThumbnailView p0, java.lang.String p1);

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
