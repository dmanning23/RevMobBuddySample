using AdMobBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;

namespace RevMobBuddyExample
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : TouchGame
	{
		public Game1()
		{
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

		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new MainMenu() };
		}
	}
}
