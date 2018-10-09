package com.examples.youtubeapidemo;


public class VideoListDemoActivity
	extends md52af954b89e412540bc9b68f2eb771b47.MvxActivity_1
	implements
		mono.android.IGCUserPeer,
		com.google.android.youtube.player.YouTubeThumbnailView.OnInitializedListener,
		com.google.android.youtube.player.YouTubeThumbnailLoader.OnThumbnailLoadedListener,
		com.google.android.youtube.player.YouTubePlayer.OnFullscreenListener,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"n_onConfigurationChanged:(Landroid/content/res/Configuration;)V:GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler\n" +
			"n_onInitializationFailure:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeInitializationResult;)V:GetOnInitializationFailure_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeInitializationResult_Handler:Com.Google.Android.Youtube.Player.YouTubeThumbnailView/IOnInitializedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onInitializationSuccess:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeThumbnailLoader;)V:GetOnInitializationSuccess_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeThumbnailLoader_Handler:Com.Google.Android.Youtube.Player.YouTubeThumbnailView/IOnInitializedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onThumbnailError:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Lcom/google/android/youtube/player/YouTubeThumbnailLoader$ErrorReason;)V:GetOnThumbnailError_Lcom_google_android_youtube_player_YouTubeThumbnailView_Lcom_google_android_youtube_player_YouTubeThumbnailLoader_ErrorReason_Handler:Com.Google.Android.Youtube.Player.IYouTubeThumbnailLoaderOnThumbnailLoadedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onThumbnailLoaded:(Lcom/google/android/youtube/player/YouTubeThumbnailView;Ljava/lang/String;)V:GetOnThumbnailLoaded_Lcom_google_android_youtube_player_YouTubeThumbnailView_Ljava_lang_String_Handler:Com.Google.Android.Youtube.Player.IYouTubeThumbnailLoaderOnThumbnailLoadedListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onFullscreen:(Z)V:GetOnFullscreen_ZHandler:Com.Google.Android.Youtube.Player.IYouTubePlayerOnFullscreenListenerInvoker, Naxam.YoutubePlayerApi.Droid\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.VideoListDemoActivity, MvvmCross_Application1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VideoListDemoActivity.class, __md_methods);
	}


	public VideoListDemoActivity ()
	{
		super ();
		if (getClass () == VideoListDemoActivity.class)
			mono.android.TypeManager.Activate ("MvvmCross_Application1.Droid.Views.YouTubePlayerSample.VideoListDemoActivity, MvvmCross_Application1.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);


	public void onConfigurationChanged (android.content.res.Configuration p0)
	{
		n_onConfigurationChanged (p0);
	}

	private native void n_onConfigurationChanged (android.content.res.Configuration p0);


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


	public void onFullscreen (boolean p0)
	{
		n_onFullscreen (p0);
	}

	private native void n_onFullscreen (boolean p0);


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
