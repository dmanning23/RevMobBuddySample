using MenuBuddy;
using RevMobBuddy;
using System;

namespace RevMobBuddyExample
{
	public class MainMenu : MenuScreen
	{
		public MainMenu() : base("Main Menu")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			//add bannerad button
			var banner = new MenuEntry("Banner Ad");
			AddMenuEntry(banner);
			banner.OnClick += (obj, e) =>
			{
				ScreenManager.AddScreen(new BannerAdPage());
				//LoadingScreen.Load(ScreenManager, true, null, new BannerAdPage());
			};

			//add interstitial button
			var interstitial = new MenuEntry("Interstitial Ad");
			AddMenuEntry(interstitial);
			interstitial.OnClick += (obj, e) =>
			{
				var ads = ScreenManager.Game.Services.GetService<IAdManager>();
				ads.DisplayInterstitialAd();
			};

			//add rewarded video button
			var video = new MenuEntry("Video Ad");
			AddMenuEntry(video);

			//add rewarded video button
			var rewardedVideo = new MenuEntry("Rewarded Video Ad");
			AddMenuEntry(rewardedVideo);
			rewardedVideo.OnClick += (obj, e) =>
			{
				var ads = ScreenManager.Game.Services.GetService<IAdManager>();
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