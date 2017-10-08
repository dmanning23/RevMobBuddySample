using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace sampleApp.iOS
{
	public partial class ViewController : UIViewController
	{

		SampleRevmobDelegate sampleRevmobDelegate;
		RMNativeAdObject rmNativeAdObject;

		public ViewController(IntPtr handle) : base(handle)
		{
			
		}
		class SampleRevmobDelegate : RevmobDelegate {

			public override void RevmobDidCacheAd(RMAdUnits adUnit, NSObject placement) {
				Console.WriteLine("RevmobDidCacheAd");

				switch (adUnit) { 
					case RMAdUnits.Banner:
						Console.WriteLine("Banner");
						break;
					case RMAdUnits.Interstitial:
						Console.WriteLine("Interstitial");
						break;					
					case RMAdUnits.Link:
						Console.WriteLine("Link");
						break;					
					case RMAdUnits.NativeAd:
						Console.WriteLine("NativeAd");
						break;					
					case RMAdUnits.RewardedVideo:
						Console.WriteLine("RewardedVideo");
						break;

				}
			}

			public override void RevmobAdClicked(RMAdUnits adUnit, NSObject placement) { 		
				switch (adUnit) { 
					case RMAdUnits.Banner:
						Console.WriteLine("Banner");
						break;
					case RMAdUnits.Interstitial:
						Console.WriteLine("Interstitial");
						break;					
					case RMAdUnits.Link:
						Console.WriteLine("Link");
						break;					
					case RMAdUnits.NativeAd:
						Console.WriteLine("NativeAd");
						break;					
					case RMAdUnits.RewardedVideo:
						Console.WriteLine("RewardedVideo");
						break;

				}	
				Console.WriteLine("RevmobAdClicked");
			}

			public override void RevmobAdDisplayed(RMAdUnits adUnit, NSObject placement) { 			
				Console.WriteLine("RevmobAdDisplayed");
			}

			public override void RevmobAdDismissed(RMAdUnits adUnit, NSObject placement) { 			
				Console.WriteLine("RevmobAdDismissed");
			}

			public override void RevmobAdFailedToRender(RMAdUnits adUnit, NSObject placement) { 			
				Console.WriteLine("RevmobAdFailedToRender");
			}

			public override void RevmobUserWillLeaveAplication(RMAdUnits adUnit, NSObject placement) {			
				Console.WriteLine("RevmobUserWillLeaveAplication");
 			}

			public override void RevmobAdUnitFailedToCache(RMAdUnits adUnit, NSObject error, NSObject placement) {			
				Console.WriteLine("RevmobAdUnitFailedToCache");
 			}

			public override void RevmobRewardedVideoActionDidCompleteOnPlacement(NSObject placement) { 			
				Console.WriteLine("RevmobRewardedVideoActionDidCompleteOnPlacement");
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			sampleRevmobDelegate = new SampleRevmobDelegate();
			Revmob.Delegate = sampleRevmobDelegate;
			UIButton buttonstartSession = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowFullscreen = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadFullscreen = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowLoadedFullscreen = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadRewardedVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowRewardedVideo = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttoncacheBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonshowCustomBannerPos = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonhideCustomBanner = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonopenLink = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonloadAdLink = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonopenLoadedAdLink = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonCacheNativeStandard = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonCacheNativeCustom = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonShowNativeStandard = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonShowNativeCustom = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonReportImpression = UIButton.FromType(UIButtonType.RoundedRect);
			UIButton buttonRepotClick = UIButton.FromType(UIButtonType.RoundedRect);

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

			buttonstartSession.SetTitle("Init", UIControlState.Normal);
			buttonstartSession.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 60, 140, 40);
			buttonstartSession.TouchUpInside += startSessionButton;
			scrollView.AddSubview(buttonstartSession);

			buttonshowFullscreen.SetTitle("Show Fullscreen", UIControlState.Normal);
			buttonshowFullscreen.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 110, 140, 40);
			buttonshowFullscreen.TouchUpInside += showFullscreenButton;
			scrollView.AddSubview(buttonshowFullscreen);

			buttonloadFullscreen.SetTitle("Cache Fullscreen", UIControlState.Normal);
			buttonloadFullscreen.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 160, 140, 40);
			buttonloadFullscreen.TouchUpInside += loadFullscreenButton;
			scrollView.AddSubview(buttonloadFullscreen);

			buttonCacheNativeCustom.SetTitle("Cache Native Custom", UIControlState.Normal);
			buttonCacheNativeCustom.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 280, 140, 40);
			buttonCacheNativeCustom.TouchUpInside += cacheNativeCustom;
			scrollView.AddSubview(buttonCacheNativeCustom);

			buttonShowNativeCustom.SetTitle("Show Native Custom", UIControlState.Normal);
			buttonShowNativeCustom.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 340, 140, 40);
			buttonShowNativeCustom.TouchUpInside += showNativeCustom;
			scrollView.AddSubview(buttonShowNativeCustom);
			View.AddSubview(scrollView);

			buttonloadRewardedVideo.SetTitle("Cache Rewarded Video", UIControlState.Normal);
			buttonloadRewardedVideo.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 400, 190, 40);
			buttonloadRewardedVideo.TouchUpInside += loadRewardedVideoButton;
			scrollView.AddSubview(buttonloadRewardedVideo);

			buttonshowRewardedVideo.SetTitle("Show Rewarded Video", UIControlState.Normal);
			buttonshowRewardedVideo.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 460, 190, 40);
			buttonshowRewardedVideo.TouchUpInside += showRewardedVideoButton;
			scrollView.AddSubview(buttonshowRewardedVideo);

			buttonshowBanner.SetTitle("Show Banner", UIControlState.Normal);
			buttonshowBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 520, 140, 40);
			buttonshowBanner.TouchUpInside += showBannerButton;
			scrollView.AddSubview(buttonshowBanner);

			buttoncacheBanner.SetTitle("Cache Banner", UIControlState.Normal);
			buttoncacheBanner.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 580, 140, 40);
			buttoncacheBanner.TouchUpInside += cacheBannerButton;
			scrollView.AddSubview(buttoncacheBanner);

			buttonCacheNativeStandard.SetTitle("Cache Native Standard", UIControlState.Normal);
			buttonCacheNativeStandard.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 640, 210, 40);
			buttonCacheNativeStandard.TouchUpInside += cacheNativeStandard;
			scrollView.AddSubview(buttonCacheNativeStandard);

			buttonShowNativeStandard.SetTitle("Show Native Standard", UIControlState.Normal);
			buttonShowNativeStandard.Frame = new CGRect(this.View.Frame.Width / 2 - 100, 700, 190, 40);
			buttonShowNativeStandard.TouchUpInside += showNativeStandard;
			scrollView.AddSubview(buttonShowNativeStandard);

			buttonopenLink.SetTitle("Open Link", UIControlState.Normal);
			buttonopenLink.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 760, 140, 40);
			buttonopenLink.TouchUpInside += openLinkButton;
			scrollView.AddSubview(buttonopenLink);

			buttonloadAdLink.SetTitle("Cache Ad Link", UIControlState.Normal);
			buttonloadAdLink.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 820, 140, 40);
			buttonloadAdLink.TouchUpInside += loadAdLinkButton;
			scrollView.AddSubview(buttonloadAdLink);

			buttonReportImpression.SetTitle("Report impression", UIControlState.Normal);
			buttonReportImpression.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 880, 140, 40);
			buttonReportImpression.TouchUpInside += reportImpressionButton;
			scrollView.AddSubview(buttonReportImpression);

			buttonRepotClick.SetTitle("Report click", UIControlState.Normal);
			buttonRepotClick.Frame = new CGRect(this.View.Frame.Width / 2 - 60, 940, 140, 40);
			buttonRepotClick.TouchUpInside += reportClickButton;
			scrollView.AddSubview(buttonRepotClick);


		}

		protected void startSessionButton(object sender, System.EventArgs e)
		{
			Revmob.InitWithAppId(NSObject.FromObject("583398aa362bb1d798f637f1"));
		}

		protected void showFullscreenButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showFullscreenButton");
			Revmob.ShowInterstitial(NSObject.FromObject("12345678901234567890abc5"));
		}

		protected void loadFullscreenButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadFullscreenButton");
			Revmob.CacheInterstitial(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void loadRewardedVideoButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadRewardedVideoButton");
		Revmob.CacheRewardedVideo(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void showRewardedVideoButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showRewardedVideoButton");
		Revmob.ShowRewardedVideo(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void callBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showBannerButton");
	Revmob.CacheBanner(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void showBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("showBannerButton");
			RMBannerView rmBannerView = (RMBannerView) Revmob.GetBanner(NSObject.FromObject("12345678901234567890abc5"));
			if (rmBannerView != null)
			{
				rmBannerView.Frame = new CGRect(0, 110, 300, 100);
				this.View.AddSubview(rmBannerView);
			}

		}

		protected void cacheBannerButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("cacheBannerButton");
			Revmob.CacheBanner(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void openLinkButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("openLinkButton");
			Revmob.OpenLink(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void loadAdLinkButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("loadAdLinkButton");
	Revmob.CacheLink(NSObject.FromObject("12345678901234567890abc5"));

		}
		protected void cacheNativeStandard(object sender, System.EventArgs e)
		{
			Console.WriteLine("cacheNativeStandard");
		Revmob.CacheNativeStandard(NSObject.FromObject("595bf431aefb0e0f6ff95663"), 320, 250);

		}
		protected void showNativeStandard(object sender, System.EventArgs e)
		{
			Console.WriteLine("showNativeStandard");
			RMNativeAdView rmNativeAdView =  (RMNativeAdView) Revmob.GetNativeStandard(NSObject.FromObject("595bf431aefb0e0f6ff95663"));

			if (rmNativeAdView != null)
			{
				rmNativeAdView.Frame = new CGRect(0, 110, 300, 100);
				this.View.AddSubview(rmNativeAdView);
			}
		}
		protected void cacheNativeCustom(object sender, System.EventArgs e)
		{
			Console.WriteLine("cacheNativeCustom");
		Revmob.CacheNativeCustom(NSObject.FromObject("595bf431aefb0e0f6ff95663"));

		}
		protected void showNativeCustom(object sender, System.EventArgs e)
		{
			Console.WriteLine("showNativeCustom");
			rmNativeAdObject = (RMNativeAdObject)Revmob.GetNativeCustom(NSObject.FromObject("595bf431aefb0e0f6ff95663"));

			if (rmNativeAdObject != null) { 
				string title 		= rmNativeAdObject.Title;
				string Description 	= rmNativeAdObject.Description;
				//string price 		= rmNativeAdObject.Price;
				ShowToast(title, this.View);

			} 

		}

		protected void reportClickButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("reportClickButton");
	if(rmNativeAdObject != null)	rmNativeAdObject.SendClickEvent();

		}
		protected void reportImpressionButton(object sender, System.EventArgs e)
		{
			Console.WriteLine("reportImpressionButton");
		if(rmNativeAdObject != null)	rmNativeAdObject.SendImpressionEvent();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

	public void ShowToast(String message, UIView view)
	{
		UIView residualView = view.ViewWithTag(1989);
		if (residualView != null)
			residualView.RemoveFromSuperview();

		var viewBack = new UIView(new CoreGraphics.CGRect(83, 0, 300, 100));
		viewBack.BackgroundColor = UIColor.Black;
		viewBack.Tag = 1989;
		UILabel lblMsg = new UILabel(new CoreGraphics.CGRect(0, 20, 300, 60));
		lblMsg.Lines = 2;
		lblMsg.Text = message;
		lblMsg.TextColor = UIColor.White;
		lblMsg.TextAlignment = UITextAlignment.Center;
		viewBack.Center = view.Center;
		viewBack.AddSubview(lblMsg);
		view.AddSubview(viewBack);
		//roundtheCorner(viewBack);
		UIView.BeginAnimations("Toast");

		UIView.SetAnimationDuration(3.0f);
	    viewBack.Alpha = 0.0f;
	    UIView.CommitAnimations();

    }

	}
}
