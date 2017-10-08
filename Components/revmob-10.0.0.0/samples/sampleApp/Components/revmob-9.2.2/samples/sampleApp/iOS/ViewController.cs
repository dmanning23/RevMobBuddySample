using System;
using CoreGraphics;
using Foundation;
using UIKit;
using RevmobAds;
using CoreMedia;
using MediaPlayer;
namespace sampleApp.iOS
{
	public partial class ViewController : UIViewController
	{
		RevMobFullscreen loadfullscreen, video, rewardedVideo;
		RevMobAdLink adLink;
		RevMobBanner banner, customBanner;
		public ViewController(IntPtr handle) : base(handle)
		{

		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//MPVolumeView volumeView;

			UIButton buttonstartSession = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowFullscreen = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadFullscreen = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowLoadedFullscreen = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadRewardedVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowRewardedVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonReleaseBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonPreLoadBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonhideBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonReleaseCustomBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonPreLoadCustomBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowCustomBannerPos = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonhideCustomBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonopenLink = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadAdLink = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonopenLoadedAdLink = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonprintEnvironmentInformation = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonsetUserAgeRangeMin = UIButton.FromType(UIButtonType.RoundedRect);

			UIScrollView scrollView;
			nfloat h = 50.0f;
			nfloat w = 50.0f;
			nfloat padding = 10.0f;
			nint n = 25;

			scrollView = new UIScrollView
			{
				Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height),
				ContentSize = new CGSize(w * 1.5, (h + padding) * n),
				BackgroundColor = UIColor.White,
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth
			};

			buttonstartSession.SetTitle("Start Session", UIControlState.Normal);
			buttonstartSession.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 60, 140, 40);
			buttonstartSession.TouchUpInside += startSessionButton;
			scrollView.AddSubview(buttonstartSession);

			buttonshowFullscreen.SetTitle("Show Fullscreen", UIControlState.Normal);
			buttonshowFullscreen.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 110, 140, 40);
			buttonshowFullscreen.TouchUpInside += showFullscreenButton;
			scrollView.AddSubview(buttonshowFullscreen);

			buttonloadFullscreen.SetTitle("Load Fullscreen", UIControlState.Normal);
			buttonloadFullscreen.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 160, 140, 40);
			buttonloadFullscreen.TouchUpInside += loadFullscreenButton;
			scrollView.AddSubview(buttonloadFullscreen);

			buttonshowLoadedFullscreen.SetTitle("Show Loaded Fullscreen", UIControlState.Normal);
			buttonshowLoadedFullscreen.Frame = new CGRect(this.View.Frame.Width / 2 - 90, 220, 190, 40);
			buttonshowLoadedFullscreen.TouchUpInside += showLoadedFullscreenButton;
			scrollView.AddSubview(buttonshowLoadedFullscreen);

			buttonloadVideo.SetTitle("Load Video", UIControlState.Normal);
			buttonloadVideo.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 280, 140, 40);
			buttonloadVideo.TouchUpInside += loadVideoButton;
			scrollView.AddSubview(buttonloadVideo);

			buttonshowVideo.SetTitle("Show Video", UIControlState.Normal);
			buttonshowVideo.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 340, 140, 40);
			buttonshowVideo.TouchUpInside += showVideonButton;
			scrollView.AddSubview(buttonshowVideo);

			buttonloadRewardedVideo.SetTitle("Load Rewarded Video", UIControlState.Normal);
			buttonloadRewardedVideo.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 400, 190, 40);
			buttonloadRewardedVideo.TouchUpInside += loadRewardedVideoButton;
			scrollView.AddSubview(buttonloadRewardedVideo);

			buttonshowRewardedVideo.SetTitle("Show Rewarded Video", UIControlState.Normal);
			buttonshowRewardedVideo.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 460, 190, 40);
			buttonshowRewardedVideo.TouchUpInside += showRewardedVideoButton;
			scrollView.AddSubview(buttonshowRewardedVideo);

			buttonReleaseBanner.SetTitle("Release Banner", UIControlState.Normal);
			buttonReleaseBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 520, 140, 40);
			buttonReleaseBanner.TouchUpInside += releaseBannerButton;
			scrollView.AddSubview(buttonReleaseBanner);

			buttonPreLoadBanner.SetTitle("Load Banner", UIControlState.Normal);
			buttonPreLoadBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 580, 140, 40);
			buttonPreLoadBanner.TouchUpInside += preLoadButton;
			scrollView.AddSubview(buttonPreLoadBanner);

			buttonshowBanner.SetTitle("Show Banner", UIControlState.Normal);
			buttonshowBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 640, 140, 40);
			buttonshowBanner.TouchUpInside += showBannerButton;
			scrollView.AddSubview(buttonshowBanner);

			buttonhideBanner.SetTitle("Hide Banner", UIControlState.Normal);
			buttonhideBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 700, 140, 40);
			buttonhideBanner.TouchUpInside += hideBannerButton;
			scrollView.AddSubview(buttonhideBanner);

			buttonReleaseCustomBanner.SetTitle("Release Custom Banner", UIControlState.Normal);
			buttonReleaseCustomBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 760, 210, 40);
			buttonReleaseCustomBanner.TouchUpInside += releaseCustomBannerButton;
			scrollView.AddSubview(buttonReleaseCustomBanner);

			buttonPreLoadCustomBanner.SetTitle("Load Custom Banner", UIControlState.Normal);
			buttonPreLoadCustomBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 820, 210, 40);
			buttonPreLoadCustomBanner.TouchUpInside += loadCustomBannerButton;
			scrollView.AddSubview(buttonPreLoadCustomBanner);

			buttonshowCustomBannerPos.SetTitle("Show Custom Banner Position", UIControlState.Normal);
			buttonshowCustomBannerPos.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 880, 210, 40);
			buttonshowCustomBannerPos.TouchUpInside += showCustomBannerPosButton;
			scrollView.AddSubview(buttonshowCustomBannerPos);

			buttonhideCustomBanner.SetTitle("Hide Custom Banner", UIControlState.Normal);
			buttonhideCustomBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 940, 190, 40);
			buttonhideCustomBanner.TouchUpInside += hideCustomBannerButton;
			scrollView.AddSubview(buttonhideCustomBanner);

			buttonopenLink.SetTitle("Open Link", UIControlState.Normal);
			buttonopenLink.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 1000, 140, 40);
			buttonopenLink.TouchUpInside += openLinkButton;
			scrollView.AddSubview(buttonopenLink);

			buttonloadAdLink.SetTitle("Load Ad Link", UIControlState.Normal);
			buttonloadAdLink.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 1060, 140, 40);
			buttonloadAdLink.TouchUpInside += loadAdLinkButton;
			scrollView.AddSubview(buttonloadAdLink);

			buttonopenLoadedAdLink.SetTitle("Open Loaded Ad Link", UIControlState.Normal);
			buttonopenLoadedAdLink.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 1120, 190, 40);
			buttonopenLoadedAdLink.TouchUpInside += openLoadedAdLinkButton;
			scrollView.AddSubview(buttonopenLoadedAdLink);

			buttonprintEnvironmentInformation.SetTitle("Print Environment Information", UIControlState.Normal);
			buttonprintEnvironmentInformation.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 1180, 210, 40);
			buttonprintEnvironmentInformation.TouchUpInside += printEnvironmentInformationButton;
			scrollView.AddSubview(buttonprintEnvironmentInformation);

			buttonsetUserAgeRangeMin.SetTitle("Set User Age Range Min", UIControlState.Normal);
			buttonsetUserAgeRangeMin.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 1240, 190, 40);
			buttonsetUserAgeRangeMin.TouchUpInside += setUserAgeRangeMinButton;
			scrollView.AddSubview(buttonsetUserAgeRangeMin);

			View.AddSubview(scrollView);
		}

		protected void startSessionButton(object sender, System.EventArgs e)
		{
			Action<NSError> actionError = revmobSessionDidNotStartWithError;
			Action action = revmobSessionDidStart;
			RevMobAds.StartSessionWithAppID("5695efd659163ac94e52393e", action, actionError);

		}

		protected void showFullscreenButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showFullscreenButton");
			if (RevMobAds.Session != null)
			{
				RevMobFullscreen fullscreen = RevMobAds.Session.Fullscreen;
				fullscreen.WeakDelegate = this;
				fullscreen.ShowAd();
			}

		}
		protected void loadFullscreenButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadFullscreenButton");
			if (RevMobAds.Session != null)
			{
				loadfullscreen = RevMobAds.Session.Fullscreen;
				loadfullscreen.WeakDelegate = this;
				loadfullscreen.LoadAd();
			}

		}
		protected void showLoadedFullscreenButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showLoadedFullscreenButton");
			if (loadfullscreen != null)
			{
				loadfullscreen.ShowAd();
			}

		}
		protected void loadVideoButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadVideoButton");
			if (RevMobAds.Session != null)
			{
				video = RevMobAds.Session.Fullscreen;
				video.WeakDelegate = this;
				video.LoadVideo();
			}

		}
		protected void showVideonButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showVideonButton");
			if (video != null)
			{
				video.ShowVideo();
			}

		}
		protected void loadRewardedVideoButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadRewardedVideoButton");
			if (RevMobAds.Session != null)
			{
				rewardedVideo = RevMobAds.Session.Fullscreen;
				rewardedVideo.WeakDelegate = this;
				rewardedVideo.LoadRewardedVideo();
			}

		}
		protected void showRewardedVideoButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showRewardedVideoButton");
			if (rewardedVideo != null)
			{
				rewardedVideo.ShowRewardedVideo();
			}

		}

		protected void releaseBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("releaseBannerButton");
			if (banner != null)
			{
				banner.ReleaseAd();
				banner = null;
			}

		}

		protected void preLoadButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("preLoadButton");
			if (RevMobAds.Session != null)
			{
				banner = RevMobAds.Session.Banner;
				banner.WeakDelegate = this;
				banner.LoadAd();
			}

		}

		protected void showBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showBannerButton");
			if (banner != null)
			{
				banner.ShowAd();
			}

		}
		protected void hideBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("hideBannerButton");
			if (banner != null)
			{
				banner.HideAd();

			}

		}
		protected void releaseCustomBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("releaseCustomBannerButton");
			if (customBanner != null)
			{
				customBanner.ReleaseAd();
				customBanner = null;
			}

		}
		protected void loadCustomBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadCustomBannerButton");
			if (RevMobAds.Session != null)
			{
				customBanner = RevMobAds.Session.Banner;
				customBanner.WeakDelegate = this;
				customBanner.Frame = new CGRect(0, 40, this.View.Frame.Width, 50);
				customBanner.LoadAd();
			}

		}
		protected void showCustomBannerPosButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showCustomBannerPosButton");
			if (customBanner != null)
			{
				customBanner.ShowAd();

			}
		}
		protected void hideCustomBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("hideCustomBannerButton");
			if (customBanner != null)
			{
				customBanner.HideAd();
			}

		}
		protected void openLinkButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("openLinkButton");
			if (RevMobAds.Session != null)
			{
				RevMobAdLink adLink = RevMobAds.Session.AdLink;
				adLink.WeakDelegate = this;
				adLink.OpenLink();
			}

		}
		protected void loadAdLinkButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadAdLinkButton");
			if (RevMobAds.Session != null)
			{
				adLink = RevMobAds.Session.AdLink;
				adLink.WeakDelegate = this;
				adLink.LoadAd();
			}

		}
		protected void openLoadedAdLinkButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("openLoadedAdLinkButton");
			if (adLink != null)
			{
				adLink.OpenLink();
			}

		}
		protected void printEnvironmentInformationButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("printEnvironmentInformationButton");
			if (RevMobAds.Session != null)
			{
				RevMobAds.Session.PrintEnvironmentInformation();
			}

		}
		protected void setUserAgeRangeMinButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("setUserAgeRangeMinButton");
			if (RevMobAds.Session != null)
			{
				RevMobAds.Session.UserAgeRangeMin = 10;

			}

		}



		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		/////Session Listeners/////
		public void revmobSessionDidStart()
		{
			Console.WriteLine("revmobSessionDidStart");

		}

		public void revmobSessionDidNotStartWithError(NSError error)
		{
			Console.WriteLine("revmobSessionDidNotStartWithError");

		}

		/////Native ads Listeners/////
		[Export("revmobUserDidClickOnNative:")]
		public void revmobUserDidClickOnNative(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnNative");

		}
		[Export("revmobNativeDidReceive:")]
		public void revmobNativeDidReceive(String placementId)
		{
			Console.WriteLine("revmobNativeDidReceive");

		}
		[Export("revmobNativeDidFailWithError:")]
		public void revmobNativeDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobNativeDidFailWithError");

		}

		/////Fullscreen Listeners/////
		[Export("revmobUserDidClickOnFullscreen:")]
		public void revmobUserDidClickOnFullscreen(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnFullscreen");

		}
		[Export("revmobFullscreenDidReceive:")]
		public void revmobFullscreenDidReceive(String placementId)
		{
			Console.WriteLine("revmobFullscreenDidReceive");

		}
		[Export("revmobFullscreenDidFailWithError:")]
		public void revmobFullscreenDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobFullscreenDidFailWithError");

		}
		[Export("revmobFullscreenDidDisplay:")]
		public void revmobFullscreenDidDisplay(String placementId)
		{
			Console.WriteLine("revmobFullscreenDidDisplay");

		}
		[Export("revmobUserDidCloseFullscreen:")]
		public void revmobUserDidCloseFullscreen(String placementId)
		{
			Console.WriteLine("revmobUserDidCloseFullscreen");

		}


		///Banner Listeners///
		[Export("revmobUserDidClickOnBanner:")]
		public void revmobUserDidClickOnBanner(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnBanner");

		}
		[Export("revmobBannerDidReceive:")]
		public void revmobBannerDidReceive(String placementId)
		{
			Console.WriteLine("revmobBannerDidReceive");


		}
		[Export("revmobBannerDidFailWithError:")]
		public void revmobBannerDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobBannerDidFailWithError");

		}
		[Export("revmobBannerDidDisplay:")]
		public void revmobBannerDidDisplay(String placementId)
		{
			Console.WriteLine("revmobBannerDidDisplay");

		}
		/////Video Listeners/////
		[Export("revmobVideoDidLoad:")]
		public void revmobVideoDidLoad(String placementId)
		{
			Console.WriteLine("revmobVideoDidLoad");

		}
		[Export("revmobVideoDidFailWithError:")]
		public void revmobVideoDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobVideoDidFailWithError");

		}
		[Export("revmobVideoNotCompletelyLoaded:")]
		public void revmobVideoNotCompletelyLoaded(String placementId)
		{
			Console.WriteLine("revmobVideoNotCompletelyLoaded");

		}
		[Export("revmobVideoDidStart:")]
		public void revmobVideoDidStart(String placementId)
		{
			Console.WriteLine("revmobVideoDidStart");

		}
		[Export("revmobVideoDidFinish:")]
		public void revmobVideoDidFinish(String placementId)
		{
			Console.WriteLine("revmobVideoDidFinish");

		}
		[Export("revmobUserDidCloseVideo:")]
		public void revmobUserDidCloseVideo(String placementId)
		{
			Console.WriteLine("revmobUserDidCloseVideo");

		}
		[Export("revmobUserDidClickOnVideo:")]
		public void revmobUserDidClickOnVideo(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnVideo");

		}


		/////Rewarded Video Listeners/////
		[Export("revmobRewardedVideoDidLoad:")]
		public void revmobRewardedVideoDidLoad(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoDidLoad");

		}
		[Export("revmobRewardedVideoDidFailWithError:")]
		public void revmobRewardedVideoDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobRewardedVideoDidFailWithError");

		}
		[Export("revmobRewardedVideoNotCompletelyLoaded:")]
		public void revmobRewardedVideoNotCompletelyLoaded(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoNotCompletelyLoaded");

		}
		[Export("revmobRewardedVideoDidStart:")]
		public void revmobRewardedVideoDidStart(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoDidStart");

		}
		[Export("revmobRewardedVideoDidComplete:")]
		public void revmobRewardedVideoDidComplete(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoDidComplete");

		}





	}
}
