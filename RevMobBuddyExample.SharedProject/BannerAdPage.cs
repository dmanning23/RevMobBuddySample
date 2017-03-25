using MenuBuddy;
using RevMobBuddy;

namespace RevMobBuddyExample
{
	public class BannerAdPage : MenuScreen
	{
		IAdManager _adManager;

		public BannerAdPage() : base("Banner Ad Screen")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			_adManager = ScreenManager.Game.Services.GetService<IAdManager>();

			AddCancelButton();

			//add the banner ad
			_adManager.ShowBannerAd();
		}

		public override void UnloadContent()
		{
			base.UnloadContent();

			_adManager.HideBannerAd();
		}
	}
}