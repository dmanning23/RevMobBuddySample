using AdMobBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace RevMobBuddyExample
{
	public class MainMenu : MenuStackScreen
	{
		public MainMenu() : base("AdMobBuddy Example")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override async Task LoadContent()
		{
			await base.LoadContent();

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

		protected void VideoReward(object obj, RewardedVideoEventArgs e)
		{
			var ads = ScreenManager.Game.Services.GetService<IAdManager>();
			ads.OnVideoReward -= VideoReward;
			//await ScreenManager.AddScreen(new OkScreen("You got a video reward!"));
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}
	}
}