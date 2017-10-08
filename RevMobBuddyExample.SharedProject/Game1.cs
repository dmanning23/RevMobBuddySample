using MenuBuddy;
using Microsoft.Xna.Framework;
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

			Graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.PortraitDown;

			VirtualResolution = new Point(720, 1280);
			ScreenResolution = new Point(720, 1280);

#if DESKTOP
			Fullscreen = false;
			Letterbox = true;
#else
			Fullscreen = true;
			Letterbox = false;
#endif
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
