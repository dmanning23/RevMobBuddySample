using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.IO;
using Android.Views;
using RM.Com.Android.Sdk.Ads.NativeAd;
using RM.Com.Android.Sdk.Ads.Banner;
using RM.Com.Android.Sdk;

namespace sampleApp.Droid
{
	[Activity(Label = "sampleApp", MainLauncher = true, Icon = "@mipmap/icon", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.KeyboardHidden | Android.Content.PM.ConfigChanges.Orientation)]
	public class MainActivity : Activity
	{
		Activity currentActivity;
		String REVMOB_APP_ID = "59395f63e96984358c4608a0";
		String REVMOB_PLACEMENT_ID = "12345678901234567890abc0";
		String REVMOB_NATIVE_ID = "12345678901234567890abc0";

		RMNativeAdObject rmNativeObject;
		RMBannerView rmBannerView;
		CallbackShowInterstitial showInterstitialAdListener;
		CallbackCacheInterstitial cacheInterstitialAdListener;

		CallbackCacheRewardedVideo loadRewardedVideoAdListener;
		CallbackShowRewardedVideo showRewardedVideoAdListener;

		CallbackCacheBanner cacheBannerAdListener;
		CallbackShowBanner showBannerAdListener;
		CallbackOpenLink openLinkAdListener;
		CallbackCacheLink cacheLinkAdListener;

		CallbackCacheNative cacheNativeAdListener;
		CallbackShowNative showNativeAdListener;

		CallbackCacheNativeCustom cacheNativeCustomAdListener;
		CallbackShowNativeCustom showNativeCustomAdListener;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			currentActivity = this;

			showInterstitialAdListener = new CallbackShowInterstitial(currentActivity);
			cacheInterstitialAdListener = new CallbackCacheInterstitial(currentActivity);
			loadRewardedVideoAdListener = new CallbackCacheRewardedVideo(currentActivity);
			showBannerAdListener = new CallbackShowBanner(currentActivity);
			showRewardedVideoAdListener = new CallbackShowRewardedVideo(currentActivity);
			openLinkAdListener = new CallbackOpenLink(currentActivity);
			cacheLinkAdListener = new CallbackCacheLink(currentActivity);
			cacheBannerAdListener = new CallbackCacheBanner(currentActivity);

			cacheNativeAdListener = new CallbackCacheNative(currentActivity);
			showNativeAdListener = new CallbackShowNative(currentActivity);

			cacheNativeCustomAdListener = new CallbackCacheNativeCustom(currentActivity);
			showNativeCustomAdListener = new CallbackShowNativeCustom(currentActivity);

			Button startSession = FindViewById<Button>(Resource.Id.startSession);
			Button showFullscreen = FindViewById<Button>(Resource.Id.showFullscreen);
			Button loadRewardedVideo = FindViewById<Button>(Resource.Id.loadRewardedVideo);
			Button showRewardedVideo = FindViewById<Button>(Resource.Id.showRewardedVideo);
			Button loadBanner = FindViewById<Button>(Resource.Id.loadBanner);
			Button showBanner = FindViewById<Button>(Resource.Id.showBanner);
			Button hideBanner = FindViewById<Button>(Resource.Id.hideBanner);
			Button openLink = FindViewById<Button>(Resource.Id.openLink);
			Button loadedLink = FindViewById<Button>(Resource.Id.loadedLink);


			startSession.Click += delegate
			{
				Rm.Init(currentActivity, REVMOB_APP_ID);
			};
			showFullscreen.Click += delegate
			{
				Rm.ShowInterstitial(currentActivity, REVMOB_PLACEMENT_ID, showInterstitialAdListener);

			};

			loadRewardedVideo.Click += delegate
			{
				Rm.CacheRewardedVideo(REVMOB_PLACEMENT_ID, loadRewardedVideoAdListener);
			};

			showRewardedVideo.Click += delegate
			{
				Rm.ShowRewardedVideo(currentActivity, REVMOB_PLACEMENT_ID, showRewardedVideoAdListener);


			};
			loadBanner.Click += delegate
			{
				Rm.CacheBanner(REVMOB_PLACEMENT_ID, cacheBannerAdListener);
			};
			showBanner.Click += delegate
			{
				rmBannerView = (RMBannerView)Rm.GetBanner(currentActivity, REVMOB_PLACEMENT_ID, showBannerAdListener);
				if (rmBannerView != null)
				{
					ViewGroup view = FindViewById<ViewGroup>(Resource.Id.banner);
					view.RemoveAllViews();
					view.AddView(rmBannerView);
				}
			};

			hideBanner.Click += delegate
			{
				if(rmBannerView != null)rmBannerView.Hide();

			};
			openLink.Click += delegate
			{
				Rm.OpenLink(currentActivity, REVMOB_PLACEMENT_ID, openLinkAdListener);
			};
			loadedLink.Click += delegate
			{
				Rm.CacheLink(REVMOB_PLACEMENT_ID, cacheLinkAdListener);

			};
		}

		[Java.Interop.Export("loadFullscreen")]
		public void loadFullscreen(View v)
		{
			Rm.CacheInterstitial(REVMOB_PLACEMENT_ID, cacheInterstitialAdListener);

		}

		[Java.Interop.Export("cacheNative")]
		public void cacheNative(View v)
		{
			Rm.CacheNativeStandard(REVMOB_NATIVE_ID, new Java.Lang.Integer(370), new Java.Lang.Integer(250), cacheNativeAdListener);
		}

		[Java.Interop.Export("showNative")]
		public void showNative(View v)
		{
			RM.Com.Android.Sdk.Ads.NativeAd.RMNativeViewStandard rmNativeViewStandard = (RM.Com.Android.Sdk.Ads.NativeAd.RMNativeViewStandard)Rm.GetNativeStandard(currentActivity, REVMOB_NATIVE_ID, showNativeAdListener);
			if (rmNativeViewStandard != null)
			{
				ViewGroup view = FindViewById<ViewGroup>(Resource.Id.banner);

				view.RemoveAllViews();
				view.AddView(rmNativeViewStandard);
			}
		}

		[Java.Interop.Export("cacheNativeCustom")]
		public void cacheNativeCustom(View v)
		{
			Rm.CacheNativeCustom(REVMOB_NATIVE_ID, cacheNativeCustomAdListener);
		}


		[Java.Interop.Export("showNativeCustom")]
		public void showNativeCustom(View v)
		{
			rmNativeObject = (RM.Com.Android.Sdk.Ads.NativeAd.RMNativeAdObject)Rm.GetNativeCustom(currentActivity, REVMOB_NATIVE_ID, showNativeCustomAdListener);
			if (rmNativeObject != null)
			{
				TextView textView = FindViewById<TextView>(Resource.Id.native_ad_title);
				TextView textBody = FindViewById<TextView>(Resource.Id.native_ad_body);
				ImageView imageView = FindViewById<ImageView>(Resource.Id.native_ad_icon);
				textView.Text = rmNativeObject.Title;
				textBody.Text = rmNativeObject.Description;

				rmNativeObject.ReportImpression(currentActivity);
			}
		}

		[Java.Interop.Export("nativeAdContainer")]
		public void nativeAdContainer(View v)
		{
			rmNativeObject.ReportClick(currentActivity);
		}

		class CallbackShowInterstitial : Java.Lang.Object, IRmListenerShow
		{
			Activity currentActivity;

			public CallbackShowInterstitial(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}
			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Interstitial dismissed!");
			}

			public void OnRmAdDismissed()
			{
				Console.WriteLine("Interstitial dismissed!");
			}

			public void OnRmAdClicked()
			{
				Console.WriteLine("Interstitial clicked!");
			}

			public void OnRmAdDisplayed()
			{
				Console.WriteLine("Interstitial displayed!");
			}

		}

		class CallbackCacheInterstitial :  Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

			public CallbackCacheInterstitial(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Interstitial not received!");
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Interstitial ad received and ready to be displayed.");
			}

		}

		class CallbackCacheRewardedVideo : Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

			public CallbackCacheRewardedVideo(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Rewarded Video loaded.");
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Rewarded Video failed to load.");
			}

		}

		class CallbackShowRewardedVideo : Java.Lang.Object, IRmListenerShowRewardedVideo
		{
			Activity currentActivity;

			public CallbackShowRewardedVideo(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmRewardedVideoCompleted()
			{
				Console.WriteLine("Rewarded Video loaded.");
			}

			public void OnRmAdDisplayed()
			{
				Console.WriteLine("Rewarded Video not completely loaded.");
			}
			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Rewarded Video failed to load.");

			}
			public void OnRmAdDismissed()
			{
				Console.WriteLine("Rewarded Video not completely loaded.");
			}
			public void OnRmAdClicked()
			{
				Console.WriteLine("Rewarded Video not completely loaded.");
			}
		}
		class CallbackCacheBanner : Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

			public CallbackCacheBanner(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Banner not received!");
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Banner ad received and ready to be displayed.");

			}
		}
		class CallbackShowBanner : Java.Lang.Object, IRmListenerGet
		{
			Activity currentActivity;

			public CallbackShowBanner(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Banner not received!");
			}

			public void OnRmAdDisplayed()
			{
				Console.WriteLine("Banner ad received and ready to be displayed.");
			}

			public void OnRmAdDismissed()
			{
				Console.WriteLine("Banner dismissed!");
			}

			public void OnRmAdClicked()
			{
				Console.WriteLine("Banner clicked!");
			}
		}

		class CallbackOpenLink : Java.Lang.Object, IRmListenerOpen
		{
			Activity currentActivity;

			public CallbackOpenLink(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}
			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Link not received!");
			}
			public void OnRmAdClicked()
			{
				Console.WriteLine("Link clicked!");
			}
		}
		class CallbackCacheLink : Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

			public CallbackCacheLink(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Link not received!");
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Link ad received and ready to be displayed.");		
			}
		}

		class CallbackCacheNative : Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

			public CallbackCacheNative(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Native not received!");
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Native ad received and ready to be displayed.");
			}
		}
		class CallbackShowNative : Java.Lang.Object, IRmListenerGet
		{
			Activity currentActivity;

			public CallbackShowNative(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Native not received!");
			}

			public void OnRmAdDisplayed()
			{
				Console.WriteLine("Native ad received and ready to be displayed.");
			}

			public void OnRmAdDismissed()
			{
				Console.WriteLine("Native dismissed!");
			}

			public void OnRmAdClicked()
			{
				Console.WriteLine("Native clicked!");
			}
		}

		class CallbackCacheNativeCustom : Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

		public CallbackCacheNativeCustom(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Native Custom not received!");
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Native Custom ad received and ready to be displayed.");
			}
		}
		class CallbackShowNativeCustom : Java.Lang.Object, IRmListenerGet
		{
			Activity currentActivity;

			public CallbackShowNativeCustom(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Native Custom not received!");
			}

			public void OnRmAdDisplayed()
			{
				Console.WriteLine("Native Custom ad received and ready to be displayed.");
			}

			public void OnRmAdDismissed()
			{
				Console.WriteLine("Native Custom dismissed!");
			}

			public void OnRmAdClicked()
			{
				Console.WriteLine("Native Custom clicked!");
			}
		}

	}

}
