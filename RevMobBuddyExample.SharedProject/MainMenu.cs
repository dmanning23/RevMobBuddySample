using AdMobBuddy;
using MenuBuddy;
using System;

namespace RevMobBuddyExample
{
	public class MainMenu : MenuScreen
	{
		public MainMenu() : base("AdMobBuddy Example")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			//add interstitial button
			var interstitial = new MenuEntry("Interstitial Ad", Content);
			AddMenuEntry(interstitial);
			interstitial.OnClick += (obj, e) =>
			{
				var ads = ScreenManager.Game.Services.GetService<IAdManager>();
				ads.DisplayInterstitialAd();
			};

			//add rewarded video button
			var rewardedVideo = new MenuEntry("Rewarded Video Ad", Content);
			AddMenuEntry(rewardedVideo);
			rewardedVideo.OnClick += (obj, e) =>
			{
				var ads = ScreenManager.Game.Services.GetService<IAdManager>();
				ads.OnVideoReward -= VideoReward;
				ads.OnVideoReward += VideoReward;
				ads.DisplayRewardedVideoAd();
			};
		}

		protected void VideoReward(object obj, EventArgs e)
		{
			var ads = ScreenManager.Game.Services.GetService<IAdManager>();
			ads.OnVideoReward -= VideoReward;
			ScreenManager.AddScreen(new OkScreen("You got a video reward!"));
		}
	}
}