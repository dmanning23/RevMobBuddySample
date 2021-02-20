using AdMobBuddy;
using AdMobBuddy.Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace RevMobBuddyExample.Android
{
	[Activity(Label = "AdMob Example"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, AlwaysRetainTaskState = true
		, LaunchMode = LaunchMode.SingleInstance
		, ScreenOrientation = ScreenOrientation.SensorPortrait
		, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
	public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			var g = new Game1();
			SetContentView((View)g.Services.GetService(typeof(View)));

			g.Services.AddService<IAdManager>(new AdMobAdapter(this, "ca-app-pub-8228485892439970~1803261097",
				"ca-app-pub-3940256099942544/1033173712", "ca-app-pub-3940256099942544/5224354917",
				"34A3D7C62F372FD18218F63F37D12398"));

			g.Run();
		}
	}
}

