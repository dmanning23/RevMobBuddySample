# Getting Started with xamarin

##Integrate in Android

Fullscreen, or interstitial, is an advertisement that fills the whole screen.

Here, you have to add following required permission into your AndroidManifest.xml file by using following line of code.
```
<uses-permission android:name="android.permission.INTERNET" />
```

Now, add the required RevMob activity inside the application tag.
```
<activity android:name="com.revmob.FullscreenActivity" android:theme="@android:style/Theme.Translucent" android:configChanges="keyboardHidden|orientation"></activity>
```

You have to start session using following line of code.
```
RevMob.StartWithListener(currentActivity, startSessionListener, "paste_your_RevMob_Media_ID_for_android_here");
```

You can create object using following line of code.
```
RevMobFullscreen fullscreen;
Activity currentActivity;
```

To Create Interstitial

```
fullscreen = RevMob.Session().CreateFullscreen(currentActivity, showLoadFullscreenAdListener);
```

Listeners

Listeners (which is also called Delegates/Callbacks) help you to follow Ad workflow. Whenever state of the Ad will change RevMob SDK will fore events respectively. It calls specific methods as per the callbacks. For example, if Ad is loaded successfully or not, you can identify whenever user click on Ad etc. Following line of code gives brief idea about it.

```
CallbackStartSessionListener startSessionListener = new CallbackStartSessionListener(currentActivity);

class CallbackStartSessionListener : RevMobAdsListener
{
  Activity currentActivity;
  public CallbackStartSessionListener(Activity currentActivity)
  {
    Console.WriteLine("CallbackStartSessionListener");
    this.currentActivity = currentActivity;

  }
  public override void OnRevMobSessionIsStarted()
  {
    Console.WriteLine("Session started");
    fullscreen = RevMob.Session().CreateFullscreen(currentActivity, showLoadFullscreenAdListener);

  }
  public override void OnRevMobSessionNotStarted(String error)
  {
    Console.WriteLine("RevMob session failed to start.");
  }
}
```

Interstitial listeners

```
CallbackShowLoadFullscreen showLoadFullscreenAdListener = new CallbackShowLoadFullscreen(currentActivity);

class CallbackShowLoadFullscreen : RevMobAdsListener
{
  Activity currentActivity;

  public CallbackShowLoadFullscreen(Activity currentActivity)
  {
    this.currentActivity = currentActivity;
    Console.WriteLine("CallbackShowLoadFullscreen");
  }

  public override void OnRevMobAdReceived()
  {
    Console.WriteLine("LoadFullscreen ad received and ready to be displayed.");
    if (fullscreen != null){
      fullscreen.Show();
    }
  }

}
```
