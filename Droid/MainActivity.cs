using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Messaging;

namespace FirstAid.Droid
{
	[Activity (Label = "FirstAid.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			var emailTask = MessagingPlugin.EmailMessenger;
            try
            {
                Console.WriteLine("Attempting to start forms.");
                global::Xamarin.Forms.Forms.Init(this, bundle);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Found the following Exception: " + ex.GetType().ToString());
                System.Diagnostics.Debug.WriteLine("Found the following Message: " + ex.Message);
            }
            LoadApplication(new global::FirstAid.App());
		}
	}
}

