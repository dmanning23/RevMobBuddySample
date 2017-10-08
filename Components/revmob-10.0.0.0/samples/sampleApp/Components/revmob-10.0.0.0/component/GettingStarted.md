# Getting Started with xamarin

##Integrate in Android

Interstitial, is an advertisement that fills the whole screen.

Here, you have to add following required permission into your AndroidManifest.xml file by using following line of code.
```
<uses-permission android:name="android.permission.INTERNET" />
```

Now, add the required RevMob activity inside the application tag.
```
<activity android:name="rm.com.android.sdk.RmInterstitial"
          android:configChanges="keyboardHidden|orientation|screenSize">
</activity>
```

You have to start session using following line of code.
```
Rm.Init(currentActivity, "paste_your_Revmob_App_ID_for_android_here");
```

You can create object using following line of code.
```
Activity currentActivity;
```

To Create Interstitial

```
Rm.CacheInterstitial(REVMOB_PLACEMENT_ID, cacheInterstitialAdListener);
```

Listeners

Listeners (which is also called Delegates/Callbacks) help you to follow Ad workflow. Whenever state of the Ad will change RevMob SDK will fore events respectively. It calls specific methods as per the callbacks. For example, if Ad is loaded successfully or not, you can identify whenever user click on Ad etc. Following line of code gives brief idea about it.

Interstitial listeners

```
class CallbackCacheInterstitial :  Java.Lang.Object, IRmListenerCache
		{
			Activity currentActivity;

			public CallbackCacheInterstitial(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}

			public void OnRmAdNotReceived(String error)
			{
				Console.WriteLine("Interstitial not received!");
			}

			public void OnRmAdReceived()
			{
				Console.WriteLine("Interstitial ad received and ready to be displayed.");
			}

		}
```


```
		class CallbackShowInterstitial : Java.Lang.Object, IRmListenerShow
		{
			Activity currentActivity;

			public CallbackShowInterstitial(Activity currentActivity)
			{
				this.currentActivity = currentActivity;
			}
			public void OnRmAdFailed(String error)
			{
				Console.WriteLine("Interstitial dismissed!");
			}

			public void OnRmAdDismissed()
			{
				Console.WriteLine("Interstitial dismissed!");
			}

			public void OnRmAdClicked()
			{
				Console.WriteLine("Interstitial clicked!");
			}

			public void OnRmAdDisplayed()
			{
				Console.WriteLine("Interstitial displayed!");
			}

		}
```
