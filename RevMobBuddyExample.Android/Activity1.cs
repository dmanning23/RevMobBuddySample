using AdMobMonoGame;
using AdMobMonoGame.Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace RevMobBuddyExample.Android
{
	[Activity(Label = "AdsExample"
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

			g.Services.AddService<IAdManager>(new AdMobAdapter(this, "ca-app-pub-5144527466254609~7481979674",
				"ca-app-pub-3940256099942544/1033173712", "ca-app-pub-3940256099942544/5224354917"));

			g.Run();
		}
	}
}

