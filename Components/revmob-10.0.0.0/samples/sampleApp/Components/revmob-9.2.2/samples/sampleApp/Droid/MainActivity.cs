using Android.App;
using Android.Widget;
using Android.OS;
using Com.Revmob;
using System;
using System.IO;
using Com.Revmob.Ads.Interstitial;
using Com.Revmob.Ads.Link;
using Android.Views;
using Com.Revmob.Ads.Banner;

namespace sampleApp.Droid
{
	[Activity(Label = "sampleApp", MainLauncher = true, Icon = "@mipmap/icon", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.KeyboardHidden | Android.Content.PM.ConfigChanges.Orientation)]
	public class MainActivity : Activity
	{
		Activity currentActivity;
		RevMobFullscreen fullscreen, video, rewardedVideo;
		RevMobBanner revmobBanner, revmobCustomBanner;
		RevMobLink link;
		CallbackStartSessionListener startSessionListener;
		CallbackShowFullscreen showFullscreenAdListener;
		CallbackShowLoadFullscreen showLoadFullscreenAdListener;
		CallbackVideoLoaded videoLoadedAdListener;
		CallbackVideoRewarded videoRewardedAdListener;
		CallbackShowBanner showBannerAdListener;
		CallbackShowCustomBanner showCustomBannerAdListener;
		CallbackOpenLink openLinkAdListener;
		CallbackOpenLoadedLink openaLoadedLinkAdListener;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			currentActivity = this;

			startSessionListener = new CallbackStartSessionListener(currentActivity);
			showFullscreenAdListener = new CallbackShowFullscreen(currentActivity);
			showLoadFullscreenAdListener = new CallbackShowLoadFullscreen(currentActivity);
			videoLoadedAdListener = new CallbackVideoLoaded(currentActivity);
			videoRewardedAdListener = new CallbackVideoRewarded(currentActivity);
			showBannerAdListener = new CallbackShowBanner(currentActivity);
			showCustomBannerAdListener = new CallbackShowCustomBanner(currentActivity);
			openLinkAdListener = new CallbackOpenLink(currentActivity);
			openaLoadedLinkAdListener = new CallbackOpenLoadedLink(currentActivity);

			Button startSession = FindViewById<Button>(Resource.Id.startSession);
			Button showFullscreen = FindViewById<Button>(Resource.Id.showFullscreen);
			Button showLoadedFullscreen = FindViewById<Button>(Resource.Id.showLoadedFullscreen);
			Button loadVideo = FindViewById<Button>(Resource.Id.loadVideo);
			Button showVideo = FindViewById<Button>(Resource.Id.showVideo);
			Button loadRewardedVideo = FindViewById<Button>(Resource.Id.loadRewardedVideo);
			Button showRewardedVideo = FindViewById<Button>(Resource.Id.showRewardedVideo);
			Button releaseBanner = FindViewById<Button>(Resource.Id.releaseBanner);
			Button releaseCustomBanner = FindViewById<Button>(Resource.Id.releaseCustomBanner);
			Button loadCustomBanner = FindViewById<Button>(Resource.Id.loadCustomBanner);
			Button loadBanner = FindViewById<Button>(Resource.Id.loadBanner);
			Button showBanner = FindViewById<Button>(Resource.Id.showBanner);
			Button hideBanner = FindViewById<Button>(Resource.Id.hideBanner);
			Button showCustomBannerPosition = FindViewById<Button>(Resource.Id.showCustomBannerPosition);
			Button hideCustomBanner = FindViewById<Button>(Resource.Id.hideCustomBanner);
			Button openLink = FindViewById<Button>(Resource.Id.openLink);
			Button loadedLink = FindViewById<Button>(Resource.Id.loadedLink);
			Button openLoadedLink = FindViewById<Button>(Resource.Id.openLoadedLink);
			Button printEnvironmentInformation = FindViewById<Button>(Resource.Id.printEnvironmentInformation);
			Button setUserAgeRangeMin = FindViewById<Button>(Resource.Id.setUserAgeRangeMin);

			startSession.Click += delegate
			{
				RevMob.StartWithListener(currentActivity, startSessionListener, "5695f1c559163ac94e52394c");
			};

			showLoadedFullscreen.Click += delegate
			{
				if (fullscreen != null)
				{
					fullscreen.Show();
				}
			};
			loadVideo.Click += delegate
			{
				if (RevMob.Session() != null)
					video = RevMob.Session().CreateVideo(currentActivity, videoLoadedAdListener);

			};
			showFullscreen.Click += delegate
			{
				if (RevMob.Session() != null)
					RevMob.Session().ShowFullscreen(currentActivity, showFullscreenAdListener);

			};

			showVideo.Click += delegate
			{
				if (video != null)
				{
					video.ShowVideo();
				}
			};
			loadRewardedVideo.Click += delegate
			{
				if (RevMob.Session() != null)
					rewardedVideo = RevMob.Session().CreateRewardedVideo(currentActivity, videoRewardedAdListener);

			};

			showRewardedVideo.Click += delegate
			{
				if (rewardedVideo != null)
				{
					rewardedVideo.ShowRewardedVideo();
				}

			};
			releaseBanner.Click += delegate
			{
				if (revmobBanner != null)
					revmobBanner.Release();
					revmobBanner = null;
			};
			loadBanner.Click += delegate
				{
					if (RevMob.Session() != null)
					{
						revmobBanner = RevMob.Session().CreateBanner(currentActivity, "", showBannerAdListener);
						revmobBanner.SetAutoShow(false);

						ViewGroup view = FindViewById<ViewGroup>(Resource.Id.banner);

						view.RemoveAllViews();
						view.AddView(revmobBanner);
					}

				};
			showBanner.Click += delegate
				{
					if (revmobBanner != null)
					{
						revmobBanner.Show();
					}else if (RevMob.Session() != null)
						{
							revmobBanner = RevMob.Session().CreateBanner(currentActivity, "", showBannerAdListener);
							revmobBanner.SetAutoShow(true);

							ViewGroup view = FindViewById<ViewGroup>(Resource.Id.banner);

							view.RemoveAllViews();
							view.AddView(revmobBanner);

					}
				};
			hideBanner.Click += delegate
			{
				if (revmobBanner != null)
					revmobBanner.Hide();
			};
			loadCustomBanner.Click += delegate
			{
				if (RevMob.Session() != null)
				{
					revmobCustomBanner = RevMob.Session().CreateBanner(currentActivity, "", showCustomBannerAdListener);
					revmobCustomBanner.SetAutoShow(false);

					ViewGroup view = FindViewById<ViewGroup>(Resource.Id.bannerCustomSize);

					view.RemoveAllViews();
					view.AddView(revmobCustomBanner);
				}

			};
			showCustomBannerPosition.Click += delegate
			{
				if (revmobCustomBanner != null)
				{
					revmobCustomBanner.Show();
				}else if (RevMob.Session() != null){
						revmobCustomBanner = RevMob.Session().CreateBanner(currentActivity, showCustomBannerAdListener);
						revmobCustomBanner.SetAutoShow(true);
						ViewGroup view = FindViewById<ViewGroup>(Resource.Id.bannerCustomSize);

						view.RemoveAllViews();
						view.AddView(revmobCustomBanner);

				}
			};
			releaseCustomBanner.Click += delegate
			{
				if (revmobCustomBanner != null)
					revmobCustomBanner.Release();
					revmobCustomBanner = null;
			};
			hideCustomBanner.Click += delegate
			{
				if (revmobCustomBanner != null)
					revmobCustomBanner.Hide();
			};
			openLink.Click += delegate
			{
				if (RevMob.Session() != null)
					RevMob.Session().OpenLink(currentActivity, openLinkAdListener);
			};
			loadedLink.Click += delegate
			{
				if (RevMob.Session() != null)
					link = RevMob.Session().CreateLink(currentActivity, openaLoadedLinkAdListener);
			};
			openLoadedLink.Click += delegate
			{
				if (link != null)
				{
					link.Open();
				}
			};
			printEnvironmentInformation.Click += delegate
			{
				if (RevMob.Session() != null)
					RevMob.Session().PrintEnvironmentInformation(currentActivity);
			};
			setUserAgeRangeMin.Click += delegate
			{
				if (RevMob.Session() != null)
					RevMob.Session().UserAgeRangeMin = 10;
			};

		}

		[Java.Interop.Export("loadFullscreen")]
		public void loadFullscreen(View v)
		{
			if (RevMob.Session() != null)
				fullscreen = RevMob.Session().CreateFullscreen(currentActivity, showLoadFullscreenAdListener);
		}


		class CallbackStartSessionListener : RevMobAdsListener
		{
			Activity currentActivity;
			public CallbackStartSessionListener(Activity currentActivity)
			{
				Console.WriteLine("CallbackStartSessionListener");
				this.currentActivity = currentActivity;

			}
			public override void OnRevMobSessionIsStarted()
			{
				Console.WriteLine("Session started");

			}
			public override void OnRevMobSessionNotStarted(String error)
			{
				Console.WriteLine("RevMob session failed to start.");
			}
		}
		class CallbackShowFullscreen : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackShowFullscreen(Activity currentActivity)
			{
				Console.WriteLine("CallbackShowFullscreen");
				this.currentActivity = currentActivity;
			}

			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("fullscreen not received!");
			}

			public override void OnRevMobAdReceived()
			{
				Console.WriteLine("Fullscreen ad received and ready to be displayed.");
			}

			public override void OnRevMobAdDismissed()
			{
				Console.WriteLine("Fullscreen dismissed!");
			}

			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("Fullscreen clicked!");
			}

			public override void OnRevMobAdDisplayed()
			{
				Console.WriteLine("Fullscreen displayed!");
			}

		}
		class CallbackShowLoadFullscreen : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackShowLoadFullscreen(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackShowLoadFullscreen");
			}

			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("LoadFullscreen not received!");
			}

			public override void OnRevMobAdReceived()
			{
				Console.WriteLine("LoadFullscreen ad received and ready to be displayed.");
			}

			public override void OnRevMobAdDismissed()
			{
				Console.WriteLine("LoadFullscreen dismissed.");
			}

			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("LoadFullscreen clicked.");
			}

			public override void OnRevMobAdDisplayed()
			{
				Console.WriteLine("loadFullscreen displayed!");
			}

		}
		class CallbackVideoLoaded : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackVideoLoaded(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackVideoLoaded");
			}

			public override void OnRevMobAdDismissed()
			{
				Console.WriteLine("Video closed.");
			}
			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("Video clicked.");
			}
			public override void OnRevMobVideoLoaded()
			{
				Console.WriteLine("Video loaded.");
			}
			public override void OnRevMobVideoStarted()
			{
				Console.WriteLine("Video started.");
			}
			public override void OnRevMobVideoFinished()
			{
				Console.WriteLine("Video finished.");
			}
			public override void OnRevMobVideoNotCompletelyLoaded()
			{
				Console.WriteLine("Video not completely loaded.");
			}
			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("Video failed");
			}

		}

		class CallbackVideoRewarded : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackVideoRewarded(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackVideoRewarded");
			}

			public override void OnRevMobRewardedVideoLoaded()
			{
				Console.WriteLine("Rewarded Video loaded.");
			}
			public override void OnRevMobRewardedVideoStarted()
			{
				Console.WriteLine("Rewarded Video started.");
			}
			public override void OnRevMobRewardedVideoCompleted()
			{
				Console.WriteLine("Rewarded Video completed.");
			}
			public override void OnRevMobRewardedVideoNotCompletelyLoaded()
			{
				Console.WriteLine("Rewarded Video not completely loaded.");
			}
			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("Rewarded Video failed to load.");
			}

		}
		class CallbackShowBanner : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackShowBanner(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackShowBanner");
			}

			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("Banner not received!");
			}

			public override void OnRevMobAdReceived()
			{
				Console.WriteLine("Banner ad received and ready to be displayed.");
			}

			public override void OnRevMobAdDismissed()
			{
				Console.WriteLine("Banner dismissed!");
			}

			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("Banner clicked!");
			}

			public override void OnRevMobAdDisplayed()
			{
				Console.WriteLine("Banner displayed!");
			}

		}
		class CallbackShowCustomBanner : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackShowCustomBanner(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackShowCustomBanner");
			}

			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("Custom Banner not received!");
			}

			public override void OnRevMobAdReceived()
			{
				Console.WriteLine("Custom Banner ad received and ready to be displayed.");
			}

			public override void OnRevMobAdDismissed()
			{
				Console.WriteLine("Custom Banner dismissed!");
			}

			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("Custom Banner clicked!");
			}

			public override void OnRevMobAdDisplayed()
			{
				Console.WriteLine("Custom Banner displayed!");
			}

		}
		class CallbackOpenLink : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackOpenLink(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackOpenLink");
			}

			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("Native not received!");
			}

			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("Native link clicked.");
			}

		}
		class CallbackOpenLoadedLink : RevMobAdsListener
		{
			Activity currentActivity;

			public CallbackOpenLoadedLink(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
				Console.WriteLine("CallbackOpenLoadedLink");
			}

			public override void OnRevMobAdNotReceived(String error)
			{
				Console.WriteLine("LoadNative not received!");
			}

			public override void OnRevMobAdClicked()
			{
				Console.WriteLine("LoadNative link clicked.");
			}
			public override void OnRevMobAdReceived()
			{
				Console.WriteLine("LoadNative link received.");
			}
		}

	}

}
