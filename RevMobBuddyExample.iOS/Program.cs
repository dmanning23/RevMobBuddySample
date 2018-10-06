using AdMobBuddy;
using AdMobBuddy.iOS;
using Foundation;
using UIKit;

namespace RevMobBuddyExample.iOS
{
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
		private static Game1 game;

		internal static void RunGame(UIApplication app)
		{
			game = new Game1();
			game.Services.AddService<IAdManager>(new AdMobAdapter(game.Services.GetService<UIViewController>(), "ca-app-pub-5144527466254609~8969023993",
				"ca-app-pub-3940256099942544/4411468910", "ca-app-pub-3940256099942544/1712485313"));
			game.Run();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}

		public override void FinishedLaunching(UIApplication app)
		{
			RunGame(app);
		}
	}
}
