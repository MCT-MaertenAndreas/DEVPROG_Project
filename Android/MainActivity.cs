using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EindProject.Droid
{
	[Activity (Label = "EindProject.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	[IntentFilter(
		new [] { Android.Content.Intent.ActionView },
		DataScheme = "https",
		DataHost = "wakatime.damon.sh",
		DataPathPrefix = "/android",
		AutoVerify = true,
		Categories = new []
        {
			Android.Content.Intent.CategoryDefault,
			Android.Content.Intent.CategoryBrowsable
        }
	)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

