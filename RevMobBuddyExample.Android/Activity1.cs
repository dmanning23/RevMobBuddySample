using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using RevMobBuddy;
using RevMobBuddy.Android;

namespace RevMobBuddyExample.Android
{
	[Activity(Label = "Game1"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, AlwaysRetainTaskState = true
		, LaunchMode = LaunchMode.SingleInstance
		, ScreenOrientation = ScreenOrientation.SensorLandscape
		, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
	public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
	{
		public FrameLayout _mainLayout;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			var g = new Game1();

			//get the game view
			var gameView = g.Services.GetService<View>();

			//create a frame layout
			_mainLayout = new FrameLayout(this);

			//add the game to the framelayout
			_mainLayout.AddView(gameView);

			SetContentView(_mainLayout);

			g.Services.AddService<IAdManager>(new AndroidRevMobManager(g, _mainLayout));

			g.Run();
		}
	}
}

