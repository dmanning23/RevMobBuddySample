using MenuBuddy;
using RevMobBuddy;

namespace RevMobBuddyExample
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : TouchGame
	{
		public Game1()
		{
			//graphics.IsFullScreen = true;
			//graphics.PreferredBackBufferWidth = 800;
			//graphics.PreferredBackBufferHeight = 480;
			//graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
		}

		protected override void Initialize()
		{
			base.Initialize();

			var ads = Services.GetService<IAdManager>();
			ads.Initialize();
		}

		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new MainMenu() };
		}
	}
}
